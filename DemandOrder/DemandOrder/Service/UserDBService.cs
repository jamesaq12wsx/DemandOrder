using DemandOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemandOrder.Service
{
    public class UserDBService
    {
        public UserID GetSingleAccount(string acc, string pss)
        {
            UserDBEntities _db = new UserDBEntities();

            var userSystem =_db.UserID.SingleOrDefault(model => model.UserName.Equals(acc) && model.Password.Equals(pss));

            if(userSystem == null)
            {
                return null;
            }

            return userSystem;
        }
    }
}