using Landeeyo.Cis.MemoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Cis
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Memory management

            #region List initialization

            var listInitialization = new ListInitialization();
            listInitialization.ImproperListInitialization();
            listInitialization.ProperListInitialization();
            Console.ReadKey();

            #endregion

            #endregion


        }
    }
}
