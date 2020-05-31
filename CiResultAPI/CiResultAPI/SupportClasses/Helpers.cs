using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CiResultAPI.SupportClasses
{
    public class Helpers
    {
        public static List<FileInfo> GetAllFile(string path, string extension, DateTime date)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            List<FileInfo> trxs;
            try
            {
                //trxs = directory.EnumerateDirectories()
                //        .AsParallel()
                //        .SelectMany(di => di.EnumerateFiles(extension, SearchOption.AllDirectories))
                //        //.Where(fi => fi.CreationTime.Date.CompareTo(date) == 0)
                //        .ToList();
                trxs = directory.GetFiles(extension, SearchOption.AllDirectories)
                       .Where(fi => fi.CreationTime.Date.CompareTo(date.Date) == 0)
                       .ToList();

            }
            catch
            {
                throw new Exception("Problem with getting TRX files");
            }
            return trxs;
        }

        //public static byte[] ImageToByteArray(Image imageIn)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

        //        return ms.ToArray();
        //    }
        //}

        public static string ParseTrxData(string trxName, ParseOption option)
        {
            trxName = Path.GetFileNameWithoutExtension(trxName);
            string result = string.Empty;

            if (option == ParseOption.Version)
            {
                Regex pattern = new Regex(@"B[0-9]\.\d\.\d+");
                result = pattern.Match(trxName).Value;
            }
            else if (option == ParseOption.TestResult)
            {
                Regex pattern = new Regex(@"\d+-\d+-\d+-\d+$");
                result = pattern.Match(trxName).Value;
            }
            else if (option == ParseOption.NameOfTest)
            {
                Regex pattern = new Regex(@"^([^\""]*)_[Desktop, Mobile]");
                string matche = pattern.Match(trxName).Value;
                //Kastbil, real shit
                result = matche.Substring(0, matche.Length - 2);
            }
            else if (option == ParseOption.Browser)
            {
                List<string> BrowserTypes = ConfigurationManager.AppSettings["SupportedBrowsers"]
                                                    .Split(',', ' ')
                                                    .Where(x => !string.IsNullOrWhiteSpace(x))
                                                    .ToList();
                foreach (var browser in BrowserTypes)
                {
                    if (trxName.Contains("_" + browser + "_"))
                    {
                        result = browser;
                        break;
                    }
                }
            }
            else if (option == ParseOption.Theme)
            {
                List<string> Themes = ConfigurationManager.AppSettings["SupportedThemes"]
                                                    .Split(',', ' ')
                                                    .Where(x => !string.IsNullOrWhiteSpace(x))
                                                    .ToList();

                foreach (var theme in Themes)
                {
                    if (trxName.Contains("_" + theme + "_"))
                    {
                        result = theme;
                        break;
                    }
                }
            }
            else if (option == ParseOption.DataBase)
            {
                List<string> DataBases = ConfigurationManager.AppSettings["SupportedDataBases"]
                                                    .Split(',', ' ')
                                                    .Where(x => !string.IsNullOrWhiteSpace(x))
                                                    .ToList();

                foreach (var database in DataBases)
                {
                    if (trxName.Contains("_" + database + "_"))
                    {
                        result = database;
                        break;
                    }
                }
            }

            return result;
        }
    }

    public enum ParseOption
    {
        TestResult,
        Product,
        Version,
        NameOfTest,
        Browser,
        Theme,
        DataBase
    }
}
