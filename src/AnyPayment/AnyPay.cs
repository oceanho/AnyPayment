using AnyPayment.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyPayment
{
    public abstract class AnyPay : IAnyPay
    {
        private IAnyPayConfigure _anyPayConfigure;

        private SortedList<string, object> _sortList;
        private Dictionary<string, object> _parameters;
        private Dictionary<string, object> _encodedDictionary;

        public AnyPay(string sectionNode)
        {
            _anyPayConfigure = null;// new AnyPayConfigure();

            _sortList = new SortedList<string, object>();
            _parameters = new Dictionary<string, object>();
            _encodedDictionary = new Dictionary<string, object>();
        }
        public AnyPay(IAnyPayConfigure anyPayCongfigure)
        {
            _anyPayConfigure = anyPayCongfigure;
            _parameters = new Dictionary<string, object>();
        }

        protected Dictionary<string, object> Parameters
        {
            get { return _parameters; }
        }

        public IAnyPayConfigure AnyPayConfigure
        {
            get
            {
                return _anyPayConfigure;
            }
        }

        public virtual IAnyPay Add(string key, object value)
        {
            if (_parameters[key] != null)
                Parameters[key] = value;
            else { Parameters.Add(key, value); }
            return this;
        }

        public virtual Dictionary<string, object> GetAll()
        {
            return Parameters;
        }

        public virtual object Get(string key)
        {
            object val = null;
            if (Parameters.TryGetValue(key, out val))
                val = string.Empty;
            return val;
        }


        public virtual void Sort()
        {
            _sortList.Clear();
            foreach (string key in Parameters.Keys)
            {
                _sortList.Add(key, Parameters[key]);
            }
            _parameters.Clear();

            foreach (string key in _sortList.Keys)
            {
                this.Add(key, _sortList[key]);
            }
            _sortList.Clear();
        }

        public virtual void Encode()
        {
            _encodedDictionary.Clear();
            foreach (string key in _parameters.Keys)
            {
                _encodedDictionary.Add(key, StringUtil.Encode(_parameters[key].ToString()));
                //if (encodingEventHandler != null)
                //    _encodedDictionary.Add(key,
                //        encodingEventHandler.Invoke(key, _parameters[key]));
            }            
        }

        public virtual TValue Get<TValue>(string key) where TValue : class
        {
            object val = Get(key);
            if (val != null && val.GetType() == typeof(string) && string.IsNullOrEmpty(val.ToString())) val = null;
            return (TValue)val;
        }
        public virtual IAnyPay Remove(string key)
        {
            Parameters.Remove(key);
            return this;
        }

        public virtual IAnyPay RemoveAll()
        {
            _sortList.Clear();
            _parameters.Clear();
            return this;
        }

        public void Dispose()
        {
            _sortList.Clear();
            _parameters.Clear();
        }
        public System.Collections.IEnumerator GetEnumerator()
        {
            return new AnyPayemtnParameterEnumerator(Parameters);
        }
    }

    internal class AnyPayemtnParameterEnumerator : IEnumerator
    {
        private int _currentIndex = -1;
        private int _currentKvListElementCount = 0;
        private Dictionary<string, object> _kvList;
        public AnyPayemtnParameterEnumerator(Dictionary<string, object> kvList)
        {
            _kvList = kvList;
            _currentKvListElementCount = _kvList.Keys.Count;
        }
        public object Current
        {
            get { return new { Key = 1, Value = 2 }; }
        }

        public bool MoveNext()
        {
            _currentIndex++;
            return _currentKvListElementCount > _currentIndex;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }
    }
}
