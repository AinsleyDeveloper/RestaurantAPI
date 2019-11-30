using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using RestaurantAPI.Constants;
using RestaurantAPI.Models;
using RestaurantAPI.Repositories.Interfaces;

namespace RestaurantAPI.Repositories
{
    public class TableRepository : ITableRepository
    {
        public string _sqlConnectionString;

        public TableRepository()
        {
            _sqlConnectionString = ConfigurationManager.ConnectionStrings["RestaurantConnectionString"].ConnectionString;
        }

        public TableRepository(string sqlConnectionString)
        {
            this._sqlConnectionString = sqlConnectionString;
        }

        public bool DeleteTableByID(int tableId)
        {
            SqlConnection sqlConnection = null;
            bool successful;


            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.DeleteTableByID;

            sqlCommand.Parameters.Add(new SqlParameter("@TableId", tableId));

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


        public List<Table> GetAllTables()
        {
            SqlConnection sqlConnection = null;
            List<Table> tables = new List<Table>();

            sqlConnection = new SqlConnection(_sqlConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.GetAllTables;

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Table table = new Table();

                    table.TableId = Convert.ToInt32(reader[0]);
                    table.TableNumber = Convert.ToInt32(reader[1]);
                    table.WaiterId = !String.IsNullOrEmpty(reader[2].ToString()) ? (int?)Convert.ToInt32(reader[2]) : null;
                    table.IsOpen = Convert.ToBoolean(reader[3]);

                    tables.Add(table);
                }

            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
            return tables;
        }

        public Table GetTableByID(int tableId)
        {
            SqlConnection sqlConnection = null;
            Table table = null;

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.GetTableByID;

            sqlCommand.Parameters.Add(new SqlParameter("@TableId", tableId));

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    table = new Table();

                    table.TableId = Convert.ToInt32(reader[0]);
                    table.TableNumber = Convert.ToInt32(reader[1]);
                    table.WaiterId = !String.IsNullOrEmpty(reader[2].ToString()) ? (int?)Convert.ToInt32(reader[2]) : null;
                    table.IsOpen = Convert.ToBoolean(reader[3]);
                }
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
            return table;
        }

        public bool InsertTable(Table table)
        {
            SqlConnection sqlConnection = null;
            bool successful;

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.InsertTable;

            sqlCommand.Parameters.Add(new SqlParameter("@TableId",table.TableId));
            sqlCommand.Parameters.Add(new SqlParameter("@TableNumber",table.TableNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@WaiterId", table.WaiterId));

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

        public bool UpdateTable(Table table)
        {
            SqlConnection sqlConnection = null;
            bool successful;

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.UpdateTable;

            sqlCommand.Parameters.Add(new SqlParameter("@TableId", table.TableId));
            sqlCommand.Parameters.Add(new SqlParameter("@TableNumber", table.TableNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@WaiterId", table.WaiterId ?? Convert.DBNull));
            sqlCommand.Parameters.Add(new SqlParameter("@IsOpen", table.IsOpen));

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

        public List<Table> GetAllTablesAvailableToWaiter(int waiterId)
        {
            SqlConnection sqlConnection = null;
            List<Table> tables = new List<Table>();

            sqlConnection = new SqlConnection(_sqlConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.GetTablesAvailableToWaiter;

            sqlCommand.Parameters.Add(new SqlParameter("@WaiterId", waiterId));

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Table table = new Table();

                    table.TableId = Convert.ToInt32(reader[0]);
                    table.TableNumber = Convert.ToInt32(reader[1]);
                    table.WaiterId = !String.IsNullOrEmpty(reader[2].ToString()) ? (int?)Convert.ToInt32(reader[2]) : null;
                    table.IsOpen = Convert.ToBoolean(reader[3]);
                    tables.Add(table);
                }

            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
            return tables;
        }
    }
}