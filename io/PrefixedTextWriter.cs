using System;
using System.IO;
using System.Text;

namespace social_network_kata_sharp.io
{
    class PrefixedTextWriter : TextWriter
    {

        protected const string PREFIX = "> ";
        private TextWriter originalOut;

        protected TextWriter OriginalOut { get => originalOut; set => originalOut = value; }

        public PrefixedTextWriter() => OriginalOut = Console.Out;

        public override Encoding Encoding { get { return new System.Text.ASCIIEncoding(); } }

        public override void WriteLine(string message) => OriginalOut.WriteLine($"{PREFIX}{message}");

        public override void Write(string message) => OriginalOut.Write($"{PREFIX}{message}");

    }
}