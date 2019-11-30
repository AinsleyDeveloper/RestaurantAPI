using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantAPI.Constants
{
    public static class StoredProcedureNames
    {
        #region Bill Stored Procedures
        public static string DeleteBillByID = "DeleteBillByID";
        public static string SettleBill = "SettleBill";
        public static string InsertBill = "InsertBill";
        public static string UpdateBill = "UpdateBill";
        public static string GetAllBills = "SelectAllFromBill";
        public static string GetBillByID = "GetBillByID";
        #endregion

        #region Item Stored Procedures
        public static string DeleteItemByID = "DeleteItemByID";
        public static string InsertItem = "InsertItem";
        public static string UpdateItem = "UpdateItem";
        public static string GetAllItems = "SelectAllFromItems";
        public static string GetTableItems = "GetTableItems";
        public static string GetItemByID = "GetItemByID";
        #endregion

        #region Waiter Stored Procedures
        public static string DeleteWaiterByID = "DeleteWaiterByID";
        public static string InsertWaiter = "InsertWaiter";
        public static string UpdateWaiter = "UpdateWaiter";
        public static string GetAllWaiters = "GetAllWaiters";
        public static string GetWaiterByID = "GetWaiterByID";
        public static string GetWaiterByUsernamePassword = "GetWaiterByUsernameAndPassword";
        #endregion

        #region Table Stored Procedures
        public static string DeleteTableByID = "DeleteTableByID";
        public static string InsertTable = "InsertTable";
        public static string UpdateTable = "UpdateTable";
        public static string GetAllTables = "SelectAllFromTables";
        public static string GetTableByID = "GetTableByID";
        public static string GetTablesAvailableToWaiter = "GetTablesAvailableToWaiter";
        #endregion

        #region Reservation Stored Procedures
        public static string DeleteReservationByID = "DeleteReservationByID";
        public static string InsertReservation = "InsertReservation";
        public static string UpdateReservation = "UpdateReservation";
        public static string GetAllReservations = "SelectAllFromReservations";
        public static string GetReservationByID = "GetReservationByID";
        #endregion
    }
}