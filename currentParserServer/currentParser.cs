using System.Globalization;
using System.Text.RegularExpressions;

namespace currentParserServer
{
    class Constant
    {   
        public string[] stringPotencyList = { "million", "thousand", "" };
        private string[] stringHundrets = { "onehundred", "twohundred", "threehundred", "fourhundred", "fivehundred", "sixhundred", "sevenhundred", "eighthundred", "ninehundred" };
        private string[] stringTens = { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eigty", "ninty" };
        private string[] stringOnes = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "therteen", "fourteen", "fiveteen", "sixteen", "seventeen", "eigthteen", "nineteen" };
        public List<string[]> stringFactorCurrents = new List<string[]>();
        public int[] potencyList = { 1_000_000, 1_000, 1 };
        public int[] factorCurrents = { 100, 10, 1 };

        public Constant()
        {
            stringFactorCurrents.Add(stringHundrets);
            stringFactorCurrents.Add(stringTens);
            stringFactorCurrents.Add(stringOnes);
        }

    }


    class CurrentParser
    {
        Constant CONSTANT = new Constant();

        static bool falseSyntax(string value)
        {
            // is a letter inside
            if (!decimal.TryParse(value, out _))
            {
                return true;
            }
            // check two digits after decimal separator and german syntax 
            if (!Regex.IsMatch(value, @"^[0-9.]{0,9}\,[0-9]{2}$"))
            {
                return true;
            }
            return false;
        }
        

        static decimal string2Decimal(String value)
        {
            return Convert.ToDecimal(value, new CultureInfo("de-DE"));
        }

        public string calcStringValueFromValue(string value)
        {
            
            if (falseSyntax(value)){
                return "Value have a false syntax. The Inputvalue can only be number. Seperator must be a comma.";
            }

            decimal decimalValue = string2Decimal(value);
  
            if (decimalValue.Equals(0.00m))
            {
                return "zero dollars";
            }
            if (decimalValue.Equals(1.00m))
            {
                return "one dollar";
            }
            return decimalValue2Text(decimalValue);
        }

        public string decimalValue2Text(decimal value)
        {
            string valueString = "";

            int i = 0;
            foreach (int potency in CONSTANT.potencyList)
            {
                int factoredValue = (int)value / potency;

                if (factoredValue > 0)
                {
                    int j = 0;
                    foreach (int factorCurrent in CONSTANT.factorCurrents)
                    {

                        int factoredCurrent = (int)factoredValue / factorCurrent;
                        if (factorCurrent == 10 && factoredValue <= 19)
                        {
                            j++;
                            continue;
                        }
                        if (factoredCurrent > 0)
                        {
                            valueString += CONSTANT.stringFactorCurrents[j][factoredCurrent - 1];
                            value -= factoredCurrent * factorCurrent * potency;
                            factoredValue -= factoredCurrent * factorCurrent;
                            if (factoredValue == 0)
                            {
                                break;
                            }
                            valueString += "-";
                        }

                        j++;
                    }
                    valueString += CONSTANT.stringPotencyList[i] + " ";
                }
                i++;
            }
            valueString = valueString + "dollars";

            int centValue = (int)(value * 100);

            if (centValue > 0)
            {
                valueString = valueString + " and ";
                int j = 0;
                foreach (int factorCurrent in CONSTANT.factorCurrents)
                {

                    int factoredCurrent = (int)centValue / factorCurrent;
                    if (factorCurrent == 10 && centValue <= 19)
                    {
                        j++;
                        continue;
                    }
                    if (factoredCurrent > 0)
                    {
                        valueString += CONSTANT.stringFactorCurrents[j][factoredCurrent - 1];
                        centValue -= factoredCurrent * factorCurrent;
                        if (centValue == 0)
                        {
                            break;
                        }
                        valueString += "-";
                    }

                    j++;
                }
                valueString += " Cent";
            }
            i++;

            return valueString;

        }

       
    }
}
