using ShaderTools.Shaders.Extensions;
using ShaderTools.Shaders.Textures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.IO
{
    public static class FileUtil
    {
        /// <summary>
        /// Maximum shader files (line 3422 in tr_shader.c)
        /// </summary>
        private const int MaxShaderFiles = 4096;

        /// <summary>
        /// /ET/etmain
        /// </summary>
        public static string ETMain { get; private set; }

        /// <summary>
        /// /ET/
        /// </summary>
        public static string Game { get; private set; }

        /// <summary>
        /// /ET/etmain/textures/
        /// </summary>
        public static string Textures { get; private set; }

        /// <summary>
        /// /ET/etmain/scripts/
        /// </summary>
        public static string Scripts { get; private set; }

        /// <summary>
        /// Whether ET folder is defined and validated.
        /// </summary>
        public static bool Defined { get; private set; }

        /// <summary>
        /// Allowed image types (jpg, tga, bmp).
        /// </summary>
        public static string[] TextureExtensions = { ".jpg", ".tga", ".bmp" };

        /// <summary>
        /// Validate texture file location and extension.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static TextureStatus Validate(string shortPath)
        {
            if (shortPath == null)
                throw new ArgumentNullException(nameof(shortPath));

            // Compare file extension against allowed filetypes
            string fileExt = Path.GetExtension(shortPath);

            // Allow missing extension, but not a wrong one
            if (fileExt != string.Empty && !TextureExtensions.Contains(fileExt))
            {
                throw new FileLoadException($"Unknown extension {fileExt}", shortPath);
            }

            // If no ET folder defined, return unknown state
            if (FileUtil.Defined == false)
            {
                return TextureStatus.Unknown;
            }

            // Get full file path for file validation
            string path = Path.Combine(FileUtil.Textures, shortPath);

            // File exists, check for multiple with same name but different image format
            if (File.Exists(path))
            {
                foreach (var ext in TextureExtensions)
                {
                    if (ext == fileExt) continue;

                    // Return a prompt for changing file extension
                    if (File.Exists(Path.ChangeExtension(path, fileExt)))
                    {
                        return TextureStatus.DuplicateExtension;
                    }
                }

                // Found with no "duplicates"
                return TextureStatus.Ok;
            }

            // File doesn't exist, check if only extension is wrong
            else
            {
                foreach (var ext in TextureExtensions)
                {
                    if (ext == fileExt) continue;

                    // Return a prompt for changing file extension
                    if (File.Exists(Path.ChangeExtension(path, fileExt)))
                        return TextureStatus.WrongExtension;
                }

                // File not found
                return TextureStatus.Missing;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texture"></param>
        /// <returns></returns>
        public static byte[] GetTexture(Texture texture)
        {
            var status = Validate(texture.Path);

            if (status == TextureStatus.Missing || status == TextureStatus.Unknown)
                return null;

            // TODO
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void SetGamePath(string path)
        {
            if (!Directory.Exists(path))
                throw MissingDir(path);

            string etmain = Path.Combine(path, Token.etmain);

            if (!Directory.Exists(etmain))
                throw MissingDir(etmain);

            string scripts = Path.Combine(path, Token.etmain);

            if (!Directory.Exists(scripts))
                throw MissingDir(scripts);

            string textures = Path.Combine(path, Token.textures);

            if (!Directory.Exists(textures))
                throw MissingDir(textures);

            string executable = Path.Combine(path, Token.ETexe);

            /*
            if (!File.Exists(executable))
                throw MissingFile(executable);
            */

            // All good
            FileUtil.Game = path;
            FileUtil.ETMain = etmain;
            FileUtil.Textures = textures;
            FileUtil.Scripts = scripts;
            FileUtil.Defined = true;
        }

        private static DirectoryNotFoundException MissingDir(string path)
            => new DirectoryNotFoundException("Directory not found: " + path);

        private static FileNotFoundException MissingFile(string path)
            => new FileNotFoundException("File not found: " + path);
    }
}
