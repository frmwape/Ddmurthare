using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Ddmurthare.App_Code.PeriodicTable
{
    /*
     The following class is used to validate that periodic table rules are met as stipulated by planet Ddmurthare.
     Once the required data is supplied via the constructor I have followed as my solution a combination of different methods (within the main ProcessValidation function) validating data sequentially i.e. if predecessor succeeds proceed to next else halt and feedback.
     At the end of the process feedback will either produce successfully supplied data per rules or failure on a particular rule.
     - FCM
    */
    public class clsValidateRules : Ddmurthare.App_Code.Utils.clsDisposeObject
    {
        private string strInputElement;
        private string strInputSymbol;
        private string strOutputElement;
        private string strOutputSymbol;
        private string strOutputValidateErrors;
        private bool bolValidOutputResult;

        public bool ValidOutputResult { get { return bolValidOutputResult; } }
        public string OutputValidateErrors { get { return strOutputValidateErrors; } }
        public string OutputSymbol { get { return strOutputSymbol; } }
        public string OutputElement { get { return strOutputElement; } }

        public clsValidateRules(string element, string symbol)
        {
            //From the begining I want to work with lower cased data when it is assigned to the variables.
            strInputElement = element.ToLower();
            strInputSymbol = symbol.ToLower();

            bolValidOutputResult = false;
            strOutputValidateErrors = "";
            strOutputSymbol = "";
            strOutputElement = "";

        }

        public void ProcessValidation()
        {
            bool canContinue = false;

            //First validation - has data been supplied?
            canContinue = DataProvided();

            //Next validate that provided data only has letters
            if (canContinue)
                canContinue = DataIsOnlyLetters();

            //Next validate that provided data for symbol only contains 2 letters
            if (canContinue)
                canContinue = SymobolHasOnlyTwoLetters();

            //Next validate that provided data for symbol data is contained in element and appears in the right sequence
            if (canContinue)
                canContinue = SymbolIsValid();

            
            if (strOutputValidateErrors.Length == 0)
                bolValidOutputResult = true;

            //Finally capitalise first letter
            CapitaliseFirstLetter();
        }

        private bool DataProvided()
        {
            //Checks that data has been provided which is necessary for validation.
            //Simple length check.

            bool result = true;

            if (strInputElement.Trim().Length == 0)
            {
                strOutputValidateErrors += "No element data provided! ";
                result = false;
            }

            if (strInputSymbol.Trim().Length == 0)
            {
                strOutputValidateErrors += "No symbol data provided! ";
                result = false;
            }

            return result;

        }

        private bool DataIsOnlyLetters()
        {
            //Checks that data provided consists of letters only.
            //Simple redex check.

            bool result = true;

            if (!Regex.IsMatch(strInputElement.Trim(), @"^[a-zA-Z]+$"))
            {
                strOutputValidateErrors += "Element data provided should only contain letters! ";
                result = false;
            }

            if (!Regex.IsMatch(strInputSymbol.Trim(), @"^[a-zA-Z]+$"))
            {
                strOutputValidateErrors += "Symbol data provided should only contain letters ";
                result = false;
            }

            return result;

        }

        private bool SymobolHasOnlyTwoLetters()
        {
            //Checks that symbol data provided consists of 2 letters only.
            //Simple length check by assigning to a long variable.

            bool result = true;
            long numberOfletters = strInputSymbol.Trim().Length;
                      
            if (numberOfletters > 2)
            {
                strOutputValidateErrors += "Symbol data provided should contain 2 letters. Supplied data contains " + numberOfletters + " letters which is more! ";
                result = false;
            }
            else if (numberOfletters < 2)
            {
                strOutputValidateErrors += "Symbol data provided should contain 2 letters. Supplied data contains " + numberOfletters + " letters which is less! ";
                result = false;
            }

            return result;

        }

        private bool SymbolIsValid()
        {
            //Checks that symbol data provided matches the following rule.
            //That it is contained in the element name sequentiallly.
            //Indexof will determine positioning of where symbol letter appears avoiding last letter appearing before first.
      
            bool result = true;
            long currentPosition = 0;
            int comparePostion = 0;
            string currentLetter;

            for (int i = 0; i < strInputSymbol.Length; i++)
            {
                currentLetter = strInputSymbol.Substring(i, 1);

                currentPosition = strInputElement.IndexOf(currentLetter, comparePostion);

                //Check if current sysmbol letter exists in the element starting positon set to previous element
                if (currentPosition == -1)
                {
                                       
                    strOutputValidateErrors += "Number " + (i + 1) + " symbol letter '" + currentLetter + "' not found in element! ";
                    result = false;
                    break;
                }
                else
                {
                    
                   
                        comparePostion = (int)currentPosition + 1;
                    
                    
                }

            }

            return result;

        }

        private void CapitaliseFirstLetter()
        {
            //Capitalise first letter of the Element and Symbol.

            int i;

            //Element done first
            for (i = 0; i < strInputElement.Length; i++)
            {
                if (i == 0)
                {
                    strOutputElement += strInputElement.Substring(i, 1).ToUpper();
                }
                else
                {
                    //Although data was initially lower cased, precaution sake still done here
                    strOutputElement += strInputElement.Substring(i, 1).ToLower();
                }
            }

            //Same process for symbol
            for (i = 0; i < strInputSymbol.Length; i++)
            {
                if (i == 0)
                {
                    strOutputSymbol += strInputSymbol.Substring(i, 1).ToUpper();
                }
                else
                {
                    //Although data was initially lower cased, precaution sake still done here
                    strOutputSymbol += strInputSymbol.Substring(i, 1).ToLower();
                }
            }


        }
    }
}