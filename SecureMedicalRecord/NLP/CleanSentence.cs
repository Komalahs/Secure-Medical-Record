using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureMedicalRecord.NLP
{
    public class CleanSentence
    {
        private string[] articles;
        private String[] prepositions;
        private string[] conjunctions;
        private string[] pronouns;

        public CleanSentence()
        {
            articles = new string[] { " a ", "an ", " the ","the ","this ","am " };
            prepositions = new String[] { " aboard ", " about ", " across ", " after ", " against ", " along ", " amid ", " among ", " anti ", " around ", " as ", " at ", " before ", " behind ", " below ", " beneath ", " beside ", " besides ", " between ", " beyond ", " by ", " concerning ", " considering ", " despite ", " down ", " during ", " except ", " excepting ", " excluding ", " following ", " from ", " for ", " in ", " inside ", " into ", " like ", " minus ", " near ", " of ", " off ", " on ", " onto ", " opposite ", " outside ", " over ", " past ", " per ", " plus ", " regarding ", " round ", " save ", " since ", " than ", " through ", " to ", " toward ", " towards ", " under ", " underneath ", " unlike ", " until ", " up ", " upon ", " versus ", " via ", " with ", " within ", " without ", " the ", " is ", " than " };
            conjunctions = new String[] { " and ", " that ", " but "," are ", " or ", " as ", " if ", " when ", " than ", " because ", " while ", " where ", " after ", " so ", " though ", " since ", " until ", " whether ", " before ", " although ", " nor ", " like ", " once ", " unless ", " now ", " except ", " also ", " be ", " it " };
            pronouns = new string[] { "i ","it ", "we ","ours ","their ","there " };

        }

        public string RemoveArticles(string query)
        {

            foreach (string s in articles)
            {
                query = query.Replace(s, " ");
            }
            return query;
        }

        public String RemovePrepositions(String query)
        {
            foreach (String s in prepositions)
            {
                query = query.Replace(s, " ");
            }
            return query;
        }

        public string RemoveConjunctions(string query)
        {
            foreach (string s in conjunctions)
            {
                query = query.Replace(s, " ");
            }
            return query;

        }
        public string RemovePronouns(string query)
        {
            foreach (string s in pronouns)
            {
                query = query.Replace(s, " ");
            }
            return query;

        }
        Iveonik.Stemmers.EnglishStemmer objt = new Iveonik.Stemmers.EnglishStemmer();

        //public string stemmingword(string word)
        //{
        //    string words = objt.Stem(word);
        //    return words;
        //}

        public string stemms(string word)
        {
            string final = null;
            string[] savestem = new string[100];
            string[] stemstring = word.Split(' ');
            for (int i = 0; i < stemstring.Length; i++)
            {
                final += " " + string.Join(" ", objt.Stem(stemstring[i]));
                //savestem[i] = objt.Stem(stemstring[i]);
            }
            //for (int i = 0; i < savestem.Length; i++)
            //{
            //    final = string.Join(" ", savestem);
            //}
            return final;
        }





    }
}
