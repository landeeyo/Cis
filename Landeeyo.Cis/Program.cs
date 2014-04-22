using Landeeyo.Cis.Enumerators;
using Landeeyo.Cis.MemoryManagement;
using Ninject;
using System;

namespace Landeeyo.Cis
{
    class Program
    {
        static void Main(string[] args)
        {
            bool memoryManagement = false;
            bool enumerators = true;

            #region Memory management

            if (memoryManagement)
            {

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
            }

            #endregion

            #region Enumerators

            if (enumerators)
            {
                #region Person custom container

                using (var personContainer = new PersonCustomContainer(5))
                {
                    personContainer.Add(new Person() { Firstname = "William", Surname = "Gibson" });
                    personContainer.Add(new Person() { Firstname = "Arthur C.", Surname = "Clarke" });
                    personContainer.Add(new Person() { Firstname = "Charles", Surname = "Stross" });
                    personContainer.Add(new Person() { Firstname = "Peter", Surname = "Watts" });
                    foreach (Person person in personContainer)
                    {
                        Console.WriteLine(person.Name);
                    }

                    Console.ReadKey();
                }

                Console.WriteLine();

                //Non-standard enumerator
                using (var personContainer = new PersonCustomContainer(5))
                {
                    
                    personContainer.Add(new Person() { Firstname = "William", Surname = "Gibson" });
                    personContainer.Add(new Person() { Firstname = "Arthur C.", Surname = "Clarke" });
                    personContainer.Add(new Person() { Firstname = "Charles", Surname = "Stross" });
                    personContainer.Add(new Person() { Firstname = "Peter", Surname = "Watts" });
                    personContainer.Enumerator = new ReverseEnumerator(personContainer.GetList);

                    foreach (Person person in personContainer)
                    {
                        Console.WriteLine(person.Name);
                    }

                    Console.ReadKey();
                }

                Console.WriteLine();

                #endregion
            }

            #endregion
        }
    }
}
