using System;
using NUnit.Framework;
using NUnit.VisualStudio.TestAdapter;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using Lesson3;

namespace Lesson4
{
    [TestFixture]
    public class NUnitTestBank
    {
        [Test]
        public void NIsInstanceOfClientTest()
        {
           //var comp= new CompareFirstName();
            var client = new Client();
            //Assert.IsInstanceOf<Client>((object)client);
            Assert.IsInstanceOf(typeof(Client),(object)client);
        }

        [Test]
        public void NIsIClientISortIFinderTest()
        {
            var client = new Client();
            Assert.IsTrue((client as IClient) ==client);
            Assert.IsTrue((client as ISort) ==client);
            Assert.IsTrue((client as IFinder) == client);
        }
        [Test]
        public void NRegexTest()
        {           
            Assert.IsTrue(Program.reg1.IsMatch("+380 11 111 11 11"));
            Assert.IsTrue(Program.reg2.IsMatch("AA 111111"));
        }
        
        [Test]
        public void NIsNotEmptyLSTest()
        {
            Assert.IsNotEmpty(Program.ls);        
        } 
        
        [Test]
        public void NAreEqualCompareFirstNameTest()
        {
            var comp_Name = new CompareFirstName();
            int comp = comp_Name.Compare(Program.ls[0], Program.ls[0]);
            int comp2 = comp_Name.Compare(Program.ls[0], Program.ls[1]);
            Assert.AreEqual(comp,0);
            Assert.AreNotEqual(comp2, -1);
        }
        [Test]
        public void NAreNotEqualCompareDataBornTest()
        {
            var comp_Data = new CompareDataBorn();
            int comp = comp_Data.Compare(Program.ls[0], Program.ls[0]);
            int comp2 = comp_Data.Compare(Program.ls[0], Program.ls[1]);
            Assert.AreEqual(comp, 0);
            Assert.AreEqual(comp2, -1);
            

        }
        [Test]
        public void NAreNotEqualCompareNumberPhoneTest()
        {
            var comp_Number = new CompareNumberPhone();
            int comp = comp_Number.Compare(Program.ls[0], Program.ls[0]);
            int comp2 = comp_Number.Compare(Program.ls[0], Program.ls[1]);
            Assert.AreEqual(comp, 0);
            Assert.AreEqual(comp2, -1);
        } 
        [Test]
         public void NFinderNameNumberDataTest()
        {
            var client = new Client();

            IFinder clientFinder = client;
            string finderName = "", finderNumber = "", finderData = "";

            clientFinder.FindBySubstringFirstName(Program.ls, "ek", out finderName);
            clientFinder.FindBySubstringNumberPhone(Program.ls, 016, out finderNumber);
            clientFinder.FindBySubstringDataBorn(Program.ls, "29", out finderData);

            Assert.IsNotNull(finderName);
            Assert.IsNotNull(finderNumber);
            Assert.IsNotNull(finderData);
             
        } 
              
    }
}
