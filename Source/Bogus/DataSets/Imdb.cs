﻿using System;
using System.Linq;
using System.Text;

namespace Bogus.DataSets
{
    /// <summary>
    /// Generates Imdb text.
    /// </summary>
    public class Imdb : DataSet
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="locale"></param>
        public Imdb(string locale = "en") : base(locale)
        {
        }

        /// <summary>
        /// Get a random imdb review sentence.
        /// </summary>
        public string Sentence()
        {
            return this.GetRandomArrayItem("sentence");
        }
        /// <summary>
        /// Get a random imdb review sentence.
        /// </summary>
        public string[] Sentences(int count)
        {
            return Enumerable.Range(1, count).Select(f => Sentence()).ToArray(); // lol
        }

        /// <summary>
        /// Get a random sentence of specific number of words. 
        /// </summary>
        /// <param name="wordCount">Get a sentence with wordCount words. Defaults between 3 and 10</param>
        /// <param name="range">Add anywhere between 0 to 'range' additional words to wordCount. Default is 0.</param>
        public string PartialSentence(int? wordCount = null, int? range = 0)
        {
            var wc = wordCount ?? this.Random.Number(3, 10);
            if (range > 0)
            {
                wc += this.Random.Number(range.Value);
            }
            var sentences = Sentences(10);
            var builder = new StringBuilder();
            for (var i = 0; i < wc; i++)
            {
                var sentence = Random.ArrayElement(sentences);
                var words = sentence.Split(new string[]{ " " }, StringSplitOptions.RemoveEmptyEntries);
                var word = Random.ArrayElement(words);
                builder.Append(word).Append(" ");
            }
            var outputSentence = builder.ToString();
            return outputSentence.Substring(0, 1).ToUpper() + outputSentence.Substring(1) + ".";
        }

        /// <summary>
        /// Get some imdb review words
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string Word()
        {
            return Random.ArrayElement(Sentence().Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries));
        }

        /// <summary>
        /// Get some lorem words
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string[] Words(int num = 0, int max = 10)
        {
            if (max == 0 || max < 0) max = 10;
            if (num == 0)
            {
                num = this.Random.Number(2, max);
            }
            return Enumerable.Range(1, num).Select(f => Word()).ToArray(); // lol
        }

        /// <summary>
        /// Get a character letter.
        /// </summary>
        /// <param name="num">Number of characters to return.</param>
        /// <returns></returns>
        public string Letter(int num = 1)
        {
            if( num <= 0 )
                return string.Empty;

            var w = Words(1)[0];
            var c = Random.ArrayElement(w.ToArray());
            return c + Letter(num - 1);
        }



        /// <summary>
        /// Slugify lorem words.
        /// </summary>
        /// <param name="wordcount"></param>
        public string Slug(int wordcount = 3)
        {
            var words = Words(wordcount);
            return Utils.Slugify(string.Join(" ", words));
        }

        /// <summary>
        /// Get some sentences.
        /// </summary>
        /// <param name="sentanceCount">The number of sentences</param>
        /// <returns></returns>
        public string Sentences(int? sentanceCount = null, string separator = "\n")
        {
            var sc = sentanceCount ?? this.Random.Number(2, 6);
            var sentences = Enumerable.Range(1, sc)
                .Select(s => Sentence());

            return string.Join(separator, sentences);
        }

        /// <summary>
        /// Get a paragraph.
        /// </summary>
        /// <param name="count">The number of paragraphs</param>
        /// <returns></returns>
        public string Paragraph(int count = 3)
        {
            return Sentences(count + Random.Number(3), " ");
        }

        /// <summary>
        /// Get some paragraphs with tabs n all.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public string Paragraphs(int count = 3, string separator = "\n\n")
        {
            var paras = Enumerable.Range(1, count)
                .Select(i => Paragraph());

            return string.Join(separator, paras);
        }

        /// <summary>
        /// Get random text on a random lorem methods.
        /// </summary>
        public string Text()
        {
            var methods = new Func<string>[] {() => Word(), () => Sentence(), () => Sentences(), () => Paragraph()};

            var randomLoremMethod = this.Random.ArrayElement(methods);
            return randomLoremMethod();
        }

        /// <summary>
        /// Get lines of lorem
        /// </summary>
        /// <returns></returns>
        public string Lines(int? lineCount = null, string seperator = "\n")
        {
            var lc = lineCount ?? this.Random.Number(1, 5);

            return Sentences(lc, seperator);
        }

    }
}
