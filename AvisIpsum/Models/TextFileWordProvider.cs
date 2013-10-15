using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AvisIpsum.Models
{
    /// <summary>
    /// Specialized version of a Word Provider, which reads words from a text file
    /// </summary>
    public class TextFileWordProvider : WordProvider
    {
        static TextFileWordProvider ()
        {
            var wordsInFile = new List<string>();

            var fullPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Words.txt"));

            using (var reader = new StreamReader(fullPath))
            {
                while (!reader.EndOfStream)
                {
                    wordsInFile.Add(reader.ReadLine());
                }
            }

            words = wordsInFile.Distinct().ToArray<string>();
        }
    }
}