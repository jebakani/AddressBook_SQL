using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBook_Sql;
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

    }
}
