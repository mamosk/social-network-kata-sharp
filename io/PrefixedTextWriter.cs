using System;
using System.IO;
using System.Text;

namespace SocialNetwork.IO
{
    class PrefixedTextWriter : TextWriter
    {

        protected const string PREFIX = "> ";

        protected TextWriter OriginalOut { get; set; }

        public override Encoding Encoding => new ASCIIEncoding();

        public PrefixedTextWriter() => OriginalOut = Console.Out;

        public override void WriteLine(string message) => OriginalOut.WriteLine($"{PREFIX}{message}");

        public override void Write(string message) => OriginalOut.Write($"{PREFIX}{message}");

    }
}