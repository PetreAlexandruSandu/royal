#region Used Namespaces
using RoyalLondonTestApplication.DataAccess.Interfaces;
using RoyalLondonTestApplication.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
#endregion

namespace RoyalLondonTestApplication.DataAccess.Components
{
    public class PoliciesData : IPoliciesData
    {
        #region Private methods
        /// <summary>
        /// Read insurance policies from CSV input file
        /// </summary>
        /// <returns>List of Policy details</returns>
        private static List<Policy> ReadPoliciesFromCsv()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GetCsvPath());

            if (File.Exists(path))
            {
                List<Policy> polices = File.ReadAllLines(path)
                                           .Skip(1)
                                           .Select(v => GetPolicyFromCsvLine(v))
                                           .ToList();

                return polices;
            }
            else
            {
                return new List<Policy>();
            }
        }

        /// <summary>
        /// Get CSV input file path
        /// </summary>
        /// <returns>Path of the CSV file</returns>
        private static string GetCsvPath()
        {
            return ConfigurationManager.AppSettings["CsvFilePath"];
        }

        /// <summary>
        /// Get result file path
        /// </summary>
        /// <returns>Result file path</returns>
        private static string GetResultFilePath()
        {
            return ConfigurationManager.AppSettings["ResultFilePath"];
        }

        /// <summary>
        /// Parse CSV line and convert to Policy object
        /// </summary>
        /// <param name="csvLine">Policy details in CSV format</param>
        /// <returns>Policy details</returns>
        private static Policy GetPolicyFromCsvLine(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Policy policy = new Policy();
            policy.Number = Convert.ToString(values[0]);
            policy.Date = DateTime.ParseExact(values[1], "dd/MM/yyyy", null);
            policy.Premiums = Convert.ToInt64(values[2]);
            policy.Membership = Convert.ToString(values[3]) == "Y";
            policy.DiscretionaryBonus = Convert.ToInt64(values[4]);
            policy.UpliftPercentage = Convert.ToDecimal(values[5]);

            return policy;
        }
        #endregion

        /// <summary>
        /// Get all insurance policies 
        /// </summary>
        /// <returns>List of Policy details</returns>
        public List<Policy> GetPolicies()
        {
            return ReadPoliciesFromCsv().ToList();
        }

        /// <summary>
        /// Create XML result file with the policies maturity values
        /// </summary>
        public void CreateXmlFile(List<Maturity> model)
        {
            try
            {
                XmlSerializer serialiser = new XmlSerializer(typeof(List<Maturity>));

                string resultFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GetResultFilePath());

                TextWriter writer = new StreamWriter(resultFilePath);
                serialiser.Serialize(writer, model);
                writer.Close();
            }
            catch (Exception ex)
            {
                //here we can log the exception
                throw;
            }
        }
    }
}
