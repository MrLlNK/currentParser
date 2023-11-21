using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace currentParserServer
{
    class Constant
    {
        public NumberFormatInfo numberFormatInfo = new NumberFormatInfo { NumberGroupSeparator = " ", NumberDecimalSeparator = "," };
        public string[] stringPotencyList = { " million", " thousand", " dollars" };
        public string[] stringTens = { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eigty", "ninty" };
        public string[] stringOnes = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "therteen", "fourteen", "fiveteen", "sixteen", "seventeen", "eigthteen", "nineteen" };
        public int[] potencyList = { 1_000_000, 1_000, 1 };
    }


    class CurrentParser
    {
        Constant CONSTANT = new Constant();

        static bool isOutOfRange(decimal value)
        {
            if (value < 0)
            {
                return true;
            }
            if (value > 999999999.99m)
            {
                return true;
            }
            {
                return false;
            }
        }

        public bool falseSyntax(string value)
        {
            try
            {
                Convert.ToDecimal(value, CONSTANT.numberFormatInfo);
            }
            catch { return true; }
            
            if (!Regex.IsMatch(value, @"^\s*(\d{1,3}(?:\s*\d{3})*)(?:,(\d{1,2}))?$"))
            {
                return true;
            }
            return false;
        }
        

        public decimal string2Decimal(String value)
        {
            return Convert.ToDecimal(value, CONSTANT.numberFormatInfo);
        }

        public string calcStringValueFromValue(string value)
        {
            
            if (falseSyntax(value)){
                return "SyntaxError: Value has a false syntax!";
            }

            decimal decimalValue = string2Decimal(value);
                
            if (isOutOfRange(decimalValue))
            {
                return "Error: Out of Range!";
            }

            if (decimalValue < 0.99m && decimalValue >= 0.00m)
            {
                return "zero dollars" + decimalValue2Cent(decimalValue);
            }

            if (decimalValue < 1.99m && decimalValue >= 1.00m)
            {
                return "one dollar" + decimalValue2Cent(decimalValue);
            }
            return decimalValue2Text(decimalValue);
        }


        public string decimalValue2Dollar(decimal value)
        {
            string valueString = "";

            int i = 0;
            foreach (int potency in CONSTANT.potencyList)
            {
                int factoredValue = (int)value / potency;
                
                if (factoredValue > 0)
                {
                int numberHundrets = (int)factoredValue / 100;
                if (numberHundrets > 0)
                {
                    valueString += CONSTANT.stringOnes[numberHundrets - 1] + "hundred";
                    value -= 100 * numberHundrets * potency;
                    factoredValue -= 100 * numberHundrets;
                    if (factoredValue > 0) { valueString += " "; }
                }
                   
                if (factoredValue >= 19)
                {
                    int numberTens = (int)factoredValue / 10;
                    if (numberTens > 0)
                    {
                        valueString += CONSTANT.stringTens[numberTens - 1];
                        value -= 10 * numberTens * potency;
                        factoredValue -= 10 * numberTens;
                        if (factoredValue > 0)
                        {
                            valueString += "-";
                        }
                    }
                }

                int numberOnes = (int)factoredValue;
                if (numberOnes > 0)
                {
                    valueString += CONSTANT.stringOnes[numberOnes - 1];
                    value -= numberOnes * potency;
                    factoredValue -= numberOnes;
                }

                valueString += CONSTANT.stringPotencyList[i] + " ";
                }
                i++;
            }
            return valueString;
        }

        public string decimalValue2Cent(decimal value) {
            string valueString = "";

            int centValue = (int)(value%1 * 100);

            if (centValue > 0)
            {
                valueString = valueString + "and ";

                if (centValue >= 19)
                {
                    int numberTens = (int)centValue / 10;
                    if (numberTens > 0)
                    {
                        valueString += CONSTANT.stringTens[numberTens - 1];
                        centValue -= 10 * numberTens;
                        if (centValue > 0)
                        {
                            valueString += "-";
                        }
                    }
                }

                int numberOnes = (int)centValue;
                if (numberOnes > 0)
                {
                    valueString += CONSTANT.stringOnes[numberOnes - 1];
                }
                valueString += " cent";
            }
            return valueString;

        }
        public string decimalValue2Text(decimal value)
        {
            string dollar = decimalValue2Dollar(value);

            string cent = decimalValue2Cent(value);
            
            return dollar + cent;

        }

       
    }
}
