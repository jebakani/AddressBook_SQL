using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AddressBook_Sql
{
    public class AddressBookManager
    {
        public static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=AddressBookService";
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        public int insertIntoTable(ContactDetails details)
        {
            using (sqlConnection)
                try
                {
                    //passing query in terms of stored procedure
                    SqlCommand sqlCommand = new SqlCommand("dbo.InsertIntoAddressBook", sqlConnection);
                    //passing command type as stored procedure
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlConnection.Open();
                    //adding the values to the stored procedure
                    sqlCommand.Parameters.AddWithValue("@firstName", details.firstName);
                    sqlCommand.Parameters.AddWithValue("@lastName", details.lastName);
                    sqlCommand.Parameters.AddWithValue("@address", details.address);
                    sqlCommand.Parameters.AddWithValue("@city", details.city);
                    sqlCommand.Parameters.AddWithValue("@state", details.state);
                    sqlCommand.Parameters.AddWithValue("@zipCode", details.zipCode);
                    sqlCommand.Parameters.AddWithValue("@phoneNumber", details.phoneNumber);
                    sqlCommand.Parameters.AddWithValue("@email", details.emailAddress);
                    int result = sqlCommand.ExecuteNonQuery();
                    //if result is greater than 0 then record is inserted
                    if (result > 0)
                        return 1;
                    else
                        return 0;
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
        }
        public int EditContactDetail(int id,string firstName,long phoneNumber)
        {
            using (sqlConnection)
                try
                {
                    //passing query in terms of stored procedure
                    SqlCommand sqlCommand = new SqlCommand("dbo.EditPhoneNumber", sqlConnection);
                    //passing command type as stored procedure
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlConnection.Open();
                    //adding the values to the stored procedure
                    sqlCommand.Parameters.AddWithValue("@firstName", firstName);
                    sqlCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    int result = sqlCommand.ExecuteNonQuery();
                    //if result is greater than 0 then record is inserted
                    if (result > 0)
                        return 1;
                    else
                        return 0;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
        }
        public int DeletetheRecord(int id, string firstName)
        {
            using (sqlConnection)
                try
                {
                    //passing query in terms of stored procedure
                    SqlCommand sqlCommand = new SqlCommand("dbo.DeleteRecord", sqlConnection);
                    //passing command type as stored procedure
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlConnection.Open();
                    //adding the values to the stored procedure
                    sqlCommand.Parameters.AddWithValue("@firstName", firstName);
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    int result = sqlCommand.ExecuteNonQuery();
                    //if result is greater than 0 then record is inserted
                    if (result > 0)
                        return 1;
                    else
                        return 0;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
        }
        public List<ContactDetails> RetriveData(string state, string city)
        {
            
            //initialize the list to store the retrived data
            List<ContactDetails> detail = new List<ContactDetails>();
            try
            {   
                //passing query in terms of stored procedure
                SqlCommand sqlCommand = new SqlCommand("dbo.RetriveData", sqlConnection);
                //passing command type as stored procedure
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@city", city);
                sqlCommand.Parameters.AddWithValue("@state", state);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                //if it has data
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ContactDetails contact = new ContactDetails();
                        contact.personId= Convert.ToInt32(reader["personId"]);
                        contact.firstName = reader.GetString(1);
                        contact.lastName = reader.GetString(2);
                        contact.address = reader.GetString(3);
                        contact.city = reader.GetString(4);
                        contact.state = reader.GetString(5);
                        contact.zipCode = reader.GetInt64(6);
                        contact.phoneNumber = reader.GetInt64(7);
                        contact.emailAddress = reader.GetString(8);
                        detail.Add(contact);
                    }
                }
                reader.Close();
                return detail;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public ContactDetails ReadData(ContactDetails contactDetails)
        {
            contactDetails.firstName = "jerry";
            contactDetails.lastName = "kevin";
            contactDetails.address = "east street";
            contactDetails.city = "chennai";
            contactDetails.state = "Tamil Nadu";
            contactDetails.zipCode = 623546;
            contactDetails.phoneNumber = 8654239564;
            contactDetails.emailAddress = "jerryk@gamil.com";
            return contactDetails;
        }
    }
}
