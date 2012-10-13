using System;
using System.IO;
using System.Collections.Generic;
namespace CSVParser
{
    public class Processor
    {
        private const int size = 441;
        public static string [] ProcessFileData(List<string[]> CDRs)
        {
            string [] output = new string [size];
            int index = 0;
            string cliNumber = CDRs[1][0].ToString();
            int noOfCallsByCaller = 0;
            double callsChargesByCaller = 0;
            double totalCallsCharges = 0;
            int totalNoOfCalls = 0;

            try
            {
                for (int i = 1; i < CDRs.Count; i++)
                {
                    totalNoOfCalls++;
                    string[] CDR = CDRs[i];
                    if (cliNumber == Convert.ToString(CDR[0]))
                    {
                        callsChargesByCaller += Convert.ToDouble(CDR[5]) * Convert.ToDouble(CDR[6]);
                        noOfCallsByCaller++;
                    }
                    else
                    {
                        output[index++] = "Total amount of call charges for " + cliNumber + " are :" + Convert.ToString(callsChargesByCaller);
                        cliNumber = CDRs[i][0].ToString();
                        noOfCallsByCaller = 1;
                        callsChargesByCaller = 0;
                        callsChargesByCaller += Convert.ToDouble(CDR[5]) * Convert.ToDouble(CDR[6]);
                    }
                    totalCallsCharges += callsChargesByCaller;
                }
                output[index++] = "Total No of Calls:" + Convert.ToString(totalNoOfCalls);
                output[index++] = "Grand total of call charges in entire CDR file:" + Convert.ToString(totalCallsCharges);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            return output;
        }
    }
}
