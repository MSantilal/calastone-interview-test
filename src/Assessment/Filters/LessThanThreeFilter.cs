using System;

namespace Assessment.Filters
{
    /// <summary>
    /// Provides ability to filter out words that have a length
    /// less than 3.
    /// </summary>
    public sealed class LessThanThreeFilter : IFilter
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

            return input.Length < 3;
        }
    }
}