using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Lab1_ASPNetConnectedMode.VALIDATION
{
    public static class Validator
    {
        //4digit number for employee Id
        public static bool IsValid(string input)
        {
            if (!Regex.IsMatch(input,@"^\d{4}$")) 
            {
                return false;
            }
            return true;
        }
        public static bool IsValid(string input, int size)
        {
            // Use string interpolation to insert the size variable into the regex pattern
            if (!Regex.IsMatch(input, $"^\\d{{{size}}}$"))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidName(string name)
        {
            if(name.Length == 0)
            {
                return false;
            }
            else
            {
                for(int i = 0; i < name.Length; i++)
                {
                    if (!(Char.IsLetter(name[i])) && !(Char.IsWhiteSpace(name[i])))
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }

    }
}