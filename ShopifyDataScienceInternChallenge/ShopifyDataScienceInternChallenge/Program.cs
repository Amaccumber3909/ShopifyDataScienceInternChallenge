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
            int firstDataRow = 1;
            int indexOrderAmount = 3;
            int indexTotalItems = 4;
            int totalItemsOutlierAmount = 10;

            // Variables to hold the two sum values
            float orderAmountWithOutliers = 0;
            float orderAmountNoOutliers = 0;

            // Used to calculate the average after getting the sums
            int totalItemsWithOutliers = 0;
            int totalItemsNoOutliers = 0;

            int totalOrders = 0;
            int totalOrdersNoOutliers = 0;

            float averageItemValue = 0;

            // Contains the averages
            float aovWithOutliers = 0;
            float aovNoOutliers = 0;

            float averageItemsPerOrderWithOutliers = 0;
            float averageItemsPerOrderNoOutliers = 0;

            // Get the data from the file and process it to calculate the AOVs
            string[] data = null;
            string currentRow = null;
            int i = 0;
            using (StreamReader reader = new StreamReader(args[0]))
            {
                // Get the data from the csv file passed in the console arguments
                while ((currentRow = reader.ReadLine()) != null)
                {
                    data = currentRow.Split(delimiter);
                    i++;

                    // Now we will add the values to the various variables
                    
                    // Check to see if we are past the header row
                    if (i >  firstDataRow)
                    {
                        // Check to see if the total_items is larger than the outlier cap
                        if (int.Parse(data[indexTotalItems]) < totalItemsOutlierAmount)
                        {
                            // total_items amount is not considered an outlier order
                            totalItemsNoOutliers += int.Parse(data[indexTotalItems]);
                            orderAmountNoOutliers += int.Parse(data[indexOrderAmount]);
                            totalOrdersNoOutliers++;
                        }

                        // Add the values for the outlier calculations
                        totalItemsWithOutliers += int.Parse(data[indexTotalItems]);
                        orderAmountWithOutliers += int.Parse(data[indexOrderAmount]);
                        totalOrders++;
                    }
                }
            }

            // Now calculate the AOVs

            aovWithOutliers = CalculateAverage(orderAmountWithOutliers, totalOrders);
            averageItemsPerOrderWithOutliers = CalculateAverage(totalItemsWithOutliers, totalOrders);
            averageItemValue = CalculateAverage(aovWithOutliers, averageItemsPerOrderWithOutliers);

            Console.WriteLine("AOV with Outlier Data");
            Console.WriteLine("AOV: $" + aovWithOutliers.ToString("0.00"));
            Console.WriteLine("Avg Items per Order: $" + averageItemsPerOrderWithOutliers.ToString("0.00"));
            Console.WriteLine("Avg Item Value: $" + averageItemValue.ToString("0.00"));

            Console.WriteLine();

            // Calculate the values
            aovNoOutliers = CalculateAverage(orderAmountNoOutliers, totalOrdersNoOutliers);
            averageItemsPerOrderNoOutliers = CalculateAverage(totalItemsNoOutliers, totalOrdersNoOutliers);
            averageItemValue = CalculateAverage(aovNoOutliers, averageItemsPerOrderNoOutliers);

            // Display them to the console
            Console.WriteLine("AOV without Outlier Data (Orders with 10 Items or Less)");
            Console.WriteLine("AOV: $" + aovNoOutliers.ToString("0.00"));;
            Console.WriteLine("Avg Items per Order: $" + averageItemsPerOrderNoOutliers.ToString("0.00"));
            Console.WriteLine("Avg Item Value: $" + averageItemValue.ToString("0.00"));


            // Prompt user to press enter to exit
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press Enter To Exit");
            Console.ReadLine();

        }


        // Calculate the average given the sum of the order_amounts and the sum of the total_items data fields
        static private float CalculateAverage(float dividend, float divisor)
        {
            float avg = 0;

            avg = dividend / divisor;

            return avg;
        }
    }
}
