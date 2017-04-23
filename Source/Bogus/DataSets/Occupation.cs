using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bogus.DataSets
{
    /// <summary>
    /// 
    /// </summary>
    public class Occupation : DataSet
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="locale"></param>
        public Occupation(string locale = "en") : base(locale)
        {
        }

        /// <summary>
        /// Get a random lorem word.
        /// </summary>
        public string Get()
        {
            return this.GetRandomArrayItem("items");
        }

        /// <summary>
        /// Get some lorem words
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string[] Occupations(int num = 3)
        {
            return Enumerable.Range(1, num).Select(f => Get()).ToArray(); // lol
        }
         
        /// <summary>
        /// Slugify lorem words.
        /// </summary>
        /// <param name="wordcount"></param>
        public string Slug(int wordcount = 3)
        {
            var words = Occupations(wordcount);
            return Utils.Slugify(string.Join(" ", words));
        } 

    }
}
