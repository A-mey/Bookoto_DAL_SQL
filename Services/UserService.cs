using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using DataAccess.Models;
using DataAccess.DBAccess;

namespace DataAccess.Services
{
    public class UserService
    {
        //public static DataSet Register(Pill Pill)
        //{
        //    DBA dba = new DBA();
        //    //DataSet ds = dba.DBExec("Register", Pill);
        //    return ds;
        //}

        public static DataSet Test(Test test)
        {
            DBA dba = new DBA();
            DataSet ds = dba.DBExec("GetProductCategories", test);
            return ds;
        }
    }
}
