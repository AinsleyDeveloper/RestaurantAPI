using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using RestaurantAPI.Models;
using RestaurantAPI.Repositories.Interfaces;
using RestaurantAPI.Constants;

namespace RestaurantAPI.Repositories
{
    public class BillRepository : IBillRepository
    {

        public string _sqlConnectionString;

        public BillRepository()
        {
            _sqlConnectionString = ConfigurationManager.ConnectionStrings["RestaurantConnectionString"].ConnectionString;
        }

        public BillRepository(string sqlConnectionString)
        {
            this._sqlConnectionString = sqlConnectionString;
        }

        public bool DeleteBillByID(int billId)
        {
            SqlConnection sqlConnection = null;
            bool successful;

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.DeleteBillByID;

            sqlCommand.Parameters.Add(new SqlParameter("@BillId",billId));

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

        public bool SettleBill(int waiterId, int tableId)
        {
            SqlConnection sqlConnection = null;
            bool successful;

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.SettleBill;

            sqlCommand.Parameters.Add(new SqlParameter("@WaiterId", waiterId));
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

        public List<Bill> GetAllBills()
        {
            SqlConnection sqlConnection = null;
            List<Bill> bills = new List<Bill>();

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.GetAllBills;

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Bill bill = new Bill();
                    var stt = reader[0].ToString();

                    bill.BillId = Convert.ToInt32(reader[0]);
                    bill.ItemId = Convert.ToInt32(reader[1]);
                    bill.TableId = Convert.ToInt32(reader[2]);
                    bill.WaiterId = Convert.ToInt32(reader[3]);
                    bill.PurchaseDate = Convert.ToDateTime(reader[4]);
                    bill.Settled = Convert.ToBoolean(reader[5]);

                    bills.Add(bill);
                }
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
            return bills;
        }

        public Bill GetBillByID(int billId)
        {
            SqlConnection sqlConnection = null;
            Bill bill = null;

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.DeleteBillByID;

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    bill = new Bill();

                    bill.BillId = Convert.ToInt32(reader[0]);
                    bill.ItemId = Convert.ToInt32(reader[1]);
                    bill.TableId = Convert.ToInt32(reader[2]);
                    bill.WaiterId = Convert.ToInt32(reader[3]);
                    bill.PurchaseDate = Convert.ToDateTime(reader[4]);
                    bill.Settled = Convert.ToBoolean(reader[5]);
                }
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }

            return bill;
        }

        public bool InsertBill(Bill bill)
        {
            SqlConnection sqlConnection = null;
            bool successful;

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.InsertBill;

            sqlCommand.Parameters.Add(new SqlParameter("@ItemId", bill.ItemId));
            sqlCommand.Parameters.Add(new SqlParameter("@TableId", bill.TableId));
            sqlCommand.Parameters.Add(new SqlParameter("@WaiterId", bill.WaiterId));
            sqlCommand.Parameters.Add(new SqlParameter("@PurchaseDate", bill.PurchaseDate));

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

        public bool UpdateBill(Bill bill)
        {
            SqlConnection sqlConnection = null;
            bool successful;

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.UpdateBill;

            sqlCommand.Parameters.Add(new SqlParameter("@BillId", bill.BillId));
            sqlCommand.Parameters.Add(new SqlParameter("@ItemId", bill.ItemId));
            sqlCommand.Parameters.Add(new SqlParameter("@TableId", bill.TableId));
            sqlCommand.Parameters.Add(new SqlParameter("@WaiterId", bill.ItemId));
            sqlCommand.Parameters.Add(new SqlParameter("@PurchaseDate", bill.TableId));
            sqlCommand.Parameters.Add(new SqlParameter("@Settled", bill.Settled));

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
    }
}