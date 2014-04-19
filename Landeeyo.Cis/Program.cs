using Landeeyo.Cis.MemoryManagement;
using Ninject;
using System;

namespace Landeeyo.Cis
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Memory management

            #region List initialization

            using (var kernel = new StandardKernel())
            {
                kernel.Bind<ListInitialization>().ToSelf();

                var listInitialization = kernel.Get<ListInitialization>();
                listInitialization.ImproperListInitialization();
                listInitialization.ProperListInitialization();
                Console.ReadKey();
            }

            #endregion

            #endregion
        }
    }
}
