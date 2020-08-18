using System;
using System.Collections.Generic;
using System.Text;

namespace Prep.Problems.Problems.gcd_of_string
{
    public class Solution
    {
        public string GcdOfStrings(string str1, string str2)
        {
            //str1 will be the longest one
            if (str2.Length > str1.Length)
            {
                var temp = str1;
                str1 = str2;
                str2 = temp;
            }

            var div = true;
            while (div)
            {
                div = false;
                var str2Length = str2.Length;
                while (str1.Length>=str2Length && str1.Substring(0,str2Length).StartsWith(str2))
                {
                    div = true;
                    str1 = str1.Substring(str2Length);
                }
                if (str1 == "")
                    return str2;
                else
                {
                    var temp = str1;
                    str1 = str2;
                    str2 = temp;
                }
            }
            return "";

        }






    }

}
