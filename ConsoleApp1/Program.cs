using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            string dir = System.IO.Path.GetDirectoryName(
               System.Reflection.Assembly.GetExecutingAssembly().Location);
            ProductCounter productCounter = new ProductCounter(dir + @"\tags.txt", "1253252");

            System.Console.WriteLine("There is " + productCounter.Count() + " milka oreos");

            // reuse of ProductCounter class
            productCounter.DirPath = dir + @"\tags.txt";
            productCounter.ProductPrefix = "647520";

            System.Console.WriteLine("There is " + productCounter.Count() + " lemons");



            //first fast code before refactoring 


            //string line;
            //int counter = 0;

            //string dir = System.IO.Path.GetDirectoryName(
            //    System.Reflection.Assembly.GetExecutingAssembly().Location);
            //System.IO.StreamReader file =
            //    new System.IO.StreamReader(dir + @"\tags.txt");
            //while ((line = file.ReadLine()) != null)
            //{
            //    string strHex = String.Concat("[0-9A-Fa-f]{", line.Length, "}");
            //    bool RetBoolHex = Regex.IsMatch(line, strHex);
            //    if (RetBoolHex)
            //    {
            //        string binarystring = String.Join(String.Empty,
            //        line.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
            //        int partition = Convert.ToInt32(binarystring.Substring(11, 3), 2);
            //        int numBitsCompanyPrefix = 0;
            //        int numBitsItemReference = 0;
            //        switch (partition)
            //        {
            //            case 0:
            //                numBitsCompanyPrefix = 40;
            //                break;
            //            case 1:
            //                numBitsCompanyPrefix = 37;
            //                break;
            //            case 2:
            //                numBitsCompanyPrefix = 34;
            //                break;
            //            case 3:
            //                numBitsCompanyPrefix = 30;
            //                break;
            //            case 4:
            //                numBitsCompanyPrefix = 27;
            //                break;
            //            case 5:
            //                numBitsCompanyPrefix = 24;
            //                break;
            //            case 6:
            //                numBitsCompanyPrefix = 20;
            //                break;
            //            default:
            //                Console.WriteLine("Default case");
            //                break;
            //        }

            //        numBitsItemReference = 44 - numBitsCompanyPrefix;

            //        string itemReferenceBinary = binarystring.Substring(14 + numBitsCompanyPrefix, numBitsItemReference);

            //        string itemReference =  Convert.ToInt32(itemReferenceBinary, 2).ToString();

            //        if (itemReference == "1253252") {
            //            System.Console.WriteLine(line + "..." + "Serial Number::" + Convert.ToInt32(binarystring.Substring(binarystring.Length - 38), 2).ToString());
            //            counter++;
            //        }


            //    }
            //    else {
            //        System.Console.WriteLine(line + " IS INVALID HEXADECIMAL STRING");
            //        continue;
            //    }



            //}

        }
    }
}
