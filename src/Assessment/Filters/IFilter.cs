﻿namespace Assessment.Filters
{
    /// <summary>
    /// Provides ability to filter text
    /// </summary>
    public interface IFilter
    {
        /// <summary>
        /// Determines whether filter will be applied on input.
        /// </summary>
        /// <param name="input">The word to run the filter on</param>
        /// <returns>
        /// <see langword="true" /> if filter matches; <see langword="false" /> if
        /// filter does not match.
        /// </returns>
        bool Filter(string input);
    }
}