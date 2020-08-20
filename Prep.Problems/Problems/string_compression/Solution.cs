using System;
using System.Collections.Generic;
using System.Text;

namespace Prep.Problems.Problems.string_compression
{
    //https://leetcode.com/problems/string-compression/
    public class Solution
    {
        public int Compress(char[] chars)
        {
            if (chars.Length <= 1)
                return chars.Length;

            var scanIndex = 1;
            var lastSeenIndex = 0;
            var insertIndex = 0;
            for (; scanIndex < chars.Length; scanIndex++)
            {
                var count = scanIndex - lastSeenIndex;
                Console.WriteLine($"Last Seen: {chars[lastSeenIndex]} Current:{chars[scanIndex]} Count: {count} ");
                if (chars[scanIndex] != chars[lastSeenIndex])
                {
                    Console.WriteLine($"Original character of {chars[lastSeenIndex]} has changed to {chars[scanIndex]} after {count} occurences");

                    insertIndex = InsertCompression(chars, insertIndex, chars[lastSeenIndex], count);
                    lastSeenIndex = scanIndex;

                }
                if (scanIndex == chars.Length - 1)
                { //We have hit the last character without a change
                    count = scanIndex - lastSeenIndex;
                    insertIndex = InsertCompression(chars, insertIndex, chars[lastSeenIndex], count + 1);
                }
            }
            return insertIndex;
        }

        public int InsertCompression(char[] chars, int insertIndex, char insertChar, int count)
        {
            Console.WriteLine($"Character '{insertChar}' will be placed at {insertIndex}");
            chars[insertIndex++] = insertChar;
            if (count > 1)
            {
                char[] countNumber = count.ToString().ToCharArray();
                for (int j = 0; j < countNumber.Length; j++)
                {
                    Console.WriteLine($"Character '{countNumber[j]}' will be placed at {insertIndex}");
                    chars[insertIndex++] = countNumber[j];
                }
            }
            return insertIndex;
        }
    }
}
