using System;
using System.Collections.Generic;
using System.Linq;
using Assessment.Processors;
using Xunit;

namespace Assessment.Tests.Processors
{
    public class TextNormaliserTests
    {
        [Fact]
        public void Normaliser_validates_params()
        {
            Assert.Throws<ArgumentNullException>(() => TextNormaliser.NormaliseText(null));
            Assert.Throws<ArgumentOutOfRangeException>(() => TextNormaliser.NormaliseText(" "));
        }


        [Fact]
        public void Returns_list_of_valid_text()
        {
            const string text = "Hello. How are you today?";
            var expected = new List<string>
            {
                "Hello",
                "How",
                "are",
                "you",
                "today",
            };

            var actual = TextNormaliser.NormaliseText(text).ToList();

            Assert.Equal(expected[0], actual[0]);
            Assert.Equal(expected[1], actual[1]);
            Assert.Equal(expected[2], actual[2]);
            Assert.Equal(expected[3], actual[3]);
            Assert.Equal(expected[4], actual[4]);

        }
    }
}