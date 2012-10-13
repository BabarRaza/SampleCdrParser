using System.Collections.Generic;
using System.IO;
using System;

namespace CSVParser
{
   public class Parser
    {
        public static List<string[]> parseCSV(string path)
        {
            List<string[]> CDRs = new List<string[]>();

            try
            {
                StreamReader readFile = new StreamReader(path);
                string line;
                string[] row;
                while ((line = readFile.ReadLine()) != null)
                {
                    row = line.Split(',');
                    CDRs.Add(row);
                }
            }

            catch (IOException  io) 
            {
               
                io.StackTrace.ToString();
            }
            
            return CDRs;
        }
    }
}
