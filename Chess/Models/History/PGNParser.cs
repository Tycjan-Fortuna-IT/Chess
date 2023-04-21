namespace Chess.Models
{
    public class PGNParser
    {
        private List<string> lines = new List<string>();

        /// <summary>
        ///     Parse from the PGN format to TXT. Removes all unnecessary information about the game
        ///     and compresses games into format one game = one line. Still the national chess notation
        ///     is preserved.
        /// </summary>
        /// <param name="ReadPath">Read PGN file to parse</param>
        /// <param name="WritePath">Output TXT file</param>
        public void ParseToTXT(string ReadPath, string WritePath)
        {
            using (StreamReader reader = new StreamReader(ReadPath))
            {
                string line;

                string concat = "";

                int braceCounter = 1;

                int counter = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("["))
                    {
                        braceCounter++;

                        if (braceCounter == 10)
                        {
                            reader.ReadLine();
                            braceCounter = 1;
                        }
                    }
                    else
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Length == 0) break;

                            concat += line;
                            concat += " ";
                        }

                        lines.Add(concat);

                        if (lines.Count > 2000)
                            this.Write(WritePath);

                        concat = "";
                    }
                }

                this.Write(WritePath);
            }
        }

        private void Write(string WritePath)
        {
            using (StreamWriter writer = new StreamWriter(WritePath, true))
            {
                foreach (var line in lines)
                {
                    writer.WriteLine(line);
                }

                writer.Flush();

                lines.Clear();
            }
        }
    }
}
