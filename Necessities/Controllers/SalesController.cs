using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Necessities.Data;
using Necessities.Models;

namespace Necessities.Controllers
{
    [Authorize]
    public class SalesController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<SaleModel> saleModels;
            using (var necessitiesContext = new NecessitiesContext())
            {
                saleModels =
                    necessitiesContext.Sales.Select(sale =>
                                                    new SaleModel
                                                        {
                                                            SaleId = sale.SaleId,
                                                            Date = sale.Date,
                                                            TaxRate = sale.TaxRate,
                                                            CreationDate = sale.CreationDate,
                                                            UpdatedDate = sale.UpdatedDate,
                                                            SaleItems =
                                                                sale.SaleItems.Select(
                                                                    item => new SaleItemModel
                                                                        {
                                                                            SaleItemId = item.SaleItemId,
                                                                            Amount = item.Amount,
                                                                            Description = item.Description,
                                                                            ItemTypeId = item.ItemTypeId,
                                                                            ConsigneeId = item.ConsigneeId,
                                                                            SaleId = item.SaleId,
                                                                            CreationDate = item.CreationDate,
                                                                            UpdatedDate = item.UpdatedDate
                                                                        })
                                                        }).ToList();
            }
            return View(saleModels);
        }

        public ActionResult Create()
        {
            Percentage taxRate = 0;
            using (var necessitiesContext = new NecessitiesContext())
            {
                var str = necessitiesContext.SalesTaxRates.OrderByDescending(rate => rate.StartDate)
                                  .FirstOrDefault(rate => rate.StartDate <= DateTime.Now);

                if (str != default(SalesTaxRate))
                {
                    taxRate = str.TaxRate;
                }
            }
            return View(new SaleModel
                {
                    SaleId = 0,
                    Date = DateTime.Now,
                    TaxRate = taxRate,
                    CreationDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    SaleItems = new SaleItemModel[0]
                });
        }

        [HttpPost]
        public ActionResult Create(SaleModel saleModel)
        {
            if (ModelState.IsValid)
            {
                using (var necessitiesContext = new NecessitiesContext())
                {
                    necessitiesContext.Sales.Add(
                        new Sale
                            {
                                SaleId = saleModel.SaleId,
                                Date = saleModel.Date,
                                TaxRate = saleModel.TaxRate,
                                CreationDate = DateTime.Now,
                                UpdatedDate = DateTime.Now,
                                SaleItems =
                                    saleModel.SaleItems.Select(
                                        item => new SaleItem
                                            {
                                                SaleItemId = item.SaleItemId,
                                                Amount = item.Amount,
                                                Description = item.Description,
                                                ItemTypeId = item.ItemTypeId,
                                                ConsigneeId = item.ConsigneeId,
                                                SaleId = item.SaleId,
                                                CreationDate = item.CreationDate,
                                                UpdatedDate = item.UpdatedDate
                                            }).ToList()
                            });

                    necessitiesContext.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(saleModel);
        }
    }
}
