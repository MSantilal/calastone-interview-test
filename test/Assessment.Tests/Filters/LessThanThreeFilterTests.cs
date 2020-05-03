using System;
using Assessment.Filters;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace Assessment.Tests.Filters
{
    public class LessThanThreeFilterTests
    {
        [Fact]
        public void Filter_validates_params()
        {
            var sut = new LessThanThreeFilter();

            Assert.Throws<ArgumentNullException>(() => sut.Filter(null));
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Filter(" "));
        }

        [Fact]
        public void Returns_false_if_input_is_more_that_three()
        {
            var sut = new LessThanThreeFilter();

            Assert.False(sut.Filter("hello"));
        }

        [Fact]
        public void Returns_true_if_input_is_less_that_three()
        {
            var sut = new LessThanThreeFilter();

            Assert.True(sut.Filter("hi"));
        }
    }
}
