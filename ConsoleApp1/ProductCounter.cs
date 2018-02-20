using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class ProductCounter
    {
      
        private string dirPath;

        private string productPrefix;

        private string binaryString;

        public ProductCounter(string path,string prefix) {

            dirPath = path;
            productPrefix = prefix;
        }

        public string DirPath
        {
            get => dirPath;
            set => dirPath = value;
        }

        public string ProductPrefix
        {
            get => productPrefix;
            set => productPrefix = value;
        }

        public bool checkIfHex(string hex) {

            string strHex = String.Concat("[0-9A-Fa-f]{", hex.Length, "}");
            return  Regex.IsMatch(hex, strHex);
        }
        public int partitionNumber(string binary) {

            return Convert.ToInt32(binary.Substring(11, 3), 2);
        }
        public string hexToBinary(string hex) {

            return String.Join(String.Empty,
                    hex.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

        }
        public string calculateItemReference(string line) {

            binaryString = hexToBinary(line);
            int partition = partitionNumber(binaryString);

            int numBitsCompanyPrefix = 0;
            int numBitsItemReference = 0;
            switch (partition)
            {
                case 0:
                    numBitsCompanyPrefix = 40;
                    break;
                case 1:
                    numBitsCompanyPrefix = 37;
                    break;
                case 2:
                    numBitsCompanyPrefix = 34;
                    break;
                case 3:
                    numBitsCompanyPrefix = 30;
                    break;
                case 4:
                    numBitsCompanyPrefix = 27;
                    break;
                case 5:
                    numBitsCompanyPrefix = 24;
                    break;
                case 6:
                    numBitsCompanyPrefix = 20;
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            numBitsItemReference = 44 - numBitsCompanyPrefix;

            string itemReferenceBinary = binaryString.Substring(14 + numBitsCompanyPrefix, numBitsItemReference);

            return Convert.ToInt32(itemReferenceBinary, 2).ToString(); 

        }
        public int Count() {

            int counter = 0;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(dirPath);

            while ((line = file.ReadLine()) != null)
            {
                
                if (checkIfHex(line))
                {

                    string itemReference = calculateItemReference(line);

                    if (itemReference == productPrefix)
                    {
                        System.Console.WriteLine(line + "..." + "Serial Number::" + Convert.ToInt32(binaryString.Substring(binaryString.Length - 38), 2).ToString());
                        counter++;
                    }


                }
                else
                {
                    System.Console.WriteLine(line + " IS INVALID HEXADECIMAL STRING");
                    continue;
                }


                
            }
            file.Close();
            return counter;
        }
    }
}
