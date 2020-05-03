using System;

namespace Assessment.Filters
{
    /// <summary>
    /// Provides ability to filter out words that contain the character
    /// 't' in them.
    /// </summary>
    public class CharTFilter : IFilter
    {
        /// <inheritdoc />
        /// <exception cref="ArgumentNullException">
        /// <paramref name="input"/> is <see langword="null" />
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="input"/> consists only of white space.
        /// </exception>
        public bool Filter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input), $"Param: {nameof(input)} is null.");
            }

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentOutOfRangeException(nameof(input), $"Param: {nameof(input)} is null or has white space characters.");
            }

            var charArray = input.ToCharArray();

            foreach (var character in charArray)
            {
                if (char.ToLower(character).Equals('t'))
                {
                    return true;
                }
            }

            return false;
        }
    }
}