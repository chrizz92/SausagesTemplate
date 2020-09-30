using System;
using Sausages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Timers;

namespace SausageTest
{
    /// <summary>
    ///Dies ist eine Testklasse für "WurstTest" und soll
    ///alle WurstTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class SausageListTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Ruft den Testkontext auf, der Informationen
        ///über und Funktionalität für den aktuellen Testlauf bietet, oder legt diesen fest.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Zusätzliche Testattribute

        //
        //Sie können beim Verfassen Ihrer Tests die folgenden zusätzlichen Attribute verwenden:
        //
        //Mit ClassInitialize führen Sie Code aus, bevor Sie den ersten Test in der Klasse ausführen.
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Mit ClassCleanup führen Sie Code aus, nachdem alle Tests in einer Klasse ausgeführt wurden.
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen.
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion Zusätzliche Testattribute

        /// <summary>
        ///Ein Test für "op_Addition"
        ///</summary>
        [TestMethod()]
        public void T01_Sausage_Plus()
        {
            Sausage a = new Sausage(SausageType.LeberKaese, DateTime.Now.AddDays(1), 0.1);
            Sausage b = new Sausage(SausageType.EierWurst, DateTime.Now.AddDays(2), 0.1);
            Sausage c = new Sausage(SausageType.EierWurst, DateTime.Now.AddDays(2), 0.3);
            Sausage d = new Sausage(SausageType.ExtraWurst, DateTime.Now.AddDays(2), 0.4);
            Sausage result = a + b;
            Assert.AreEqual(DateTime.Now.AddDays(1).ToShortTimeString(), result.DateOfExpiry.ToShortTimeString(), "Ablaufdatum stimmt nicht");
            Assert.AreEqual(SausageType.LeberKaese, result.SausageType);
            Assert.AreEqual(0.2, result.Weight, 0.000000001);
            result = b + c;
            Assert.AreEqual(SausageType.EierWurst, result.SausageType);
            Assert.AreEqual(0.4, result.Weight, 0.000000001);
            result = c + d;
            Assert.AreEqual(SausageType.Faschiertes, result.SausageType);
            Assert.AreEqual(0.7, result.Weight, 0.000000001);
        }

        /// <summary>
        /// Ein Test für "Add" in Liste
        /// </summary>
        [TestMethod()]
        public void T02_SausageListAdd()
        {
            Sausage sausageA, sausageB, sausageC, sausageD;
            SausageList list = new SausageList();
            sausageA = new Sausage(SausageType.EierWurst, DateTime.Now.AddDays(1), 0.2);
            sausageB = new Sausage(SausageType.ExtraWurst, DateTime.Now.AddDays(12), 0.5);
            sausageC = new Sausage(SausageType.LeberKaese, DateTime.Now.AddDays(3), 0.3);
            sausageD = new Sausage(SausageType.EierWurst, DateTime.Now.AddDays(10), 0.4);
            list.Add(sausageA);
            Assert.AreEqual(1, list.Count, "Count zählt nicht richtig");
            Assert.AreEqual(sausageA.Weight, list.WeightOfAllSausages, 0.000000001, "Gesamtgweicht stimmt nicht");
            list.Add(sausageB);
            Assert.AreEqual(2, list.Count, "Count zählt nicht richtig");
            Assert.AreEqual(0.7, list.WeightOfAllSausages, 0.000000001, "Gesamtgewicht Addition funktioniert nicht richtig");
            list.Add(sausageC);
            Assert.AreEqual(3, list.Count, "Count zählt nicht richtig");
            Assert.AreEqual(1, list.WeightOfAllSausages, 0.000000001, "Gesamtgewicht Addition funktioniert nicht richtig");
            Assert.AreEqual(SausageType.ExtraWurst, list[0].SausageType, "Position wurde falsch übergeben");
            Assert.AreEqual(SausageType.LeberKaese, list[1].SausageType, "Position wurde falsch übergeben");
            Assert.AreEqual(SausageType.EierWurst, list[2].SausageType, "Position wurde falsch übergeben");
            list.Add(sausageD);
            Assert.AreEqual(4, list.Count, "Count zählt nicht richtig");
            Assert.AreEqual(1.4, list.WeightOfAllSausages, 0.000000001, "Gesamtgewicht aller Würste funktioniert nicht richtig");
            Assert.AreEqual(0.4, list[3].Weight, 0.000000001, "Position zweite Eierwurst wurde falsch übergeben");
        }

        /// <summary>
        /// Ein Test für "Add" in Liste
        /// </summary>
        [TestMethod()]
        public void T03_Remove()
        {
            Sausage sausageA, sausageB, sausageC, sausageD;
            SausageList list = new SausageList();
            sausageA = new Sausage(SausageType.EierWurst, DateTime.Now.AddDays(1), 0.2);
            sausageB = new Sausage(SausageType.ExtraWurst, DateTime.Now.AddDays(12), 0.5);
            sausageC = new Sausage(SausageType.LeberKaese, DateTime.Now.AddDays(3), 0.3);
            sausageD = new Sausage(SausageType.EierWurst, DateTime.Now.AddDays(10), 0.4);
            list.Add(sausageA);
            list.Add(sausageB);
            list.Add(sausageC);
            list.Add(sausageD);
            Assert.AreEqual(4, list.Count, "Count zählt nicht richtig");
            Assert.AreEqual(1.4, list.WeightOfAllSausages, 0.000000001, "Gesamtgewicht aller Würste funktioniert nicht richtig");
            int position = list.GetPos(sausageB);
            Assert.AreEqual(0, position);
            list.RemoveSausageOnPosition(position);
            Assert.AreEqual(0.9, list.WeightOfAllSausages, 0.0001, "Um 0,5 kg leichter");
            Assert.AreEqual(3, list.Count);
            position = list.GetPos(sausageB);
            Assert.AreEqual(-1, position, "SausageB ist nicht mehr in der Liste");
            Sausage expected = list[SausageType.ExtraWurst];
            Assert.IsNull(expected, "Keine Extrawurst mehr");
        }

        /// <summary>
        /// Ein Test für "SchneideAb"
        /// </summary>
        [TestMethod()]
        public void T04_CutFromSausage()
        {
            Sausage sausageA, sausageB, sausageC, sausageD;
            SausageList list = new SausageList();
            sausageA = new Sausage(SausageType.EierWurst, DateTime.Now.AddDays(1), 0.2);
            sausageB = new Sausage(SausageType.ExtraWurst, DateTime.Now.AddDays(12), 0.5);
            sausageC = new Sausage(SausageType.LeberKaese, DateTime.Now.AddDays(3), 0.3);
            sausageD = new Sausage(SausageType.EierWurst, DateTime.Now.AddDays(10), 0.5);
            Sausage sausageExpected;
            list.Add(sausageA);
            list.Add(sausageB);
            list.Add(sausageC);
            list.Add(sausageD);
            Sausage givenSausage = list.CutFromSausage(SausageType.EierWurst, 0.1);
            Assert.AreEqual(4, list.Count, "Einfacher Cut falsch berechnet(0.1 von sausageA übrig");
            sausageExpected = list[SausageType.EierWurst];
            Assert.AreSame(sausageA, sausageExpected, "Eierwurst A ist noch nicht verbraucht");
            Assert.AreEqual(1.4, list.WeightOfAllSausages, 0.000000001, "10 Deka fehlen jetzt");
            givenSausage = list.CutFromSausage(SausageType.EierWurst, 0.3);
            Assert.AreEqual(3, list.Count, "Eine Eierwurst ist nun verbraucht");
            Assert.AreEqual(1.1, list.WeightOfAllSausages, 0.0001, "zweite Wurst angeschnitten");
            givenSausage = list.CutFromSausage(SausageType.EierWurst, 0.8);
            Assert.AreEqual(2, list.Count, "Zweite Eierwurst ist nun auch verbraucht");
            Assert.AreEqual(0.8, list.WeightOfAllSausages, 0.0001, "restliche zwei Würste");
            Assert.AreEqual(0.3, givenSausage.Weight, 0.001);
            givenSausage = list.CutFromSausage(SausageType.EierWurst, 0.3);
            Assert.IsNull(givenSausage, "keine Eierwurst mehr vorhanden");
        }
    }
}