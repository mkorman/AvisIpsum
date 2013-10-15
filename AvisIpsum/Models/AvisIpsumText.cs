using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvisIpsum.Models
{
    public class AvisIpsumText
    {
        public string Contents { get; set; }

        public AvisIpsumText (string contents)
        {
            this.Contents = contents;
        }
    }
}