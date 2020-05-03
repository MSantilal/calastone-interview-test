using System;
using System.Collections.Generic;
using System.Linq;
using Assessment.Filters;

namespace Assessment.Processors
{
    /// <summary>
    /// Provides ability to process text
    /// </summary>
    public sealed class FilterProcessor
    {
        private readonly List<IFilter> _filters;

        /// <summary>
        /// Initialises an instance of <see cref="FilterProcessor"/>
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="filters"/> is <see langword="null" />
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="filters"/> is empty.
        /// </exception>
        public FilterProcessor(IEnumerable<IFilter> filters)
        {
            if (filters == null)
            {
                throw new ArgumentNullException(nameof(filters), $"Param: {nameof(filters)} is null.");
            }

            if (!filters.Any())
            {
                throw new ArgumentOutOfRangeException(nameof(filters), $"Param: {nameof(filters)} contains no filters.");
            }

            _filters = (List<IFilter>) filters;
        }

        /// <summary>
        /// Returns a processed string.
        /// </summary>
        /// <param name="input">Word to filter</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="input"/> is <see langword="null" />
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="input"/> consists only of white space.
        /// </exception>
        public string Process(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), $"Param: {nameof(input)} is null.");
            }

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentOutOfRangeException(nameof(input), $"Param: {nameof(input)} is null or contains whitespace.");
            }
            
            return _filters.TrueForAll(f => f.Filter(input)) ? string.Empty : input;
        }

    }
}