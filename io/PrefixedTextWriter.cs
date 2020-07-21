using System;
using System.IO;
using System.Text;

namespace social_network_kata_sharp.io
{
    class PrefixedTextWriter : TextWriter
    {

        #region fields

        private TextWriter originalOut;

        #endregion fields

        #region properties

        protected TextWriter OriginalOut { get => originalOut; set => originalOut = value; }

        public override Encoding Encoding { get { return new System.Text.ASCIIEncoding(); } }

        #endregion properties

        #region constructors

        public PrefixedTextWriter() => OriginalOut = Console.Out;

        #endregion constructors

        #region methods

        protected const string PREFIX = "> ";

        public override void WriteLine(string message) => OriginalOut.WriteLine($"{PREFIX}{message}");

        public override void Write(string message) => OriginalOut.Write($"{PREFIX}{message}");

        #endregion methods

    }
}