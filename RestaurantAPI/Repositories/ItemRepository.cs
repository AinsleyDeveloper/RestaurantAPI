using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using RestaurantAPI.Constants;
using RestaurantAPI.Models;
using RestaurantAPI.Repositories.Interfaces;

namespace RestaurantAPI.Repositories
{
    public class ItemRepository : IItemRepository
    { 
      public string _sqlConnectionString;

    public ItemRepository()
    {
        _sqlConnectionString = ConfigurationManager.ConnectionStrings["RestaurantConnectionString"].ConnectionString;
    }

    public ItemRepository(string sqlConnectionString)
    {
        this._sqlConnectionString = sqlConnectionString;
    }


    public bool DeleteItemByID(int itemId)
        {
            SqlConnection sqlConnection = null;
            bool successful;

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = StoredProcedureNames.DeleteItemByID;

            sqlCommand.Parameters.Add(new SqlParameter("@ItemId", itemId));

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                successful = true;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }

            return successful;
        }

        public List<Item> GetAllItems()
        {
            SqlConnection sqlConnection = null;
            List<Item> items = new List<Item>();

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.GetAllItems;

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while(reader.Read())
                {
                    Item item = new Item();

                    item.ItemId = Convert.ToInt32(reader[0]);
                    item.Name = reader[1].ToString();
                    item.Description = reader[2].ToString();
                    item.Price = Convert.ToDecimal(reader[3]);

                    items.Add(item);
                }
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                sqlConnection.Close();

            }

            return items;
        }

        public Item GetItemByID(int itemId)
        {
            SqlConnection sqlConnection = null;
            Item item = null;

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = StoredProcedureNames.GetItemByID;

            sqlCommand.Parameters.Add(new SqlParameter("@ItemId", itemId));

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    

                    item.ItemId = Convert.ToInt32(reader[0]);
                    item.Name = reader[1].ToString();
                    item.Description = reader[2].ToString();
                    item.Price = Convert.ToDecimal(reader[3]);
                }
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                sqlConnection.Close();
            }
            return item;
        }

        public bool InsertItem(Item item)
        {
            SqlConnection sqlConnection = null;
            bool successful;

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = StoredProcedureNames.InsertItem;

            sqlCommand.Parameters.Add(new SqlParameter("@ItemId", item.ItemId));
            sqlCommand.Parameters.Add(new SqlParameter("@ItemName", item.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@ItemDescription", item.Description));
            sqlCommand.Parameters.Add(new SqlParameter("@ItemPrice", item.Price));

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                successful = true;

            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                sqlConnection.Open();
            }
            return successful;
        }

        public bool UpdateItem(Item item)
        {
            SqlConnection sqlConnection = null;
            bool successful;

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = StoredProcedureNames.UpdateItem;

            sqlCommand.Parameters.Add(new SqlParameter("@ItemId", item.ItemId));
            sqlCommand.Parameters.Add(new SqlParameter("@ItemName", item.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@ItemDescription", item.Description));
            sqlCommand.Parameters.Add(new SqlParameter("@ItemPrice", item.Price));

            try
            {
                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                successful = true;

            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
            return successful;
        }

        public List<Item> GetTableItems(int waiterId, int tableId)
        {
            SqlConnection sqlConnection = null;
            List<Item> items = new List<Item>();

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.GetTableItems;

            sqlCommand.Parameters.Add(new SqlParameter("@WaiterId", waiterId));
            sqlCommand.Parameters.Add(new SqlParameter("@TableId", tableId));

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Item item = new Item();

                    item.ItemId = Convert.ToInt32(reader[0]);
                    item.Name = reader[1].ToString();
                    item.Description = reader[2].ToString();
                    item.Price = Convert.ToDecimal(reader[3]);

                    items.Add(item);
                }
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();

            }

            return items;
        }
    }
}