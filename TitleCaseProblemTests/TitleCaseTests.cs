using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TitleCaseProblemTests
{
    [TestClass]
    public class TitleCaseTests
    {
        [TestMethod]
        public void Example1()
        {
            var result = TitleCase("i love solving problems and it is fun");
            Assert.AreEqual("I Love Solving Problems and It Is Fun", result);
        }
        
        [TestMethod]
        public void Example2()
        {
            var result = TitleCase("wHy DoeS A biRd Fly?");
            Assert.AreEqual("Why Does a Bird Fly?", result);
        }
        
        [TestMethod]
        public void Corner1()
        {
            var result = TitleCase("aT");
            Assert.AreEqual("At", result);
        }
        
        [TestMethod]
        public void Corner2()
        {
            var result = TitleCase("");
            Assert.AreEqual("", result);
        }

        private List<string> lowerList = new List<string> { "a", "the", "to", "at", "in", "with", "and", "but", "or" }; 

        public string TitleCase(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                title = title.ToLower();
                var words = title.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    if (i == 0 || i == words.Length - 1 || !lowerList.Contains(words[i]))
                    {
                        words[i] = Capitalize(words[i]);
                    }
                }

                // Combine words into sentence
                return string.Join(" ", words);
            }

            return title;
        }

        // Capitalize word
        private string Capitalize(string word)
        {
            return char.ToUpper(word[0]) + word.Substring(1);
        }

        // Lowercase word
        /*private string Lowercase(string word)
        {
            // foreach letter in word
            // Lowercase letter
            return word.ToLower();
        }*/

        #region My Attempt

        private static readonly List<string> LowerCaseListMe = new List<string> {"a", "the", "to", "at", "in", "with", "and", "but", "or"};

        public string TitleCaseMe(string title)
        {
            string[] titleParts = new string[] {};

            if (!string.IsNullOrWhiteSpace(title))
            {
                titleParts = title.Split(' ');
                CapitalizeWordMe(ref titleParts[0]);

                if (titleParts.Length > 1)
                {
                    CapitalizeWordMe(ref titleParts[titleParts.Length - 1]);

                    for (var i = 1; i < titleParts.Length - 1; i++)
                    {
                        if (LowerCaseListMe.Any(e => e.Equals(titleParts[i], StringComparison.CurrentCultureIgnoreCase)))
                        {
                            LowercaseWordMe(ref titleParts[i]);
                        }
                        else
                        {
                            CapitalizeWordMe(ref titleParts[i]);
                        }
                    }
                }
            }

            return titleParts.Length > 0 ? String.Join(" ", titleParts) : title;
        }

        public void CapitalizeWordMe(ref string word)
        {
            word = word.Substring(0, 1).ToUpper() + word.Substring(1, word.Length - 1).ToLower();
        }

        public void LowercaseWordMe(ref string word)
        {
            word = word.ToLower();
        }

        #endregion
    }
}
