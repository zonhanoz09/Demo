using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class BaseController : Controller
    {
        internal DemoContext db;

        public BaseController()
        {
            if (db == null)
            {
                db = new DemoContext();
            }
        }
    }
}