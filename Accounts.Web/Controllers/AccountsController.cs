using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Accounts.Web.DBOperations;
using Accounts.Web.Models;

namespace Accounts.Web.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Account/AccountHoldersDetails    
        public ActionResult GetAllAccountHoldersDetails()
        {

            Accounts.Web.DBOperations.DBOperations EmpRepo = new Accounts.Web.DBOperations.DBOperations();
            ModelState.Clear();
            return View(EmpRepo.GetAllAccountHolders());
        }


        // GET: Account/AddEmployee    
        public ActionResult AddAccountDetails()
        {
            return View();
        }
       



        // POST: Account/AddAccountHolder 
        [HttpPost]
        public ActionResult AddAccountDetails(AccountsModel Account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Accounts.Web.DBOperations.DBOperations AccountHolder = new Accounts.Web.DBOperations.DBOperations();

                    var count = AccountHolder.getAllAccountNumbers().Where(x=>x.AccountNumber== Account.AccountNumber);
                    if (count != null)
                    {
                        ViewBag.Message = "Account Already Existed!, Please check Account Number";
                    }
                    else
                    {
                        if (AccountHolder.AddAccountHolder(Account))
                        {
                            ViewBag.Message = "Account details added successfully";
                        }
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // update:    
        public ActionResult EditAccountDetails(int id)
        {
            Accounts.Web.DBOperations.DBOperations EmpRepo = new Accounts.Web.DBOperations.DBOperations();

            return View(EmpRepo.GetAllAccountHolders().Find(Emp => Emp.AccountNumber == id));

        }

       
        [HttpPost]


        //Edit
        public ActionResult EditAccountDetails(int id, AccountsModel obj)
        {
            try
            {
                Accounts.Web.DBOperations.DBOperations EmpRepo = new Accounts.Web.DBOperations.DBOperations();



                //EmpRepo.UpdateAccountHolders(obj);

                if (EmpRepo.UpdateAccountHolders(obj))
                {
                    ViewBag.AlertMsg = "Account details Updated successfully";

                }

                return RedirectToAction("GetAllAccountHoldersDetails");


            }
            catch
            {
                return View();
            }
        }

       

        //Delete
        public ActionResult DeleteAccount(int id)
        {
            try
            {
                Accounts.Web.DBOperations.DBOperations EmpRepo = new Accounts.Web.DBOperations.DBOperations();
                if (EmpRepo.DeleteAccountHolder(id))
                {
                    ViewBag.AlertMsg = "Account details deleted successfully";

                }
                return RedirectToAction("GetAllAccountHoldersDetails");

            }
            catch
            {
                return View();
            }
        }
    }
}
