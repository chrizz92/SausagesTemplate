using Sausages;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Sausage> sausages = new List<Sausage>();

            //Todo: Würste erstellen und zur List<Sausage> hinzufügen
            Sausage sausageOne = new Sausage(SausageType.EierWurst, new DateTime(2021, 03, 02), 0.25);
            Sausage sausageTwo = new Sausage(SausageType.ExtraWurst, new DateTime(2020, 12, 24), 0.50);
            Sausage sausageThree = new Sausage(SausageType.LeberKaese, new DateTime(2020, 11, 02), 0.10);
            Sausage sausageFour = new Sausage(SausageType.EierWurst, new DateTime(2022, 08, 03), 0.30);
            sausages.Add(sausageOne);
            sausages.Add(sausageTwo);
            sausages.Add(sausageThree);
            sausages.Add(sausageFour);
            //IComparable bei Sausage implementieren --> dann kann untenstehende Zeile auskommentiert werden
            sausages.Sort();

            //Todo: Würste ausgeben um Sortierung zu prüfen
            foreach (Sausage sausage in sausages)
            {
                Console.WriteLine($"Typ: {sausage.SausageType.ToString(),-12} Gewicht: {sausage.Weight,5:f} ");
            }
        }
    }
}