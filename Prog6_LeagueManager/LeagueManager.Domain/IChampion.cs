using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueManager.Domain
{
    public interface IChampion
    {
        String Name { get; }

        String Fight(IChampion champion);
    }
}
