using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace currentParserServer
{
    class Constant
    {   
        public String[] stringPotencyList = { "million", "thousand", "" };
        private String[] stringHundrets = { "onehundred", "twohundred", "threehundred", "fourhundred", "fivehundred", "sixhundred", "sevenhundred", "eighthundred", "ninehundred" };
        private String[] stringTens = { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eigty", "ninty" };
        private String[] stringOnes = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "therteen", "fourteen", "fiveteen", "sixteen", "seventeen", "eigthteen", "nineteen" };
        public List<String[]> stringFactorCurrents = new List<String[]>();
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

        

        static Boolean outOfRange(double value)
        {
            if (value < 0)
            {
                return true;
            }
            if (value > 999_999_999)
            {
                return true;
            }
            return false;
        }


        public String valueToWord(double value)
        {

            if (value == 0)
            {
                return "zero dollars";
            }
            if (value == 1)
            {
                return "one dollar";
            }
            String valueString = "";

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
            return valueString + "dollars";
        }


    }
}
