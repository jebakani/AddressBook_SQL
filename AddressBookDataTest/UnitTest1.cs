using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBook_Sql;
using System.Collections.Generic;

namespace AddressBookDataTest
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookManager addressBookManager;
        [TestInitialize]
        public void SetUp()
        {
            addressBookManager = new AddressBookManager();
        }
        //UC1-Inserting the data into the record and checking the data
        [TestMethod]
        public void InsertionOfRecordTest()
        {
            //assign 
            int expected = 1;
            ContactDetails contactDetails = new ContactDetails();
            contactDetails = addressBookManager.ReadData(contactDetails);
            //act
            int actual = addressBookManager.insertIntoTable(contactDetails);
            //assert
            Assert.AreEqual(expected, actual);
        }
        //UC2-Editing the data in the record and checking the data
        [TestMethod]
        public void EditingTheRecordTest()
        {
            //assign 
            int expected = 1;
            //act
            int actual = addressBookManager.EditContactDetail(5,"harry",7373377956);
            //assert
            Assert.AreEqual(expected, actual);
        }
        //UC2-Deleting the data in the record and checking the data
        [TestMethod]
        public void DeletingTheRecordTest()
        {
            //assign 
            int expected = 1;
            string name = "jerry";
            int id = 8;
            //act
            int actual = addressBookManager.DeletetheRecord(id, name);
            //assert
            Assert.AreEqual(expected, actual);
        }
        //UC7-Retriving the data in the record and checking the data
        [TestMethod]
        public void RetrivingTheRecordTest()
        {
            //assign 
            string expected = "Stephan harry ";
            string actual = "";
            //assign state and city
            string state = "Kerala";
            string city = "madurai";
            //act
            List<ContactDetails> list = addressBookManager.RetriveData(state,city, "@city", "@state", "dbo.RetriveData");
            foreach(var l in list)
            {
                actual += "" + l.firstName + " ";
            }
            //assert
            Assert.AreEqual(expected, actual);
        }
        //UC8-Retriving record in sorted order
        [TestMethod]
        public void RetrivingTheSortedRecordTest()
        {
            //assign 
            string expected = "harry jerry Jessi Jessi Stephan stuart ";
            string actual = "";
            //act
            List<ContactDetails> list = addressBookManager.RetriveDataSorted("dbo.RetriveDataSorted");
            foreach (var l in list)
            {
                actual += "" + l.firstName + " ";
            }
            //assert
            Assert.AreEqual(expected, actual);
        }
        //UC9-Retriving the data in the record and checking the data
        [TestMethod]
        public void RetrivingTheRecordTestBasedOnType()
        {
            //assign 
            string expected = "stuart Jessi ";
            string actual = "";
            //assign state and city
            string type = "friend";
            string addressBookaname = "TVS";
            //act
            List<ContactDetails> list = addressBookManager.RetriveData(type, addressBookaname,"@type", "@addressName", "dbo.RetriveDataType");
            foreach (var l in list)
            {
                actual += "" + l.firstName + " ";
            }
            //assert
            Assert.AreEqual(expected, actual);
        }
        //UC9-Inserting the data into the record and checking the data
        [TestMethod]
        public void InsertionOfDuplicateRecordTest1()
        {
            //assign 
            int expected = 1;
            ContactDetails contactDetails = new ContactDetails();
            contactDetails = addressBookManager.ReadData(contactDetails);
            //act
            int actual = addressBookManager.insertIntoTableDuplicate(contactDetails);
            //assert
            Assert.AreEqual(expected, actual);
        }

    }
}
