using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisIpsum.Models
{
    public interface IWordProvider
    {
        string GetRandomWord ();
    }
}
