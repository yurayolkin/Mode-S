using System;
using System.Collections.Generic;

namespace ModeS.ViewModel.ServiceLocator
{
   
}    public sealed class ServiceLoactor
    {
        private static Dictionary<Type, Type> _services = new Dictionary<Type, Type>();

        public static void Register<T, TY>()
        {
            _services.Add(typeof(T), typeof(TY));
        }

        public static void Register<T>()
        {
            _services.Add(typeof(T), typeof(T));
        }

        public static T Resolve<T>()
        {
            return (T) Activator.CreateInstance(_services[typeof (T)]);
        }
    }