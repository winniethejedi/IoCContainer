using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCContainer
{
    public class DataAccess2 : IDataAccess2
    {
        private int _incrementingNumber = 0;

        public int GetIncrementingNumber()
        {
            _incrementingNumber++;
            return _incrementingNumber;
        }
    }
}
