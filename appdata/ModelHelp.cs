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
                DateTime dt;
                TimeSpan timeSpan = new TimeSpan(0, 00, 0);
                timeSpan = timeStart;
                dt = Convert.ToDateTime(timeSpan.ToString());
                string ts = dt.Minute.ToString("00");
                string st = dt.Hour.ToString();
                string tst = $"{st}:{ts}";
                return tst;
            }
        }

       
        
            
            
            

    }
}
