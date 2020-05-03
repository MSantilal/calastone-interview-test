using System;
using Assessment.Filters;
using Xunit;

namespace Assessment.Tests.Filters
{
    public class CharTFilterTests
    {
        [Fact]
        public void Filter_validates_params()
        {
            var sut = new CharTFilter();

            Assert.Throws<ArgumentNullException>(() => sut.Filter(null));
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Filter(" "));
        }

        [Fact]
        public void Returns_false_if_input_does_not_contain_t()
        {
            var sut = new CharTFilter();

            Assert.False(sut.Filter("pinball"));
        }

        [Fact]
        public void Returns_true_if_input_does_contain_t()
        {
            var sut = new CharTFilter();

            Assert.True(sut.Filter("kart"));
        }

        [Fact]
        public void Returns_true_if_input_does_contain_an_upper_case_t()
        {
            var sut = new CharTFilter();

            Assert.True(sut.Filter("Tango"));
        }
    }
}