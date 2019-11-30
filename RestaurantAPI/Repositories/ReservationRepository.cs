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
    public class ReservationRepository : IReservationRepository
    {
        public string _sqlConnectionString;

        public ReservationRepository()
        {
            _sqlConnectionString = ConfigurationManager.ConnectionStrings["RestaurantConnectionString"].ConnectionString;
        }

        public ReservationRepository(string sqlConnectionString)
        {
            this._sqlConnectionString = sqlConnectionString;
        }

        public bool DeleteReservationByID(int reservationId)
        {
            SqlConnection sqlConnection = null;
            bool successful;

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.DeleteReservationByID;

            sqlCommand.Parameters.Add(new SqlParameter("@ReservationId", reservationId));

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

        public List<Reservation> GetAllReservations()
        {
            SqlConnection sqlConnection = null;
            List<Reservation> reservations = new List<Reservation>();

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.GetAllReservations;

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Reservation reservation = new Reservation();

                    reservation.ReservationId = Convert.ToInt32(reader[0]);
                    reservation.CustomerFirstName = reader[1].ToString();
                    reservation.CustomerLastName = reader[2].ToString();
                    reservation.CellNumber = reader[3].ToString();
                    reservation.DateTime = Convert.ToDateTime(reader[4]);
                    reservation.TableId = Convert.ToInt32(reader[5]);

                    reservations.Add(reservation);
                }
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();

            }

            return reservations;
        }

        public Reservation GetReservationByID(int reservationId)
        {
            SqlConnection sqlConnection = null;
            Reservation reservation = null;

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.GetItemByID;

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    reservation = new Reservation();

                    reservation.ReservationId = Convert.ToInt32(reader[0]);
                    reservation.CustomerFirstName = reader[1].ToString();
                    reservation.CustomerLastName = reader[2].ToString();
                    reservation.CellNumber = reader[3].ToString();
                    reservation.DateTime = Convert.ToDateTime(reader[4]);
                    reservation.TableId = Convert.ToInt32(reader[5]);
                }  
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
            return reservation ;
        }

        public bool InsertReservation(Reservation reservation)
        {
            SqlConnection sqlConnection = null;
            bool successful;

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.InsertReservation;

            sqlCommand.Parameters.Add(new SqlParameter("@TableId", reservation.TableId));
            sqlCommand.Parameters.Add(new SqlParameter("@FirstName", reservation.CustomerFirstName));
            sqlCommand.Parameters.Add(new SqlParameter("@LastName", reservation.CustomerLastName));
            sqlCommand.Parameters.Add(new SqlParameter("@CellNumber", reservation.CellNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@Date", reservation.DateTime));

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

        public bool UpdateReservation(Reservation reservation)
        {
            SqlConnection sqlConnection = null;
            bool successful;

            sqlConnection = new SqlConnection(_sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoredProcedureNames.UpdateReservation;

            sqlCommand.Parameters.Add(new SqlParameter("@ReservationId", reservation.ReservationId));
            sqlCommand.Parameters.Add(new SqlParameter("@CustomerFirstName", reservation.CustomerFirstName));
            sqlCommand.Parameters.Add(new SqlParameter("@CustomerLastName", reservation.CustomerLastName));
            sqlCommand.Parameters.Add(new SqlParameter("@CellNumber", reservation.CellNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@DateTime", reservation.DateTime));

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