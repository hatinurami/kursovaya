using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static elj.appdata.DBapp;

namespace elj.appdata
{
    public partial class Shedule
    {
        public string Rasp
        {
            get
            {
                var arrrasp = context.Subject.Select(i => i.idSubj.Where(j => j == context.Shedule.));
                //var rasp = string.Join("\n", context.Shedule.Select(i => i.));
                return;
            }
        }
    }
}
