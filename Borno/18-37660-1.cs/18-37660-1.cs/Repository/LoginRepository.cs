using _18_36449_1.cs.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_36449_1.cs.Repository
{
    public class LoginRepository
    {
        DataAccess db = new DataAccess();
        SqlDataReader reader;

        public bool LoginValidation(LoginEntity eLog)
        {

            string sql = "Select * from Login Where UserName='"+eLog.UserName+"' And Password='"+eLog.Password+"'";
            reader=db.GetData(sql);
            if (reader.Read())
                return true;
            else
                return false;
        }
        public bool SignUp(LoginEntity eLog)
        {
            string sql = "Insert Into Login  values('" + eLog.UserName + "','" + eLog.Password + "')";
            int result = db.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            else 
                return false;
        }
    }
}
