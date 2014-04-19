using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Cis.MemoryManagement
{
    /// <summary>
    /// This example shows important property of list initialization and memory allocation.
    /// Default list initialization gives list with 0 elements allocated. During executing
    /// IList Add method available memory is shrinking. When next Add isn't possible due to
    /// insufficient allocated memory size list is resized, allocated memory is doubled.
    /// When we know how much objects we'll store in list (even roughly) we can save much
    /// time by allocating bigger than default size of memory at the beginning.
    /// </summary>
    public class ListInitialization
    {
        public void ImproperListInitialization()
        {
            var list = new List<int>();
            Console.WriteLine("Initial capacity: {0}", list.Capacity);
            TestListInitialization(list);
        }

        public void ProperListInitialization()
        {
            var list = new List<int>(1024);
            Console.WriteLine("Initial capacity: {0}", list.Capacity);
            TestListInitialization(list);
        }

        private static void TestListInitialization(List<int> list)
        {
            Console.WriteLine("List filling begins...");
            var oldCapacity = list.Capacity;
            var random = new Random();
            var resizeCount = 0;
            for (int i = 0; i < 1024; i++)
            {
                list.Add(random.Next(1024));
                if (oldCapacity != list.Capacity)
                {
                    Console.WriteLine("List has changed it's size from {0} to {1} at {2} iteration", oldCapacity, list.Capacity, i);
                    oldCapacity = list.Capacity;
                    resizeCount++;
                }
            }
            Console.WriteLine("List has been filled with 1024 random integers and {0} memory reallocations", resizeCount);
            Console.WriteLine();
        }
    }
}
