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
        //UC2-Retriving the data in the record and checking the data
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
            List<ContactDetails> list = addressBookManager.RetriveData(state,city);
            foreach(var l in list)
            {
                actual += "" + l.firstName + " ";
            }
            //assert
            Assert.AreEqual(expected, actual);
        }

    }
}
