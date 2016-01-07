using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LeagueManager.Service.Model
{
    public class MyDbInitializer : DropCreateDatabaseIfModelChanges<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            base.Seed(context);

            //Wat een mooie seed methode!

        }
    }
}