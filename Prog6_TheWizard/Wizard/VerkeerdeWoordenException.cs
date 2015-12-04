using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wizard
{
    public class VerkeerdeWoordenException : Exception
    {
        public VerkeerdeWoordenException()
            : base("Er zijn de verkeerde woorden gebruikt voor deze spreuk!")
        {
        }
    }
}
