using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Cis.Enumerators
{
    public class ReverseEnumerator : IEnumerator
    {
        private IList _list;
        private int _position;

        public ReverseEnumerator(IList list)
        {
            _list = list;
            _position = list.Count;
        }

        public object Current
        {
            get { return _list[_position]; }
        }

        public bool MoveNext()
        {
            if (_position - 1 >= 0)
            {
                _position--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _position = _list.Count;
        }
    }
}
