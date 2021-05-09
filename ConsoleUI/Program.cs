using Business.Concrete;
using Core.Utilities.Helpers;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            TerritoryManager territoryManager1 = new TerritoryManager(new EfTerritoryDal());
            var result1 = territoryManager1.Add(new Territory { RegionId = 4, TerritoryId = "44556", TerritoryDescription = "Atlanta" });
            Thread.Sleep(1000);
            var result2 = territoryManager1.Get(t => t.TerritoryId == "44556");

            if (result1.Success)
            {
                Console.WriteLine("\n---------------------------------");
                Console.WriteLine("\n---Add operasyonu ile ilgili---");
                Console.WriteLine(result1.Message);
                Console.WriteLine("\n---------------------------------");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine(result1.Message);
                Thread.Sleep(2000);
            }

            if (result2.Success)
            {

                Console.WriteLine("\n---Get operasyonu ile ilgili---");
                Console.WriteLine("\nAlan Açıklaması: " + result2.Data.TerritoryDescription);
                Thread.Sleep(2000);
                Console.WriteLine("\n" + result2.Message);
                Console.WriteLine("\n---------------------------------");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("\n---------------------------------");
                Console.WriteLine("\n---Get operasyonu ile ilgili---");
                Console.WriteLine(result2.Message);
                Console.WriteLine("\n---------------------------------");
                Thread.Sleep(2000);
            }
        }
    }
}
