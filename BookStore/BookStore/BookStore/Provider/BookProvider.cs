using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Provider
{
    public class BookProvider : IBookProvider
    {
        private string connectionString = @"server=LTIN286498\SNEHASERVER2;Initial Catalog=BookStore;User Id=sa;Password=123456;";
        public List<BookDetails> AllBooks()
        {
            List<BookDetails> bList = new List<BookDetails>();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string qCmd = "select * from BookDetails where IsActive=1";
                SqlCommand command = new SqlCommand(qCmd, connection);

                SqlDataReader sqlDataReader = command.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    BookDetails bd = new BookDetails();
                    bd.BookId = (int)sqlDataReader[0];
                    bd.BookName = sqlDataReader[1].ToString();
                    bd.Author = sqlDataReader[2].ToString();
                    bd.Publisher = sqlDataReader[3].ToString();
                    bd.price = (int)sqlDataReader[4];
                    bd.pages = (int)sqlDataReader[5];
                    bd.Category = sqlDataReader[6].ToString();
                    bd.Subcategory = sqlDataReader[7].ToString();
                    bd.AddedBy = sqlDataReader[8].ToString();
                    bd.modifiedBy = sqlDataReader[9].ToString();
                    //bd.isActive = sqlDataReader[10];
                    bd.AddedOn = Convert.ToDateTime(sqlDataReader[11]);
                    bd.LastModifiedOn = Convert.ToDateTime(sqlDataReader[12]);

                    bList.Add(bd);
                }
                connection.Close();
            }

            return bList;
        }

        public BookDetails bookDetails(int id)
        {
           
            BookDetails bd = new BookDetails();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string qCmd = "select * from BookDetails where BookId="+id;
                SqlCommand command = new SqlCommand(qCmd, connection);

                SqlDataReader sqlDataReader = command.ExecuteReader();

                sqlDataReader.Read();
                
                   
                    bd.BookId = (int)sqlDataReader[0];
                    bd.BookName = sqlDataReader[1].ToString();
                    bd.Author = sqlDataReader[2].ToString();
                    bd.Publisher = sqlDataReader[3].ToString();
                    bd.price = (int)sqlDataReader[4];
                    bd.pages = (int)sqlDataReader[5];
                    bd.Category = sqlDataReader[6].ToString();
                    bd.Subcategory = sqlDataReader[7].ToString();
                    bd.AddedBy = sqlDataReader[8].ToString();
                    bd.modifiedBy = sqlDataReader[9].ToString();
                    //bd.isActive = sqlDataReader[10];
                    bd.AddedOn = Convert.ToDateTime(sqlDataReader[11]);
                    bd.LastModifiedOn = Convert.ToDateTime(sqlDataReader[12]);

                connection.Close();
            }

            return bd;
        }
    }
}
