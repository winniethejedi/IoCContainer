namespace IoCContainer
{
    public class BusinessLogic : IBusinessLogic
    {
        private readonly IDataAccess1 _dataAccess1;
        private readonly IDataAccess2 _dataAccess2;

        public BusinessLogic(IDataAccess1 dataAccess1,
            IDataAccess2 dataAccess2)
        {
            _dataAccess1 = dataAccess1;
            _dataAccess2 = dataAccess2;
        }

        public string GetIncrementingStringAndNumber()
        {
            return _dataAccess1.GetIncrementingString() + " " + _dataAccess2.GetIncrementingNumber();
        }
    }
}
