using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteThiToeic.Access.EF;

namespace WebsiteThiToeic.Access.DAO
{
    public class UserDAO
    {
        Db db = null;
        public UserDAO()
        {
            db = new Db();
        }

        public int InsertUser(USER uSER)
        {
            db.USERs.Add(uSER);
            db.SaveChanges();
            return uSER.ID;
        }
    }
}