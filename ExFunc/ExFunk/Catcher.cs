using System;
using System.Collections.Generic;

namespace ExFunk
{
    public class Catcher
    {
        private readonly List<Type> _exceptions = new List<Type>();
        private readonly Func<dynamic> _funk;
        private static Action _action;
        private readonly Dictionary<Type, Func<dynamic, dynamic>> _groupList = new Dictionary<Type, Func<dynamic, dynamic>>();
        
        internal Catcher(Func<dynamic> @try)
        {
            _funk = @try;
        }

        internal Catcher(Action @try)
        {
            _action = @try;
        }

        public Catcher Catch<T>() where T : Exception
        {
            _exceptions.Add(typeof(T));
            return this;
        }

        public Catcher OrCatch<T>() where T : Exception
        {
            _exceptions.Add(typeof(T));
            return this;
        }
        
        public Catcher ThenReturn(Func<dynamic, dynamic> returns)
        {
            foreach (var exception in _exceptions)
            {
                _groupList.Add(exception, returns);
            }
            _exceptions.Clear();
            return this;
        }
        public dynamic Run()
        {
            try
            {
                if (_funk != null)
                    return _funk.Invoke();

                _action.Invoke();
                return null;
            }
            catch (Exception ex)
            {
                foreach (var exceptionItem in _groupList)
                {
                    if (exceptionItem.Key != ex.GetType()) continue;

                    var result = exceptionItem.Value.Invoke(ex);
                    //if (result != null)
                        return result;
                }
                throw;
            }
        }
    }
}
