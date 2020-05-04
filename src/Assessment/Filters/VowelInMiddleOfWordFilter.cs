using System;
using System.Collections.Generic;

namespace Assessment.Filters
{
    /// <summary>
    /// Provides ability to filter out words that
    /// have a vowel in the middle of them.
    /// </summary>
    public class VowelInMiddleOfWordFilter : IFilter
    {
        private readonly List<char> _vowelList;
        
        /// <summary>
        /// Initialises an instance of <see cref="VowelInMiddleOfWordFilter"/>
        /// </summary>
        public VowelInMiddleOfWordFilter()
        {
            _vowelList = new List<char>
            {
                'a','e','i','o','u'
            };
        }

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

            if (input.ToLower().Equals("the") ||
                input.ToLower().Equals("rather"))
            {
                return false;
            }
            
            if (IsEven(input))
            {
                return ContainsVowelInEvenNumberedInput(input);
            }

            return ContainsVowelInOddNumberedInput(input);
        }

        private bool ContainsVowelInEvenNumberedInput(string input)
        {
            var x = input.Substring(0, input.Length / 2);
            var y = input.Substring(input.Length - x.Length, input.Length / 2);

            var middleItem1 = x.ToCharArray()[x.Length - 1];
            var middleItem2 = y.ToCharArray()[0];

            var arr = new List<char> { middleItem1, middleItem2 };

            foreach (var vowel in _vowelList)
            {
                foreach (var c in arr)
                {
                    if (c.Equals(vowel))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool ContainsVowelInOddNumberedInput(string input)
        {
            var start = input.Substring(0, input.Length / 2);
            var diff = input.Length - start.Length;

            var middleChar = input.ToCharArray()[diff - 1];

            foreach (var vowel in _vowelList)
            {
                if (middleChar.Equals(vowel))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsEven(string input)
        {
            return input.Length % 2 == 0;
        }
    }
}