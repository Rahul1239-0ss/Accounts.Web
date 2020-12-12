using Accounts.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Accounts.Web.DBOperations
{
    public class DBOperations
    {
        private SqlConnection con;

        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Account details    
        public bool AddAccountHolder(AccountsModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddAccountDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@AccountNumber", obj.AccountNumber);
            com.Parameters.AddWithValue("@AccountHolder", obj.AccountHolder);
            com.Parameters.AddWithValue("@CurrentBalance", obj.CurrentBalance);
            com.Parameters.AddWithValue("@BankName", obj.BankName);
            com.Parameters.AddWithValue("@OpeningDate", obj.OpeningDate);
            com.Parameters.AddWithValue("@IsActive", obj.IsActive);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        //To view Account details with generic list     
        public List<AccountsModel> GetAllAccountHolders()
        {
            connection();
            List<AccountsModel> EmpList = new List<AccountsModel>();


            SqlCommand com = new SqlCommand("GetAccountDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind AccountsModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                EmpList.Add(

                    new AccountsModel
                    {

                        AccountNumber = Convert.ToInt32(dr["AccountNumber"]),
                        AccountHolder = Convert.ToString(dr["AccountHolder"]),
                        CurrentBalance = Convert.ToDecimal(dr["CurrentBalance"]),
                        BankName = Convert.ToString(dr["BankName"]),
                        OpeningDate = Convert.ToString(dr["OpeningDate"]),
                        IsActive = Convert.ToBoolean(dr["IsActive"])

                    }
                    );
            }

            return EmpList;
        }
        //To Update Account Holders details    
        public bool UpdateAccountHolders(AccountsModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateAccountDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@AccountNumber", obj.AccountNumber);
            com.Parameters.AddWithValue("@AccountHolder", obj.AccountHolder);
            com.Parameters.AddWithValue("@CurrentBalance", obj.CurrentBalance);
            com.Parameters.AddWithValue("@BankName", obj.BankName);
            com.Parameters.AddWithValue("@OpeningDate", obj.OpeningDate);
            com.Parameters.AddWithValue("@IsActive", obj.IsActive);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        //To delete Account details    
        public bool DeleteAccountHolder(int accountnumber)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteAccountNumber", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@AccountNumber", accountnumber);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        public List<AccountsModel> getAllAccountNumbers()
        {
            connection();
            List<AccountsModel> EmpList = new List<AccountsModel>();


            SqlCommand com = new SqlCommand("GetAccountNumbers", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind AccountsModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                EmpList.Add(

                    new AccountsModel
                    {
                        AccountNumber = Convert.ToInt32(dr["AccountNumber"])
                    }
                    );
            }

            return EmpList;
        }
    }
}

   