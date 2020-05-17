using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureMedicalRecord.NLP
{
    public class Tokenizer
    {
         // for discarding digits
        private static char[] delimiters_no_digits = new char[] {
            '{', '}', '(', ')', '[', ']', '>', '<','-', '_', '=', '+',
            '|', '\\', ':', ';', '"', ',', '.', '/', '?', '~', '!',
            '@', '#', '$', '%', '^', '&', '*', ' ', '\r', '\n', '\t',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };


        public string btnGo_Click(string message)
        {
            string text = message;

            // Call the improved tokenizer
            string[] tokens = Tokenize(text);

            // This time, we first put the result in a StringBuilder for the sake of efficiency;
            // then we dump the content of the StringBuilder to the text box.
            // We assume each word is 4 letters on the average.

            //StringBuilder sb = new StringBuilder(tokens.Length * 4);
            string res = null;
            foreach (string token in tokens)
            {
                res = string.Join(" ", tokens);           
            }

            return res;
        }

        public static string[] Tokenize(string text)
        {
            string[] tokens = null;
                tokens = text.Split(delimiters_no_digits, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tokens.Length; i++ )
            {
                string token = tokens[i];

                // Change token only when it starts and/or ends with "'" and the
                // toekn has at least 2 characters.
                if (token.Length > 1)
                {
                    if (token.StartsWith("'") && token.EndsWith("'"))
                        tokens[i] = token.Substring(1, token.Length - 2);  // remove the starting and ending "'"

                    else if (token.StartsWith("'"))
                        tokens[i] = token.Substring(1); // remove the starting "'"

                    else if (token.EndsWith("'"))
                        tokens[i] = token.Substring(0, token.Length - 1); // remove the last "'"
                }
            }

            return tokens;
        }
    }
    }
