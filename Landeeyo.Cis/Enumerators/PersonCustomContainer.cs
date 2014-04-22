using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Cis.Enumerators
{
    public class PersonCustomContainer : IEnumerable, IEnumerator, IDisposable
    {
        private List<Person> _people;
        private int _position;
        private readonly int _positionDefault = -1;
        private bool _disposed = false;
        private IEnumerator _enumerator;
        public IEnumerator Enumerator { set { _enumerator = value; } }
        public List<Person> GetList { get { return _people; } }

        public PersonCustomContainer(int size = 0)
        {
            _people = new List<Person>(size);
            _position = _positionDefault;
            _enumerator = (IEnumerator)this;
        }

        #region Partly implemented list interface

        public void Add(Person value)
        {
            _people.Add(value);
        }

        public void Clear()
        {
            _people.Clear();
        }

        public void Remove(Person value)
        {
            _people.Remove(value);
        }

        public int Count
        {
            get { return _people.Count; }
        }

        #endregion

        public IEnumerator GetEnumerator()
        {
            return _enumerator;
        }

        #region IEnumerator

        public object Current
        {
            get { return _people[_position]; }
        }

        public bool MoveNext()
        {
            if (_position + 1 < _people.Count)
            {
                _position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _position = _positionDefault;
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                // if this is a dispose call dispose on all state you
                // hold, and take yourself off the Finalization queue.
                if (disposing)
                {
                    if (_people != null)
                    {
                        _people = null;
                    }
                }

                _disposed = true;
            }
        }

        #endregion
    }
}
