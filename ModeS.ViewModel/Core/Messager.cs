using System;
using System.Collections.Generic;

namespace ModeS.ViewModel.Core
{
    public class Messager
    {
        private static readonly Dictionary<string, Action<object>> Dictionary = new Dictionary<string, Action<object>>(); 

        public static void Register(object o, string name, Action<object> action)
        {
            Dictionary.Add(name, action);
        }

        public static void Send(string name, object parameter)
        {
            Dictionary[name].Invoke(parameter);
        }
    }
}