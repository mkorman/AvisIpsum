using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AvisIpsum.Models
{
    /// <summary>
    /// Provides ipsum paragraphs by using an IWordProvider
    /// </summary>
    public class IpsumParagraphProvider : IIpsumParagraphProvider
    {
        public const int MIN_WORDS = 10;
        public const int MAX_WORDS = 100;

        protected IWordProvider wordProvider;
        protected Random random;

        public IpsumParagraphProvider () : this (new TextFileWordProvider())
        {
        }

        public IpsumParagraphProvider(IWordProvider wordProvider)
        {
            this.wordProvider = wordProvider;
            this.random = new Random();
        }

        /// <summary>
        /// Gets a single paragraph with the specified number of words. This will be capped between MIN_WORDS and MAX_WORDS
        /// </summary>
        /// <param name="numberOfWords">Maximum number of words</param>
        /// <returns>A paragraph of Ipsum text</returns>
        protected AvisIpsumText GetParagraphFixed(int numberOfWords)
        {
            // Cap input
            numberOfWords = Math.Max(numberOfWords, MIN_WORDS);
            numberOfWords = Math.Min(numberOfWords, MAX_WORDS);

            var sb = new StringBuilder();

            sb.Append("<p>");

            for (int i=0; i< numberOfWords; i++)
            {
                var word = wordProvider.GetRandomWord();

                if (i == 0)
                {
                    word = CapitalizeFirstChar(word);
                }

                sb.Append(word);

                if (i < numberOfWords - 1)
                {
                    sb.Append(" ");
                }
                else
                {
                    sb.Append(".</p>");
                }
            }

            return new AvisIpsumText (sb.ToString());
        }

        /// <summary>
        /// Gets one paragraph of random length up to maxWords
        /// </summary>
        /// <param name="maxWords">Maximum possible length of the paragraph</param>
        /// <returns></returns>
        public AvisIpsumText GetParagraph (int maxWords)
        {
            return GetParagraphFixed(random.Next(maxWords));
        }

        /// <summary>
        /// Gets one paragraph of random length up to the fixed MAX_WORDS
        /// </summary>
        /// <returns>A parapgraph of Ipsum words with max length</returns>
        public AvisIpsumText GetParagraph ()
        {
            return GetParagraph(MAX_WORDS);
        }


        public AvisIpsumText GetParagraphs (int numberOfParagraphs, int wordsPerParagraph)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numberOfParagraphs; i++)
            {
                sb.Append(GetParagraph(wordsPerParagraph).Contents);
            }

            return new AvisIpsumText(sb.ToString());
        }

        public AvisIpsumText GetParagraphs (int numberOfParagraphs)
        {
            return GetParagraphs(numberOfParagraphs, MAX_WORDS);
        }

        protected static string CapitalizeFirstChar (string text)
        {
            if (string.IsNullOrEmpty (text))
            {
                return text;
            }

            return char.ToUpper(text[0]) + text.Substring(1);
        }
    }
}