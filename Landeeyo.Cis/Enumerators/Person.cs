using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Cis.Enumerators
{
    public class Person
    {
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Name { get { return string.Format("{0} {1}", Surname, Firstname); } }
    }
}
