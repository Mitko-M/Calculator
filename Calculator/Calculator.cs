using System.Collections.Generic;
using System.Linq;
using Windows.Security.Authentication.Identity.Provider;

namespace Calculator
{
    public class Calculator
    {
        private string input;
        private char[] artihmetics = { '*', '/', '-', '+' };

        public Calculator()
        {
            
        }

        public Calculator(string _input)
        {
            input = _input;
        }

        public string Calculate()
        {
            string result = "";

           //TODO: think of the business logic and implement it then use the class in the windows.cs

            return result;
        }
    }
}
