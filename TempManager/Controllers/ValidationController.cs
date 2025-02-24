using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using TempManager.Models;

namespace TempManager.Controllers
{
    public class ValidationController : Controller
    {
        private TempManagerContext context;

        public ValidationController(TempManagerContext ctx)
        {
            context = ctx;
        }

        public JsonResult CheckDate(string date)
        {
            if (!DateTime.TryParse(date, out DateTime dateTime))
            {
                return Json("Date is not valid.");
            }

            Temp temp = context.Temps.FirstOrDefault(t => t.Date == dateTime);

            if (temp == null)
            {
                return Json(true);
            }
            else
            {
                return Json("Date is already in the database.");
            }
        }
    }
}
