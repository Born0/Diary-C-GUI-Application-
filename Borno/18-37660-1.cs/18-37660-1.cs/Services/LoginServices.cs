using _18_36449_1.cs.Entities;
using _18_36449_1.cs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_36449_1.cs.Services
{
    public class LoginServices
    {
        LoginRepository login=new LoginRepository();

        public bool LoginCheck(LoginEntity eLog)
        {
            return login.LoginValidation(eLog);
        }
        public bool NewSignUp(LoginEntity eLog)
        {
            return login.SignUp(eLog );
        }
    }
}
