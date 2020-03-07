using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheetDAL.ViewModel
{
    public class TaskViewModel
    {
        public int EmpID { get; set; }
        public string Code { get; set; }
        public string EmpName { get; set; }

        public string TaskName { get; set; }
        public string Description { get; set; }

       
    }
}
