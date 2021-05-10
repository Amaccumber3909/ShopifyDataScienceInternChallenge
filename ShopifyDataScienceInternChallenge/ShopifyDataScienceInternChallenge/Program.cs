/*
 * FILE             :   Program.cs
 * PROJECT          :   Shopify Data Science Intern Challenge
 * PROGRAMMER       :   Alex MacCumber
 * FIRST VERSION    :   April 9th 2021
 * DESCRIPTION      :   Console application to show AOV based on Dataset provided for the
 *                      challenge at: https://docs.google.com/spreadsheets/d/16i38oonuX1y1g7C_UAmiK9GkY7cS-64DfiDMNiR41LM/edit#gid=0
 *                      and downloaded as a CSV file.
 *                      
 *                      This solution works based on the idea that we are able to view the data and see that there are extreme outliers
 *                      within the dataset that are causing the AOV to be heavily skewed. To adapt to that, we are ignoring orders with
 *                      an item amount of 10 or more as we can see orders go up to 8 items and then the outliers have 2000 items
 *                      
 * Assumptions      :   This program has been developed under the assumption that we know the structure of the data
 *                      This lets us access only the needed values and ignore the unneeded ones for the purpose of calculating
 *                      the AOV
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopifyDataScienceInternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {

            char delimiter = ',';

            // variables to hold the data
            List<string[]> dataFields = null;


            float aovWithOutliers = 0;
            float aovWithoutOutliers = 0;

            // Get the data from the file and process it to calculate the AOVs
            string[] data = null;
            string currentRow = null;
            int i = 0;
            using (StreamReader reader = new StreamReader(args[0]))
            {
                // Get the data from the csv file passed in the console arguments
                while ((currentRow = reader.ReadLine()) != null)
                {
                    Console.WriteLine(currentRow);
                    data = currentRow.Split(delimiter);
                    i++;
                }
            }

            // Now calculate the AOVs

            // aovWithOutliers = AverageWithOutliers(dataFields);
            // aovWithoutOutliers = AverageNoOutliers(dataFields);



        }


        static private float AverageNoOutliers(string[] data)
        {
            float avg = 0;




            return avg;
        }


        static private float AverageWithOutliers(string[] data)
        {
            float avg = 0;




            return avg;
        }
    }
}
