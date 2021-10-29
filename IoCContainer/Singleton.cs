using System;

namespace IoCContainer
{
    public class Singleton : ISingleton
    {
        private DateTime _incrementingDateTime = new DateTime(year: 1999, month: 12, day: 31);

        public DateTime GetIncrementingDateTime()
        {
            _incrementingDateTime = _incrementingDateTime.AddDays(1);
            return _incrementingDateTime;
        }
    }
}
