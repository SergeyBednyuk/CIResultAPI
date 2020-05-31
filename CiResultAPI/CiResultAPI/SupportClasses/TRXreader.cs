using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace CiResultAPI.SupportClasses
{
    public class TRXreader
    {
        public static string GetErrorDataFromTrx(string trxName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(trxName);
            XmlNodeList errorsNodes = xDoc.GetElementsByTagName("ErrorInfo");

            return errorsNodes[0].FirstChild.InnerText;
        }

        public static List<string> ExtractFailedTestNumbers(string trxName)
        {
            List<string> ListOfFailedScenarios = new List<string>();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(trxName);

            XmlNodeList errorsNodes = xDoc.GetElementsByTagName("ErrorInfo");

            foreach (XmlNode node in errorsNodes)
            {
                string notFormattedfailedScenarioName = node.ParentNode.ParentNode.Attributes["testName"].Value;

                List<string> numbers = Regex.Split(notFormattedfailedScenarioName, @"\D+").Where(v => !string.IsNullOrEmpty(v)).ToList();

                try
                {
                    string nameFailedTestNumber = string.Empty;
                    if (numbers.Count == 3)
                    {
                        nameFailedTestNumber = string.Format("{0}.{1}_{2}", numbers[0], numbers[1], numbers[2]);
                    }
                    else if (numbers.Count >= 4)
                    {
                        nameFailedTestNumber = string.Format("{0}.{1}_{2}_{3}", numbers[0], numbers[1], numbers[2], numbers[3]);
                    }
                    else
                    {
                        nameFailedTestNumber = string.Format("");
                    }
                    ListOfFailedScenarios.Add(nameFailedTestNumber);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return ListOfFailedScenarios;
        }

        public static List<int> GetResultOfTest(string trxName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(trxName);
            XmlNode resultsNode = xDoc.GetElementsByTagName("Counters")[0];
            List<int> results = new List<int>();

            if (resultsNode != null)
            {
                int total = Convert.ToInt32(resultsNode.Attributes["total"].Value);
                int passed = Convert.ToInt32(resultsNode.Attributes["passed"].Value);
                int failed = Convert.ToInt32(resultsNode.Attributes["failed"].Value);
                int skipped = Convert.ToInt32(resultsNode.Attributes["total"].Value)
                                   - Convert.ToInt32(resultsNode.Attributes["executed"].Value);

                results.AddRange(new List<int>() { total, passed, failed, skipped });
            }

            return results;
        }
    }
}
