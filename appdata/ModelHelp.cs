using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static elj.appdata.DBapp;

namespace elj.appdata
{
    public partial class RaspGroup_Result
    {
        public string timeStarrt
        {
            get
            {
                string ts = $"{timeStart.Hours}:{timeStart.Minutes}";
                return ts;
            }
        }

    }
}
