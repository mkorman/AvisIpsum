using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvisIpsum.Models
{
    public class IpsumRequestParams
    {
        [Display (Name = "Number of paragraphs")]
        [Range(1, 100)]
        public int NumberOfParagraphs { get; set; }

        [Display (Name ="Words per paragraph")]
        [Range(IpsumParagraphProvider.MIN_WORDS, IpsumParagraphProvider.MAX_WORDS)]
        public int WordsPerParagraph { get; set; }
    }
}