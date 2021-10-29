using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoCContainer
{
    public class Container
    {
        private readonly Dictionary<Type, object> _singletons = new Dictionary<Type, object>();
        private readonly Dictionary<Type, Type> _transients = new Dictionary<Type, Type>();

        public string GetSingletonsString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach(var singleton in _singletons)
            {
                stringBuilder.AppendLine(singleton.Value.GetType().ToString());
            }

            return stringBuilder.ToString();
        }

        public string GetTransientsString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var transients in _transients)
            {
                stringBuilder.AppendLine(transients.Value.ToString());
            }

            return stringBuilder.ToString();
        }

        public void Register<TInterface, TClass>(LifeCycleType lifeCycleType = LifeCycleType.Transient) where TClass : TInterface where TInterface : class
        {
            var interfaceType = typeof(TInterface);
            var classType = typeof(TClass);

            if (_transients.TryGetValue(interfaceType, out _)
                || _singletons.TryGetValue(interfaceType, out _))
            {
                throw new InvalidOperationException($"{interfaceType} is already registered.");
            }

            if (classType.IsAbstract)
            {
                throw new InvalidOperationException("Cannot register abstract classes.");
            }

            switch (lifeCycleType)
            {
                case LifeCycleType.Transient:
                    if (!_transients.TryAdd(interfaceType, classType))
                    {
                        throw new InvalidOperationException($"Failed to register {interfaceType}.");
                    }
                    break;
                case LifeCycleType.Singleton:
                    var singleton = Resolve(classType);

                    if (!_singletons.TryAdd(interfaceType, singleton))
                    {
                        throw new InvalidOperationException($"Failed to register {interfaceType}.");
                    }
                    break;
            }
        }

        public TInterface Resolve<TInterface>() where TInterface : class
        {
            var type = typeof(TInterface);
            return (TInterface)Resolve(type);
        }

        private object Resolve(Type type)
        {
            if (_transients.TryGetValue(type, out Type classType))
            {
                return CreateInstance(classType);
            }
            else if (_singletons.TryGetValue(type, out object instance))
            {
                return instance;
            }
            else if (!type.IsAbstract)
            {
                return CreateInstance(type);
            }

            throw new InvalidOperationException("No registration for " + type);
        }

        private object CreateInstance(Type implementationType)
        {
            var constructors = implementationType.GetConstructors();

            if (constructors.Length == 0)
            {
                throw new InvalidOperationException($"No constructors found for {implementationType}");
            }
            else if (constructors.Length > 1)
            {
                throw new InvalidOperationException($"Unable to determine what constructor to use for {implementationType}");
            }

            var constructor = constructors.Single();
            var paramTypes = constructor.GetParameters().Select(p => p.ParameterType);
            var dependencies = paramTypes.Select(Resolve).ToArray();
            return Activator.CreateInstance(implementationType, dependencies);
        }
    }
}
