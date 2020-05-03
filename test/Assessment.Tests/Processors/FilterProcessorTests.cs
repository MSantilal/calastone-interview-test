using System;
using System.Collections.Generic;
using System.Text;
using Assessment.Filters;
using Assessment.Processors;
using NSubstitute;
using Xunit;

namespace Assessment.Tests.Processors
{
    public class FilterProcessorTests
    {
        [Fact]
        public void Ctor_validates_params()
        {
            Assert.Throws<ArgumentNullException>(() => new FilterProcessor(null));
            Assert.Throws<ArgumentOutOfRangeException>(() => new FilterProcessor(new List<IFilter>()));
        }

        [Fact]
        public void Process_validates_params()
        {
            var list = new List<IFilter>
            {
                Substitute.For<IFilter>(),
                Substitute.For<IFilter>(),
                Substitute.For<IFilter>(),
            };

            var sut = new FilterProcessor(list);

            Assert.Throws<ArgumentNullException>(() => sut.Process(null));
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Process(" "));
        }

        [Fact]
        public void Processes_less_than_three_words()
        {
            var sb = new StringBuilder();
            var lessThanThreeFilter = Substitute.For<IFilter>();
            var filters = new List<IFilter> { lessThanThreeFilter };
            var sut = new FilterProcessor(filters);
            var normalisedStrings = "hello what are you up to today";

            lessThanThreeFilter
                .Filter(Arg.Any<string>())
                .Returns(false, false, false, false, true, true, false);

            foreach (var str in normalisedStrings.Split(' '))
            {
                var processedItem = sut.Process(str);
                if (string.IsNullOrEmpty(processedItem))
                {
                    continue;
                }

                sb.AppendLine(processedItem);
            }

            var actual = sb.ToString();

            lessThanThreeFilter.Received(7).Filter(Arg.Any<string>());
            Assert.Equal("hello" + Environment.NewLine +
                         "what" + Environment.NewLine +
                         "are" + Environment.NewLine +
                         "you" + Environment.NewLine +
                         "today" + Environment.NewLine, actual);
        }

        [Fact]
        public void Processes_words_containing_t()
        {
            var sb = new StringBuilder();
            var charTFilter = Substitute.For<IFilter>();
            var filters = new List<IFilter> { charTFilter };
            var sut = new FilterProcessor(filters);
            var normalisedStrings = "hello what are you up to today";

            charTFilter
                .Filter(Arg.Any<string>())
                .Returns(false, false, false, false, false, true, true);

            foreach (var str in normalisedStrings.Split(' '))
            {
                var processedItem = sut.Process(str);
                if (string.IsNullOrEmpty(processedItem))
                {
                    continue;
                }

                sb.AppendLine(processedItem);
            }

            var actual = sb.ToString();

            charTFilter.Received(7).Filter(Arg.Any<string>());
            Assert.Equal("hello" + Environment.NewLine +
                         "what" + Environment.NewLine +
                         "are" + Environment.NewLine +
                         "you" + Environment.NewLine +
                         "up" + Environment.NewLine, actual);
        }

        [Fact]
        public void Processes_words_containing_vowel_in_the_middle()
        {
            var sb = new StringBuilder();
            var vowelFilter = Substitute.For<IFilter>();
            var filters = new List<IFilter> { vowelFilter };
            var sut = new FilterProcessor(filters);
            var normalisedStrings = "hello what are you up to today";

            vowelFilter
                .Filter(Arg.Any<string>())
                .Returns(false, true, false, true, true, true, false);

            foreach (var str in normalisedStrings.Split(' '))
            {
                var processedItem = sut.Process(str);
                if (string.IsNullOrEmpty(processedItem))
                {
                    continue;
                }

                sb.AppendLine(processedItem);
            }

            var actual = sb.ToString();

            vowelFilter.Received(7).Filter(Arg.Any<string>());
            Assert.Equal("hello" + Environment.NewLine +
                         "are" + Environment.NewLine +
                         "today" + Environment.NewLine, actual);
        }

        [Fact]
        public void Process_words_with_all_filters()
        {
            var sb = new StringBuilder();
            var charTFilter = Substitute.For<IFilter>();
            var lessThanThreeFilter = Substitute.For<IFilter>();
            var vowelInTheMiddleFilter = Substitute.For<IFilter>();

            var filters = new List<IFilter>
            {
                vowelInTheMiddleFilter,
                lessThanThreeFilter,
                charTFilter
            };

            var sut = new FilterProcessor(filters);
            var normalisedStrings = "hello what are you up to today";

            vowelInTheMiddleFilter
                .Filter(Arg.Any<string>())
                .Returns(false, true, false, true, true, true, false);

            lessThanThreeFilter
                .Filter(Arg.Any<string>())
                .Returns(false, false, false, false, true, true, false);

            charTFilter
                .Filter(Arg.Any<string>())
                .Returns(false, false, false, false, false, true, true);


            foreach (var str in normalisedStrings.Split(' '))
            {
                var processedItem = sut.Process(str);
                if (string.IsNullOrEmpty(processedItem))
                {
                    continue;
                }

                sb.AppendLine(processedItem);
            }

            var actual = sb.ToString();

            vowelInTheMiddleFilter.Received(7).Filter(Arg.Any<string>());
            lessThanThreeFilter.Received(4).Filter(Arg.Any<string>());
            charTFilter.Received(0).Filter(Arg.Any<string>());

            Assert.Equal("hello" + Environment.NewLine +
                         "what" + Environment.NewLine +
                         "are" + Environment.NewLine +
                         "you" + Environment.NewLine +
                         "up" + Environment.NewLine +
                         "to" + Environment.NewLine +
                         "today" + Environment.NewLine, actual);

        }
    }
}