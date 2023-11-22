using System.Globalization;
using System.Text.RegularExpressions;

namespace currentParserServer
{
    class Constant
    {
        public NumberFormatInfo numberFormatInfo = new NumberFormatInfo { NumberGroupSeparator = " ", NumberDecimalSeparator = "," };
        public string[] stringPotencyList = { "million", "thousand", "" };
        public string[] stringTens = ["ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eigty", "ninty"];
        public string[] stringOnes = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "therteen", "fourteen", "fiveteen", "sixteen", "seventeen", "eigthteen", "nineteen"];
        public int[] potencyList = [1_000_000, 1_000, 1];
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

        static string ConcatenateStrings(string stringStart, string stringEnd, string seperator)
        {
            stringStart = stringStart.TrimEnd();
            stringStart = stringStart.TrimStart();
            stringEnd = stringEnd.TrimStart();
            stringEnd = stringEnd.TrimEnd();
            return stringStart + seperator + stringEnd;
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

        public string getSpezialCase(decimal value)
        {
            if (value < 0.99m && value >= 0.00m)
            {
                string dollar = "zero dollars";
                string cent = convertCent2Text(value);
                return ConcatenateStrings(dollar, cent, (cent == "") ? "" : " and ");
            }

            if (value <1.99m && value >= 1.00m)
            {
                string dollar = "one dollar";
                string cent = convertCent2Text(value);
                return ConcatenateStrings(dollar, cent, (cent == "") ? "" : " and ");
            }
            return "";
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

            string spezialValue = getSpezialCase(decimalValue);
            if (spezialValue != "")
            {
                return spezialValue;
            }

            return convertCurrent2Text(decimalValue);
        }


        public string convertDollar2Text(decimal value)
        {          
            string valueString = "";

            int i = 0;
            foreach (int potency in CONSTANT.potencyList)
            {
                int factoredValue = (int)value / potency;
                value -= factoredValue* potency;
                if (factoredValue > 0)
                {
                    int numberHundrets = (int)factoredValue / 100;
                    if (numberHundrets > 0)
                    {
                        factoredValue -= 100 * numberHundrets;
                        string convertedHundret = ConcatenateStrings(CONSTANT.stringOnes[numberHundrets - 1], "hundred", "");
                        valueString = ConcatenateStrings(valueString, convertedHundret, " ");
                    }
                    string tens = ConvertTensInText(factoredValue);
                    
                    valueString = ConcatenateStrings(valueString, tens, (tens =="")?"":" " );
                   
                    valueString = ConcatenateStrings(valueString, CONSTANT.stringPotencyList[i], " ");
                    
                }
                i++;
            }
            valueString = ConcatenateStrings(valueString, "dollars", " ");
            return valueString;
        }

        public string convertCent2Text(decimal value) {
            int centValue = (int)(value%1 * 100);

            if (centValue == 0)
            {
                return "";
            }

            if (centValue == 1)
            {
                return "one cent";
            }

            return ConcatenateStrings(ConvertTensInText(centValue), "cents", " ");

        }

        public string convertCurrent2Text(decimal value)
        {
            string dollar = convertDollar2Text(value);

            string cent = convertCent2Text(value);

            return ConcatenateStrings(dollar, cent, (dollar == "" || cent == "") ? "" : " and ");

        }

        public string ConvertTensInText(decimal value)
        {
            int numberTens = 0;
            string convertedTens = "";

            if (value >= 19)
            {
                numberTens = (int)value / 10;
                if (numberTens > 0)
                {
                    value -= 10 * numberTens;
                    convertedTens = ConcatenateStrings(convertedTens, CONSTANT.stringTens[numberTens - 1], " ");
                }
            }

            int numberOnes = (int)value;
            if (numberOnes > 0)
            {
                convertedTens = ConcatenateStrings(convertedTens, CONSTANT.stringOnes[numberOnes - 1], (numberTens == 0) ? "" : "-");
            }
            return convertedTens;
        }
    }
}
