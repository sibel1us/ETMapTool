﻿using ShaderTools.Objects;
using ShaderTools.Objects.EditorDirectives;
using ShaderTools.Objects.GeneralDirectives;
using ShaderTools.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Utilities.IO
{
    public class ShaderParser
    {
        internal enum ParserPosition
        {
            Outside,
            InShader,
            InStage,
            EndOfFile
        }

        public string Path { get; set; }

        private ParserPosition Position { get; set; }

        /// <summary>
        /// .shader-file's lines
        /// </summary>
        private string[] Lines { get; set; }

        /// <summary>
        /// Line number in the shader file
        /// </summary>
        private int Index { get; set; }

        /// <summary>
        /// Gets the current line with whitespace and comments trimmed out
        /// </summary>
        private string CurrentLine
        {
            get
            {
                // Get line, get rid of whitespace
                string line = Lines[Index];

                // Skip empty lines
                if (string.IsNullOrWhiteSpace(line))
                {
                    return string.Empty;
                }

                int commentIndex = line.IndexOf("//");

                // Line starts with a comment
                if (commentIndex != -1)
                {
                    // Parse header comments if not inside a shader
                    if (Position == ParserPosition.Outside && commentIndex == 0)
                    {
                        return line.TrimEnd();
                    }

                    // Otherwise skip comments
                    return line.Substring(0, commentIndex).Trim();
                }

                // Return line
                return line.Trim();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shaderFilePath"></param>
        public ShaderParser(string shaderFilePath)
        {
            if (!File.Exists(shaderFilePath))
            {
                throw new FileNotFoundException("File not found.", shaderFilePath);
            }

            this.Path = shaderFilePath;
            this.Lines = File.ReadAllLines(Path);
        }

        /// <summary>
        /// Move forward, passing whitespace/comments-only. Throws if the file ends while inside shader.
        /// </summary>
        /// <exception cref="ShaderFileStructureException"/>
        private void PassWhiteSpace()
        {
            while (Index < Lines.Length)
            {
                // Break out of the loop once a line with some content is encountered
                if (!string.IsNullOrWhiteSpace(CurrentLine))
                {
                    return;
                }

                Index++;
            }

            // End of file reached

            if (Position == ParserPosition.InShader)
            {
                throw new ShaderFileStructureException("Missing closing bracket at the end of file.", Path);
            }

            if (Position == ParserPosition.InStage)
            {
                throw new ShaderFileStructureException("Two missing closing brackets at the end of file.", Path);
            }

            Position = ParserPosition.EndOfFile;
        }

        /// <summary>
        /// Not catch-ed!
        /// </summary>
        /// <returns></returns>
        public List<Shader> GetShaders()
        {
            var shaders = new List<Shader>();
            this.Index = 0;
            this.Position = ParserPosition.Outside;

            while (Position != ParserPosition.EndOfFile)
            {
                var shader = ParseShader();

                if (shader != null)
                {
                    shaders.Add(shader);
                }
            }

            if (Position == ParserPosition.InShader)
            {
                throw new ShaderFileStructureException("Missing closing brace at the end of file.", Path);
            }

            if (Position == ParserPosition.InStage)
            {
                throw new ShaderFileStructureException("Two missing closing braces at the end of file.", Path);
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Shader ParseShader()
        {
            PassWhiteSpace();

            // TODO: check if this check is ever needed
            if (Position == ParserPosition.EndOfFile)
            {
                throw new ShaderFileStructureException($"Unexpected end of file.", Index, Path);
            }

            // Get shader, move forward one line and set reader depth
            string shaderName = ParseShaderName();

            if (shaderName == null)
            {
                Logger.Error($"Invalid shader name '{CurrentLine}'", Index, Path);
            }

            Shader shader = new Shader(shaderName);

            Index++;
            Position = ParserPosition.InShader;

            // Skip whitespace and comments
            PassWhiteSpace();

            // Expect an opening brace { after shader name definition
            if (CurrentLine != Token.OpeningBrace)
            {
                throw new ShaderFileStructureException($"Expecting {Token.OpeningBrace}", Index, Path);
            }

            // Move past opening brace, we are now inside the shader
            Position = ParserPosition.InShader;

            while (Position != ParserPosition.Outside)
            {
                // Move forward until hitting some text
                Index++;
                PassWhiteSpace();

                // Parse editor level
                if (Position == ParserPosition.InShader)
                {
                    // Reached end of current shader block
                    if (CurrentLine == Token.ClosingBrace)
                    {
                        Position = ParserPosition.Outside;
                        continue;
                    }

                    // Hit a stage
                    if (CurrentLine == Token.OpeningBrace)
                    {
                        Position = ParserPosition.InStage;
                        continue;
                    }

                    // Parse surfaceparms
                    if (LineStartsWith(Token.surfaceparm))
                    {
                        // Add shader, and log a warning if it's already added
                        Surfaceparms? parsed = ParseSurfaceparm();

                        if (parsed.HasValue)
                        {
                            if (!shader.Surfparms.Add(parsed.Value))
                                Logger.Warn($"Duplicate surfaceparm {CurrentLine}.", Index, Path);
                        }
                        else
                        {
                            Logger.Warn($"Invalid surfaceparm {CurrentLine}.", Index, Path);
                        }

                        continue;
                    }
                    else
                    {
                        IGeneralDirective parsed = ParseGeneralDirective();

                        if (parsed != null)
                        {
                            string err = "";//shader.AddGeneralDirective(parsed);

                            if (!string.IsNullOrEmpty(err))
                                Logger.Warn($"{err} '{CurrentLine}'.", Index, Path);
                        }

                        continue;
                    }
                }

                // Parse stage
                else if (Position == ParserPosition.InStage)
                {
                    // Reached end of stage
                    if (CurrentLine == Token.ClosingBrace)
                    {
                        Position = ParserPosition.Outside;
                        break;
                    }
                }
            }

            // This point should be reached when current line is the closing brace }
            Index++;
            return shader;
        }

        private string ParseShaderName()
        {
            // TODO: shader name parsing and validation
            return CurrentLine;
        }

        /// <summary>
        /// Parses a surfaceparm from the current line, returning null if it can't be matched to any surfaceparm.
        /// </summary>
        /// <returns></returns>
        private Surfaceparms? ParseSurfaceparm()
        {
            if (Enum.TryParse(GetValue(Token.surfaceparm), out Surfaceparms result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Parses general, editor, q3map, and other directives such as skyparms, fogparms and surfaceparms.
        /// </summary>
        /// <returns></returns>
        private IGeneralDirective ParseGeneralDirective()
        {
            // Parse editor directives
            if (LineStartsWith(Token.qer))
            {
                var parsed = ParseEditorDirective();

                if (parsed == null)
                {
                    Logger.Warn($"Invalid editor-property '{CurrentLine}'", Index, Path);
                }

                return parsed;
            }

            // Parse compiler directives
            if (LineStartsWith(Token.q3map))
            {
                // TODO: q3map things
            }

            // Parse cull
            if (LineStartsWith(Token.cull))
            {
                if (Enum.TryParse(GetValue(Token.cull), out CullValue result))
                {
                    return new Cull(result);
                }
                else
                {
                    Logger.Warn($"Unknown cull value '{CurrentLine}'", Index, Path);
                    return null;
                }
            }

            // Parse skyparms
            if (LineStartsWith(Token.skyparms))
            {
                // TODO
                return null;
            }

            // Parse fogparms
            if (LineStartsWith(Token.fogparms))
            {
                // TODO
                return null;
            }

            // Can't recognize directive - return error
            Logger.Warn($"Unrecognized general directive '{CurrentLine}'", Index, Path);
            return new Unknown(CurrentLine);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ed"></param>
        private IEditorDirective ParseEditorDirective()
        {
            // Parse editor image
            if (LineStartsWith(Token.qer_editorimage))
            {
                return new EditorImage(); // TODO: texture path parser
            }

            // Parse nocarve-property
            if (LineStartsWith(Token.qer_nocarve))
            {
                //Logger.Warn($"Duplicate {Token.qer_nocarve}-property in shader.", Index, Path);
                return new NoCarve();
            }

            // Parse qer_transparency
            if (LineStartsWith(Token.qer_trans))
            {
                double parsed = ParseDouble(GetValue(Token.qer_trans));

                if (parsed < 0 || parsed > 1)
                    Logger.Info($"Property {Token.qer_trans} should be between 0 and 1.", Index, Path);

                return new Transparency();
            }

            // Invalid qer_-property
            return null;
        }

        private object ParseStage()
        {
            return new object();
        }

        private double ParseDouble(string input)
        {
            return double.Parse(input, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Check if current line starts with the input string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool LineStartsWith(string input) => CurrentLine.StartsWith(input, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Get the current line, excluding prefix-length from the start.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        private string GetValue(string prefix) => CurrentLine.Substring(prefix.Length).TrimStart();
    }
}
