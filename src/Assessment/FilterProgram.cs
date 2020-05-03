using System;
using System.Collections.Generic;
using System.Text;
using Assessment.Filters;
using Assessment.Processors;

namespace Assessment
{
    internal sealed class FilterProgram
    {
        public FilterProgram()
        {
            var sb = new StringBuilder();
           
            var wordsFromText = FileProcessor.GetText("assessment-text.txt");

            var filterProcessor = new FilterProcessor(new List<IFilter>
            {
                new VowelInMiddleOfWordFilter(),
                new LessThanThreeFilter(),
                new CharTFilter()
            });

            foreach (var str in wordsFromText)
            {
                var processedItem = filterProcessor.Process(str);
                if (string.IsNullOrEmpty(processedItem))
                {
                    continue;
                }

                sb.AppendLine(processedItem);
            }

            Console.WriteLine(sb.ToString());
        }

       
    }


}