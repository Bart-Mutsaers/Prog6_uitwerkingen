using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wizard
{
    public class Toverstaf : IToverstaf
    {
        private int _hoeveelheidEnergie;

        public int HoeveelheidEnergie
        {
            get { return _hoeveelheidEnergie; }
        }

        public Toverstaf()
        {
            _hoeveelheidEnergie = 10;
        }

        public Toverstaf(int energie)
        {
            _hoeveelheidEnergie = 100;
        }

        public void Links()
        {
            _hoeveelheidEnergie--;
        }

        public void Rechts()
        {
            _hoeveelheidEnergie--;
        }

        public void Omhoog()
        {
            _hoeveelheidEnergie--;
        }

        public void Omlaag()
        {
            _hoeveelheidEnergie--;
        }
    }
}
