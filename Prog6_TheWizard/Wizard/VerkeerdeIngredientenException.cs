using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wizard
{
    public class VerkeerdeIngredientenException : Exception
    {
        public VerkeerdeIngredientenException()
            : base("Er zijn de verkeerde ingredienten gebruikt voor deze spreuk!")
        {
        }
    }
}
