using System;

namespace IoCContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            Console.WriteLine("List of registed transient objects. There shouldn't be any.");
            Console.WriteLine(container.GetTransientsString());
            Console.WriteLine("List of registed singleton objects. There shouldn't be any.");
            Console.WriteLine(container.GetSingletonsString());

            Console.WriteLine("Registering objects . . .");
            container.Register<IBusinessLogic, BusinessLogic>();
            Console.WriteLine("BusinessLogic registered.");
            container.Register<IDataAccess2, DataAccess2>();
            Console.WriteLine("IDataAccess2 registered.");
            container.Register<IDataAccess1, DataAccess1>();
            Console.WriteLine("IDataAccess1 registered.");
            container.Register<ISingleton, Singleton>(LifeCycleType.Singleton);
            Console.WriteLine("ISingleton registered.");
            Console.WriteLine("Done registering objects.");
            Console.WriteLine("");

            Console.WriteLine("List of registed transient objects. There should be three: BusinessLogic, DataAccess2, and DataAccess1.");
            Console.WriteLine(container.GetTransientsString());
            Console.WriteLine("List of registed singleton objects. There should be one: Singleton.");
            Console.WriteLine(container.GetSingletonsString());

            Console.WriteLine("Resolving first instances of objects . . .");
            var dataAccess1 = container.Resolve<IDataAccess1>();
            Console.WriteLine("dataAccess1 resolved.");
            var dataAccess2 = container.Resolve<IDataAccess2>();
            Console.WriteLine("dataAccess2 resolved.");
            var businessLogic = container.Resolve<IBusinessLogic>();
            Console.WriteLine("businessLogic resolved.");
            var singleton = container.Resolve<ISingleton>();
            Console.WriteLine("singleton resolved.");
            Console.WriteLine("Done resolving first instances of objects.");
            Console.WriteLine("");

            Console.WriteLine("Invoking dataAccess1.GetIncrementingString. This should be \"1\" because it's the first time the method is invoked.");
            Console.WriteLine(dataAccess1.GetIncrementingString());
            Console.WriteLine("");
            Console.WriteLine("Invoking dataAccess2.GetIncrementingNumber. This should be 1 because it's the first time the method is invoked.");
            Console.WriteLine(dataAccess2.GetIncrementingNumber());
            Console.WriteLine("");
            Console.WriteLine("Invoking businessLogic.GetIncrementingStringAndNumber. This should be \"1 1\" because it's the first time that this method is invoked");
            Console.WriteLine("and businessLogic has its own instances of DataAccess1 and DataAccess2");
            Console.WriteLine(businessLogic.GetIncrementingStringAndNumber());
            Console.WriteLine("");
            Console.WriteLine("Invoking singleton.GetIncrementingDatetime. This should be 1/1/2000 because it's the first time the method is invoked.");
            Console.WriteLine(singleton.GetIncrementingDateTime().ToShortDateString());
            Console.WriteLine("");

            Console.WriteLine("Invoking dataAccess1.GetIncrementingString. This should be \"11\" because it's the second time the method is invoked.");
            Console.WriteLine(dataAccess1.GetIncrementingString());
            Console.WriteLine("");
            Console.WriteLine("Invoking dataAccess2.GetIncrementingNumber. This should be 2 because it's the second time the method is invoked.");
            Console.WriteLine(dataAccess2.GetIncrementingNumber());
            Console.WriteLine("");
            Console.WriteLine("Invoking businessLogic.GetIncrementingStringAndNumber. This should be \"11 2\" because it's the second time that this method is invoked");
            Console.WriteLine("and businessLogic has its own instances of DataAccess1 and DataAccess2");
            Console.WriteLine(businessLogic.GetIncrementingStringAndNumber());
            Console.WriteLine("");
            Console.WriteLine("Invoking singleton.GetIncrementingDatetime. This should be 1/2/2000 because it's the second time the method is invoked.");
            Console.WriteLine(singleton.GetIncrementingDateTime().ToShortDateString());
            Console.WriteLine("");

            Console.WriteLine("Resolving second instances of objects . . .");
            var dataAccess12 = container.Resolve<IDataAccess1>();
            Console.WriteLine("dataAccess12 resolved.");
            var dataAccess22 = container.Resolve<IDataAccess2>();
            Console.WriteLine("dataAccess22 resolved.");
            var businessLogic2 = container.Resolve<IBusinessLogic>();
            Console.WriteLine("businessLogic2 resolved.");
            var singleton2 = container.Resolve<ISingleton>();
            Console.WriteLine("singleton2 resolved.");
            Console.WriteLine("Done resolving second instances of objects.");
            Console.WriteLine("");

            Console.WriteLine("Invoking dataAccess12.GetIncrementingString. This should be \"1\" because it's the first time the method is invoked.");
            Console.WriteLine(dataAccess12.GetIncrementingString());
            Console.WriteLine("");
            Console.WriteLine("Invoking dataAccess22.GetIncrementingNumber. This should be 1 because it's the first time the method is invoked.");
            Console.WriteLine(dataAccess22.GetIncrementingNumber());
            Console.WriteLine("");
            Console.WriteLine("Invoking businessLogic2.GetIncrementingStringAndNumber. This should be \"1 1\" because it's the first time that this method is invoked");
            Console.WriteLine("and businessLogic2 has its own instances of DataAccess1 and DataAccess2");
            Console.WriteLine(businessLogic2.GetIncrementingStringAndNumber());
            Console.WriteLine("");
            Console.WriteLine("Invoking singleton2.GetIncrementingDatetime. This should be 1/3/2000 because it's the third time the method is invoked.");
            Console.WriteLine(singleton2.GetIncrementingDateTime().ToShortDateString());
            Console.WriteLine("");

            Console.WriteLine("Invoking dataAccess12.GetIncrementingString. This should be \"11\" because it's the second time the method is invoked.");
            Console.WriteLine(dataAccess12.GetIncrementingString());
            Console.WriteLine("");
            Console.WriteLine("Invoking dataAccess22.GetIncrementingNumber. This should be 2 because it's the second time the method is invoked.");
            Console.WriteLine(dataAccess22.GetIncrementingNumber());
            Console.WriteLine("");
            Console.WriteLine("Invoking businessLogic2.GetIncrementingStringAndNumber. This should be \"11 2\" because it's the second time that this method is invoked");
            Console.WriteLine("and businessLogic2 has its own instances of DataAccess1 and DataAccess2");
            Console.WriteLine(businessLogic2.GetIncrementingStringAndNumber());
            Console.WriteLine("");
            Console.WriteLine("Invoking singleton2.GetIncrementingDatetime. This should be 1/4/2000 because it's the fourth time the method is invoked");
            Console.WriteLine(singleton2.GetIncrementingDateTime().ToShortDateString());
            Console.WriteLine("");

            Console.WriteLine("Invoking dataAccess1.GetIncrementingString. This should be \"111\" because it's the second time the method is invoked.");
            Console.WriteLine(dataAccess1.GetIncrementingString());
            Console.WriteLine("");
            Console.WriteLine("Invoking dataAccess2.GetIncrementingNumber. This should be 3 because it's the third time the method is invoked.");
            Console.WriteLine(dataAccess2.GetIncrementingNumber());
            Console.WriteLine("");
            Console.WriteLine("Invoking businessLogic.GetIncrementingStringAndNumber. This should be \"111 3\" because it's the third time that this method is invoked");
            Console.WriteLine("and businessLogic has its own instances of DataAccess1 and DataAccess2");
            Console.WriteLine(businessLogic.GetIncrementingStringAndNumber());
            Console.WriteLine("");
            Console.WriteLine("Invoking singleton.GetIncrementingDatetime. This should be 1/5/2000 because it's the firth time the method is invoked.");
            Console.WriteLine(singleton.GetIncrementingDateTime().ToShortDateString());
        }
    }
}
