using System;

namespace Num2Word.Service
{

    public class CoreService
    {
        public string ReturnNumWord(int num)
        {
            string output = "";
            switch (num)
            {
                case 1:
                    output = "ONE";
                    break;
                case 2:
                    output = "TWO";
                    break;
                case 3:
                    output = "THREE";
                    break;
                case 4:
                    output = "FOUR";
                    break;
                case 5:
                    output = "FIVE";
                    break;
                case 6:
                    output = "SIX";
                    break;
                case 7:
                    output = "SEVEN";
                    break;
                case 8:
                    output = "EIGHT";
                    break;
                case 9:
                    output = "NINE";
                    break;
                case 10:
                    output = "TEN";
                    break;
                case 11:
                    output = "ELEVEN";
                    break;
                case 12:
                    output = "TWELVE";
                    break;
                case 13:
                    output = "THIRTEEN";
                    break;
                case 14:
                    output = "FOURTEEN";
                    break;
                case 15:
                    output = "FIFTEEN";
                    break;
                case 16:
                    output = "SIXTEEN";
                    break;
                case 17:
                    output = "SEVENTEEN";
                    break;
                case 18:
                    output = "EIGHTEEN";
                    break;
                case 19:
                    output = "NINETEEN";
                    break;
                case 20:
                    output = "TWENTY";
                    break;
                case 30:
                    output = "THIRTY";
                    break;
                case 40:
                    output = "FORTY";
                    break;
                case 50:
                    output = "FIFTY";
                    break;
                case 60:
                    output = "SIXTY";
                    break;
                case 70:
                    output = "SEVENTY";
                    break;
                case 80:
                    output = "EIGHTY";
                    break;
                case 90:
                    output = "NINTY";
                    break;
            }

            return output;


        }

        public string Convert(double num)
        {
            //throw new NotImplementedException();
            //Num needs to be number a thousand and greater than 0

            /*
             123.45 = ONE HUNDERD AND TWENTY THREE DOLLARS AND FORTY-FIVE CENTS

            */

            if (num <= 0 || num > 999)
                throw new Exception("Input Number can must be greater than 0 and smaller than 1000");

            int leftSideOfDecimal = 0, rightSideOfDecimal = 0;

            string finalResult = string.Empty;
            string strCentsWord = string.Empty;
            string strHundredsWord = string.Empty;
            string strTensWord = string.Empty;
            string strCents = string.Empty;
            string strDollars = string.Empty;

            if (num.ToString().Contains("."))
            {
                //if number has over 2 decimal place, throw
                if (!DoesNumHasTwoDecimalPlace(num))
                    throw new Exception("Input Number can have 2 decimal places");

                string[] numStr = num.ToString().Split('.');

                strCents = numStr[1]; //e.g. 45
                strDollars = numStr[0]; //e.g. 123

                if (int.TryParse(strCents, out rightSideOfDecimal))
                {
                    strCentsWord = string.Concat(ConvertTensToWords(rightSideOfDecimal, "-"), " CENT");
                    if (rightSideOfDecimal > 1)
                    {
                        strCentsWord += "S";
                    }
                }
                else
                {
                    throw new Exception("Error converting the right hand side of the decimal place");
                }

            }
            else
            {
                strDollars = num.ToString();
            }

            if (!int.TryParse(strDollars, out leftSideOfDecimal))
            {
                throw new Exception("Error converting the left hand side of the decimal place");
            }

            if (strDollars.Length > 2)
            {
                int hundreds = 0;
                if (int.TryParse(strDollars.Substring(0, 1), out hundreds))
                {
                    strHundredsWord = ReturnNumWord(hundreds) + " HUNDRED";
                }
                else
                {
                    throw new Exception("Error converting the hundreds value");
                }

                strDollars = strDollars.Substring(1, 2);
            }

            int tens = 0;

            if (int.TryParse(strDollars, out tens))
            {
                strTensWord = ConvertTensToWords(tens, " ");
            }

            if (!string.IsNullOrEmpty(strHundredsWord))
            {
                finalResult = strHundredsWord;
            }

            if(!string.IsNullOrEmpty(strHundredsWord) && !string.IsNullOrEmpty(strTensWord))
            {
                finalResult += " AND ";
            }

            if (!string.IsNullOrEmpty(strTensWord))
            {
                finalResult += strTensWord;
            }

            if(leftSideOfDecimal > 0)
            {
                finalResult += " DOLLAR";
                if (leftSideOfDecimal > 1)
                {
                    finalResult += "S";
                }
            }

            if (!string.IsNullOrEmpty(strCentsWord))
            {
                if (leftSideOfDecimal > 0)
                {
                    finalResult += " AND ";
                }

                finalResult += strCentsWord;
            }

            return finalResult;

            //hundreds = strDollars.

        }

        public bool DoesNumHasTwoDecimalPlace(double num)
        {
            bool result = true;

            string[] numStr = num.ToString().Split('.');

            result = numStr[1].Length <= 2;

            return result;
        }

        public string ConvertTensToWords(int num, string concat)
        {
            string result = string.Empty;

            if (num > 0)
            {
                string ones = string.Empty;
                string tens = string.Empty;


                int _num = num;

                if (num > 20)
                {
                    if (num % 10 > 0)
                    {
                        ones = ReturnNumWord((num % 10));
                        _num = num - (num % 10);
                    }
                }

                tens = ReturnNumWord(_num);

                if (string.IsNullOrEmpty(ones))
                {
                    result = tens;
                }
                else
                {
                    result = string.Concat(tens, concat, ones);
                }
            }

            return result;
        }
    }
}
