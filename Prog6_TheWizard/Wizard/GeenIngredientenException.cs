using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wizard
{
    public class GeenIngredientenException : Exception
    {
        public GeenIngredientenException() : base("Er zijn geen ingredienten gebruikt voor deze spreuk!")
        {
        }
    }
}
