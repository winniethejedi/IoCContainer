using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCContainer
{
    public class DataAccess1 : IDataAccess1
    {
        private string _incrementingString = "";

        public string GetIncrementingString()
        {
            _incrementingString += "1";
            return _incrementingString;
        }
    }
}
