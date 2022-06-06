using elj.appdata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static elj.appdata.DBapp;

namespace elj.classFunc
{
    internal class Filtr
    {
        public static List<Student> FiltrGroup(int kurs, string status, string group)
        {
            int cbk = kurs;
            string cbs = status;
            string cbg = group;

            if (cbs == null && cbk == -1)
            {

               // cbg = group;

               return context.Student.
                      Where(i => i.StudGroup1.groupName == cbg).ToList();
            }
            //else if (cbk != -1 && cbs == null)
            //{

            //    cbg = cb_Group.SelectedValue.ToString();

            //    infoGridStudents.ItemsSource = context.Student.
            //          Where(i => i.StudGroup1.groupName == cbg && i.StudGroup1.course == cbk).ToList();
            //}
            // else 
            // {
            //     cbg = cb_Group.SelectedValue.ToString();
            //
            //     infoGridStudents.ItemsSource = context.Student.
            //           Where(i => i.StudGroup1.groupName == cbg && i.StudGroup1.course == cbk && i.status == cbs.ToString()).ToList();
            // }

            return null;

        }
        public void FiltrCourse()
        {

        }
        public void FiltrStatus()
        {

        }
    }
}
