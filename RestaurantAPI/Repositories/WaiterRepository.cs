using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using RestaurantAPI.Constants;
using System.Data.SqlClient;
using RestaurantAPI.Models;
using RestaurantAPI.Repositories.Interfaces;

namespace RestaurantAPI.Repositories
{
    public class WaiterRepository : IWaiterRepository
    {
        public string _sqlConnectionString;

        public WaiterRepository()
        {
            _sqlConnectionString = ConfigurationManager.ConnectionStrings["RestaurantConnectionString"].ConnectionString;
        }

        public WaiterRepository(string sqlConnectionString)
        {
            this._sqlConnectionString = sqlConnectionString;
        }

        public bool DeleteWaiterByID(int waiterId)
        {
            SqlConnection sqlConnection = null;
            bool successful;

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.DeleteWaiterByID;

            sqlCommand.Parameters.Add(new SqlParameter("@WaiterId", waiterId));

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

        public List<Waiter> GetAllWaiters()
        {
            SqlConnection sqlConnection = null;
            List<Waiter> waiters = new List<Waiter>();

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.GetAllWaiters;


            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while(reader.Read())
                {
                    Waiter waiter = new Waiter();


                    waiters.Add(waiter);
                }
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }

            return waiters;
        }

        public Waiter GetWaiterByID(int waiterId)
        {
            SqlConnection sqlConnection = null;
            Waiter waiter = null;

            sqlConnection = new SqlConnection(_sqlConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = StoredProcedureNames.GetWaiterByID;

            sqlCommand.Parameters.Add(new SqlParameter("@WaiterId", waiterId));

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
               

                while (reader.Read())
                {
                    waiter = new Waiter();

                    waiter.WaiterId = Convert.ToInt32(reader[0]);
                    waiter.FirstName = reader[1].ToString();
                    waiter.LastName = reader[2].ToString();
                    waiter.Login = reader[3].ToString();
                    waiter.Password = reader[4].ToString();
                   
                }
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
            return waiter;
        }

        public bool InsertWaiter(Waiter waiter)
        {
            SqlConnection sqlConnection = null;
            bool successful;

            sqlConnection = new SqlConnection(_sqlConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.InsertWaiter;
            sqlCommand.Connection = sqlConnection;


            sqlCommand.Parameters.Add(new SqlParameter("@FirstName", waiter.FirstName));
            sqlCommand.Parameters.Add(new SqlParameter("@LastName", waiter.LastName));
            sqlCommand.Parameters.Add(new SqlParameter("@Login", waiter.Login));
            sqlCommand.Parameters.Add(new SqlParameter("@Password", waiter.Password));

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

        public bool UpdateWaiter(Waiter waiter)
        {
            SqlConnection sqlConnection = null;
            bool successful;

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = StoredProcedureNames.UpdateWaiter;


            sqlCommand.Parameters.Add(new SqlParameter("@WaiterId", waiter.WaiterId));
            sqlCommand.Parameters.Add(new SqlParameter("@FirstName", waiter.FirstName));
            sqlCommand.Parameters.Add(new SqlParameter("@LastName", waiter.LastName));
            sqlCommand.Parameters.Add(new SqlParameter("@Login", waiter.Login));
            sqlCommand.Parameters.Add(new SqlParameter("@Password", waiter.Password));

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

        public Waiter GetWaiterByUsernameAndPassword(string login, string password)
        {
            SqlConnection sqlConnection = null;
            Waiter waiter = null;

            sqlConnection = new SqlConnection(_sqlConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.GetWaiterByUsernamePassword;
            sqlCommand.Connection = sqlConnection;

            sqlCommand.Parameters.Add(new SqlParameter("@Username", login));
            sqlCommand.Parameters.Add(new SqlParameter("@Password", password));

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                waiter = new Waiter();

                while (reader.Read())
                {
                    waiter.WaiterId = Convert.ToInt32(reader[0]);
                    waiter.FirstName = reader[1].ToString();
                    waiter.LastName = reader[2].ToString();
                    waiter.Login = reader[3].ToString();
                    waiter.Password = reader[4].ToString();
                }
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
            return waiter;
        }
    }
}