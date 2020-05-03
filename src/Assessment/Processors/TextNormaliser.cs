using System;
using System.Collections.Generic;

namespace Assessment.Processors
{
    /// <summary>
    /// Provides ability to get text from file without non-alphabetical characters.
    /// </summary>
    public static class TextNormaliser
    {
        /// <summary>
        /// Returns a list of strings without non-alphabetical characters.
        /// </summary>
        /// <param name="text">Text to normalise</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="text"/> is <see langword="null" />
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="text"/> consists only of white space.
        /// </exception>
        public static IEnumerable<string> NormaliseText(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text), $"Param: {nameof(text)} is null.");
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentOutOfRangeException(nameof(text), $"Param: {nameof(text)} is null or contains whitespace.");
            }

            var splitText = text.Split(GetListOfPunctuationUsed(text));
            var normalisedText = new List<string>();

            foreach (var str in splitText)
            {
                if (!string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str))
                {
                    foreach (var value in str.Split(' '))
                    {
                        if (!string.IsNullOrEmpty(value))
                        {
                            normalisedText.Add(value);
                        }
                    }
                }
            }

            return normalisedText;
        }

        private static char[] GetListOfPunctuationUsed(string text)
        {
            var list = new List<char>();

            foreach (var c in text.ToCharArray())
            {
                if (char.IsPunctuation(c))
                {
                    if (!list.Contains(c))
                    {
                        list.Add(c);
                    }
                }
            }

            return list.ToArray();
        }
    }
}
