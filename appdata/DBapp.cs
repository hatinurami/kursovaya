using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using elj.appdata;


namespace elj.appdata
{
    public static class DBapp
    {
        public static elJournalEntities context = new elJournalEntities();
        public static Student autst = new Student();
        public static Teacher auttch = new Teacher();

        public static List<MarkStud_Result> msr = new List<MarkStud_Result>();
        public static List<RaspGroup_Result> ob = new List<RaspGroup_Result>();
       
      

        
    }
   
}
