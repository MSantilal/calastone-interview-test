using System.IO;

namespace Assessment
{
    internal sealed class FilterProgram
    {
        public FilterProgram()
        {
            var text = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "assessment-text.txt"));

            var splitText = text.Split(' ');
        }
    }


}