using System;
using System.Collections.Generic;
using System.IO;

namespace Assessment.Processors
{
    /// <summary>
    /// Provides ability to get text from file.
    /// </summary>
    public static class FileProcessor
    {
        /// <summary>
        /// Returns text with punctuation removed 
        /// </summary>
        /// <param name="filename">Filename to get text from.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="filename"/> is <see langword="null" />
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="filename"/> consists only of white space.
        /// </exception>
        public static IEnumerable<string> GetText(string filename)
        {
            if (filename == null)
            {
                throw new ArgumentNullException(nameof(filename), $"Param: {nameof(filename)} is null.");
            }

            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentOutOfRangeException(nameof(filename), $"Param: {nameof(filename)} is null or contains whitespace.");
            }

            var text = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), filename));
            
            return TextNormaliser.NormaliseText(text);
        }

       
    }
}