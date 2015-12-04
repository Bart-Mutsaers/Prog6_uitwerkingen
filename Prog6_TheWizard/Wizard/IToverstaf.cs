using System;
namespace Wizard
{
    public interface IToverstaf
    {
        void Links();
        void Omhoog();
        void Omlaag();
        void Rechts();

        int HoeveelheidEnergie { get;  }
    }
}
