using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ETMapHelper.Objects
{
    /// <summary>
    /// This class so-far only handles replacing the BITMAP-property.
    /// </summary>
    public class AseModel
    {
        private string FilePath;
        private string Temporary = "asemodel.tmp";
        private string Backup;

        private const string MATERIAL_NAME = "*MATERIAL_NAME";
        private const string BITMAP = "*BITMAP\t";
        private const string GEOMOBJECT = "*GEOMOBJECT";

        public AseModel(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Couldn't find file \"{filePath}\"");

            FilePath = filePath;
            Backup = Path.GetFileNameWithoutExtension(filePath);
        }

        public AseModel()
        {

        }

        public string FixBitmaps()
        {
            // Initialize counters.
            int linesRead = 0;
            int linesFixed = 0;

            var timer = new Stopwatch();
            timer.Start();

            // Initialize the current line, error message and material.
            string line = "";
            string error = null;
            string material = null;

            // Assume we are in materials by default.
            bool inMaterials = true;
            
            // Create temporary file.
            if (!File.Exists(Temporary))
                File.Create(Temporary).Close();

            StreamReader reader;
            try
            { reader = new StreamReader(FilePath); }
            catch
            { return $"Could not open file {FilePath}, check that it is not open in another process."; }

            StreamWriter writer;
            try
            { writer = new StreamWriter(Temporary); }
            catch
            { return $"Could write to temporary file {Temporary}, check that it is not open in another process."; }


            while ((line = reader.ReadLine()) != null)
            {
                linesRead++;

                // Passed materials already, so just write the rest of the file as usual.
                if (!inMaterials)
                {
                    writer.WriteLine(line);
                    continue;
                }

                // No longer in materials, check for leftovers and keep reading/writing the file.
                if (line.Trim().StartsWith(GEOMOBJECT))
                {
                    if (material != null)
                    {
                        error = $"Material name {material} left over after leaving materials on line {linesRead}.";
                        break;
                    }

                    inMaterials = false;
                    writer.WriteLine(line);
                    continue;
                }

                // A material is not stored yet, look for one.
                if (material == null)
                {
                    // Bitmap found despite no material being saved. Stop file processing.
                    if (line.Trim().StartsWith(BITMAP))
                    {
                        error = $"ERROR: Found bitmap without material present on line {linesRead} \"{line.Trim()}\"";
                        break;
                    }

                    // If material found, save it in memory. Write the line as usual.
                    if (line.Trim().StartsWith(MATERIAL_NAME)) material = GetMaterial(line);
                    writer.WriteLine(line);
                }

                // A material is stored, look for a bitmap
                else
                {
                    // Material found despite one being stored already. Stop file processing.
                    if (line.Trim().StartsWith(MATERIAL_NAME))
                    {
                        error = $"ERROR: Material {material} already in store, but found line {linesRead} \"{line.Trim()}\"";
                        break;
                    }
                    
                    // Bitmap found. Try to replace it and continue.
                    if (line.Trim().StartsWith(BITMAP))
                    {
                        var replacement = ReplaceBitmap(material, line);
                        writer.WriteLine(ReplaceBitmap(material, line));
                        if (replacement != line) linesFixed++;
                        material = null;
                    }

                    // No bitmap found yet, keep going.
                    else writer.WriteLine(line);

                }
            }
            // Reached end of file, or encountered an error.

            // Close filestreams.
            reader.Close();
            writer.Close();

            // Encountered an error. Delete the temporary file.
            if (error != null)
            {
                File.Delete(Temporary);
                return error;
            }

            // No error encountered.
            //File.Copy(FilePath, Backup);
            //File.Delete(FilePath);

            timer.Stop();
            var ms = Math.Round(timer.Elapsed.TotalMilliseconds);

            if (linesFixed == 0)
                return $"Processed file {Path.GetFileName(FilePath)} in {ms}ms, nothing to fix. It probably wasn't created by q3map2, or was already fixed.";

            return $"Replaced {linesFixed} bitmaps on {linesRead} lines in {ms}ms in file {Path.GetFileName(FilePath)}.";
        }

        /// <summary>
        /// Gets the MATERIAL-string from the line.
        /// </summary>
        public string GetMaterial(string line)
        {
            var index = line.IndexOf('"') + 1;
            return line.Substring(index, line.Length - index - 1);
        }

        /// <summary>
        /// Replaces the bitmap with stored MATERIAL on the line. Return just the line if it isn't "broken".
        /// </summary>
        public string ReplaceBitmap(string replaceWith, string line)
        {
            var test = line.IndexOf("\\");
            if (line.IndexOf("\\") == -1) return line;
            if (line[line.IndexOf('"') + 1] != '.') return line;

            return line.Substring(0, line.IndexOf('"') + 1) + replaceWith + "\"";
        }
    }
}
