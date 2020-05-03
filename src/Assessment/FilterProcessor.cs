using System;
using System.Collections.Generic;
using System.Text;
using Assessment.Filters;

namespace Assessment
{
    internal sealed class FilterProcessor
    {
        private readonly IEnumerable<IFilter> _filters;
        private readonly StringBuilder _builder;

        /// <summary>
        /// Initialises an instance of <see cref="FilterProcessor"/>
        /// </summary>
        /// <param name="filters"></param>
        public FilterProcessor(IEnumerable<IFilter> filters)
        {
            _filters = filters;
            _builder = new StringBuilder();
        }

        /// <summary>
        /// Returns a string of words processed by a filter
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
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(input, $"Param: {nameof(input)} is null.");
            }

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentOutOfRangeException(input, $"Param: {nameof(input)} is null or has white space characters.");
            }

            foreach (var item in _filters)
            {
                if (item.Filter(input))
                {
                    _builder.AppendLine(input);
                }
            }

            return _builder.ToString();
        }

    }
}