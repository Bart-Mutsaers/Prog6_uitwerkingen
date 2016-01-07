using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueManager.Domain
{
    public class Vayne : IChampion
    {

        public string Name
        {
            get { return "Vayne";  }
        }


        public string Fight(IChampion champion)
        {
            //Vayne wint in dit geval altijd.

            switch (champion.Name)
            {
                case "Vayne" : return "Tie";
                default: return this.Name;
            }

           

        }
    }
}
