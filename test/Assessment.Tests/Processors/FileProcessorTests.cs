using System;
using Assessment.Processors;
using Xunit;

namespace Assessment.Tests.Processors
{
    public class FileProcessorTests
    {
        [Fact]
        public void Filter_validates_params()
        {
            Assert.Throws<ArgumentNullException>(() => FileProcessor.GetText(null));
            Assert.Throws<ArgumentOutOfRangeException>(() => FileProcessor.GetText(" "));
        }

    }
}