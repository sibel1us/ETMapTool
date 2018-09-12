using ShaderTools.Shaders;
using ShaderTools.Shaders.Exceptions;
using ShaderTools.Shaders.General;
using ShaderTools.Shaders.Surfaceparm;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.IO
{
    internal enum ReaderDepth
    {
        Root,
        Shader,
        Stage,
        EndOfFile
    }

    public class ShaderReader
    {
        public string Path { get; set; }

        private ReaderDepth Depth { get; set; }

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
                string line = Lines[Index].Trim();

                // No need for null checks as we access array index
                if (string.IsNullOrWhiteSpace(line))
                    return line;

                // If line has comment, get part before it
                if (line.IndexOf("//") != -1)
                    return line.Substring(0, line.IndexOf("//")).TrimEnd();

                // Return line as-is otherwise
                return line;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shaderFilePath"></param>
        public ShaderReader(string shaderFilePath)
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
            
            if (Depth == ReaderDepth.Shader)
            {
                throw new ShaderFileStructureException("Missing closing bracket at the end of file.", Path);
            }

            if (Depth == ReaderDepth.Stage)
            {
                throw new ShaderFileStructureException("Two missing closing brackets at the end of file.", Path);
            }

            Depth = ReaderDepth.EndOfFile;
        }

        /// <summary>
        /// Not catch-ed!
        /// </summary>
        /// <returns></returns>
        public List<Shader> GetShaders()
        {
            var shaders = new List<Shader>();
            this.Index = 0;
            this.Depth = ReaderDepth.Root;

            while (Depth != ReaderDepth.EndOfFile)
            {
                var shader = ParseShader();

                if (shader != null)
                {
                    shaders.Add(shader);
                }
            }

            if (Depth == ReaderDepth.Shader)
            {
                throw new ShaderFileStructureException("Missing closing brace at the end of file.", Path);
            }

            if (Depth == ReaderDepth.Stage)
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
            if (Depth == ReaderDepth.EndOfFile)
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
            Depth = ReaderDepth.Shader;

            // Skip whitespace and comments
            PassWhiteSpace();

            // Expect an opening brace { after shader name definition
            if (CurrentLine != Token.OpeningBrace)
            {
                throw new ShaderFileStructureException($"Expecting {Token.OpeningBrace}", Index, Path);
            }

            // Move past opening brace, we are now inside the shader
            Depth = ReaderDepth.Shader;

            while (Depth != ReaderDepth.Root)
            {
                // Move forward until hitting some text
                Index++;
                PassWhiteSpace();

                // Parse editor level
                if (Depth == ReaderDepth.Shader)
                {
                    // Reached end of current shader block
                    if (CurrentLine == Token.ClosingBrace)
                    {
                        Depth = ReaderDepth.Root;
                        continue;
                    }

                    // Hit a stage
                    if (CurrentLine == Token.OpeningBrace)
                    {
                        Depth = ReaderDepth.Stage;
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
                            string err = shader.AddGeneralDirective(parsed);

                            if (!string.IsNullOrEmpty(err))
                                Logger.Warn($"{err} '{CurrentLine}'.", Index, Path);
                        }

                        continue;
                    }
                }

                // Parse stage
                else if (Depth == ReaderDepth.Stage)
                {
                    // Reached end of stage
                    if (CurrentLine == Token.ClosingBrace)
                    {
                        Depth = ReaderDepth.Root;
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
        /// Returns null on failures.
        /// </summary>
        /// <returns></returns>
        private IGeneralDirective ParseGeneralDirective()
        {
            // Parse editor directives
            if (LineStartsWith(Token.qer))
            {
                IEditorDirective parsed = ParseEditorDirective();

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
            return null;
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
                return new EditorNoCarve();
            }

            // Parse qer_transparency
            if (LineStartsWith(Token.qer_trans))
            {
                double parsed = ParseDouble(GetValue(Token.qer_trans));

                if (parsed < 0 || parsed > 1)
                    Logger.Info($"Property {Token.qer_trans} should be between 0 and 1.", Index, Path);

                return new EditorTransparency();
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
