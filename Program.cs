using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace CSVParser
{
    class Program
    {
        public static void Main(string[] args) 
        {
            try
            {
                DateTime stTime = DateTime.Now;
                List<string[]> fileData = Parser.parseCSV(@"E:\temp\sample-cdr.csv");
                string [] output = Processor.ProcessFileData(fileData);
                DateTime etTime = DateTime.Now;
                TimeSpan elapsed = etTime-stTime;
                output[output.Length - 1] = "Elapsed Time : " + elapsed.ToString();
                File.WriteAllLines(@"E:\temp\cdr_summary.txt", output);
            }
            catch (Exception ex) 
            {
                ex.StackTrace.ToString();
            }
    
        }
       
       
    }
}
