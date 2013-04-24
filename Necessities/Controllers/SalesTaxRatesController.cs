using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Necessities.Data;
using Necessities.Models;

namespace Necessities.Controllers.BackOffice
{
    [Authorize]
    public class SalesTaxRatesController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<SalesTaxRateModel> salesTaxRateModels;
            using (var necessitiesContext = new NecessitiesContext())
            {
                salesTaxRateModels = necessitiesContext.SalesTaxRates.ToList().Select(
                    str => new SalesTaxRateModel {StartDate = str.StartDate, TaxRate = str.TaxRate});
            }
            return View(salesTaxRateModels);
        }

        public ActionResult Create()
        {
            return View(new SalesTaxRateModel { StartDate = DateTime.Today, TaxRate = 0.00m });
        }

        [HttpPost]
        public ActionResult Create(DateTime startDate, decimal taxRate)
        {
            var salesTaxRateModel = new SalesTaxRateModel { StartDate = startDate, TaxRate = taxRate / 100 };
            using (var necessitiesContext = new NecessitiesContext())
            {
                necessitiesContext.SalesTaxRates.Add(new SalesTaxRate
                {
                    StartDate = salesTaxRateModel.StartDate,
                    TaxRate = salesTaxRateModel.TaxRate
                });

                necessitiesContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
