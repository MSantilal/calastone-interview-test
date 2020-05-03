using System;
using Assessment.Filters;
using Xunit;

namespace Assessment.Tests.Filters
{
    public class VowelInMiddleOfWordFilterTests
    {
        [Fact]
        public void Filter_validates_params()
        {
            var sut = new VowelInMiddleOfWordFilter();

            Assert.Throws<ArgumentNullException>(() => sut.Filter(null));
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Filter(" "));
        }

        [Fact]
        public void Returns_true_if_word_contains_vowel_in_middle_for_odd_numbered_input()
        {
            var sut = new VowelInMiddleOfWordFilter();
            
            Assert.True(sut.Filter("currently"));
            Assert.True(sut.Filter("clean"));
        }

        [Fact]
        public void Returns_true_if_word_is_the_or_rather()
        {
            var sut = new VowelInMiddleOfWordFilter();

            Assert.True(sut.Filter("the"));
            Assert.True(sut.Filter("rather"));
        }

        [Fact]
        public void Returns_false_if_word_does_not_contains_vowel_in_middle_for_odd_numbered_input()
        {
            var sut = new VowelInMiddleOfWordFilter();

            Assert.False(sut.Filter("substring"));
            Assert.False(sut.Filter("another"));
        }

        [Fact]
        public void Returns_true_if_word_does_contain_a_vowel_in_middle_for_even_numbered_input()
        {
            var sut = new VowelInMiddleOfWordFilter();

            Assert.True(sut.Filter("what"));
            Assert.True(sut.Filter("mate"));
            Assert.True(sut.Filter("finest"));
        }

       
    }
}