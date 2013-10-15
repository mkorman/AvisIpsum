using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisIpsum.Models
{
    /// <summary>
    /// Provides paragraphs of random text
    /// </summary>
    public interface IIpsumParagraphProvider
    {
        /// <summary>
        /// Gets one Paragraph of random length
        /// </summary>
        /// <returns></returns>
        AvisIpsumText GetParagraph();

        /// <summary>
        /// Gets one Paragraph of random length up to the specified number of words
        /// </summary>
        /// <param name="numberOfWords"></param>
        /// <returns></returns>
        AvisIpsumText GetParagraph(int numberOfWords);
        AvisIpsumText GetParagraphs(int numberOfParagraphs);
        AvisIpsumText GetParagraphs(int numberOfParagraphs, int numberOfWords);
    }
}
