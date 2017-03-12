using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_IbanAndReferenceNumber.Models
{
    public class Iban
    {
    public string IbanNumber { get; set; }
        private string[] letters = new string[] {"A","B","C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P","Q","R","S","T","U","V","W","X","Y","Z"};
        private int[] numbers = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35 };

        public string CheckIbanValidation(string ibanNumber)
        {            
            ulong divider = 97;
            ulong reminder = 0;
            string fourCharsToEnd = ibanNumber.Substring(0, 4);
            ibanNumber = ibanNumber.Remove(0, 4);
            ibanNumber = ibanNumber.Insert(ibanNumber.Count(), fourCharsToEnd);
            int index = ibanNumber.IndexOf("F");
            string letterConverted = Letters(ibanNumber.Substring(index,2));
            ibanNumber = ibanNumber.Replace("FI", letterConverted);
            ulong number = ulong.Parse(ibanNumber);
            reminder = (number) % divider;           

            if(reminder == 1)
            {
                return "Iban is correct!";
            }
            else
            {
                return "Iban is incorrect!";
            }
        }
        private string Letters(string s)
        {
            string lettersToNum = "";
            for (int i = 0; i < letters.Length; i++)
            {
                if (s.Contains(letters[i]))
                {
                    lettersToNum = s.Replace(letters[i], numbers[i].ToString());
                    s = lettersToNum;
                }
            }
            return lettersToNum;
        }

        


    }
}
