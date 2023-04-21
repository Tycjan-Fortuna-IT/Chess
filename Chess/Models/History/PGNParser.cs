using System.ComponentModel;
using System.Dynamic;

namespace Chess.Models
{
    public class PGNParser
    {
        private List<string> lines = new List<string>();

        public void Parse(string ReadPath, string WritePath)
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
