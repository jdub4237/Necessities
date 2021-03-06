﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Necessities.Data;
using Necessities.Models;

namespace Necessities.Controllers
{
    [Authorize]
    public class ConsigneesController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<ConsigneeModel> consigneeModels;
            using (var necessitiesContext = new NecessitiesContext())
            {
                consigneeModels = necessitiesContext.Consignees.ToList().Select(
                    str => new ConsigneeModel
                    {
                        ConsigneeId = str.ConsigneeId,
                        FirstName = str.FirstName,
                        LastName = str.LastName,
                        AddressOne = str.AddressOne,
                        AddressTwo = str.AddressTwo,
                        City = str.City,
                        State = str.State,
                        PostalCode = str.PostalCode,
                        PhoneNumber = str.PhoneNumber,
                        Email = str.Email,
                        Percentage = str.Percentage,
                        CreationDate = str.CreationDate,
                        UpdatedDate = str.UpdatedDate
                    });
            }
            return View(consigneeModels);
        }

        public ActionResult Create()
        {
            return View(new ConsigneeModel
                            {
                                State = "MO",
                                Percentage = 40.00m,
                                CreationDate = DateTime.Now,
                                UpdatedDate = DateTime.Now
                            });
        }

        [HttpPost]
        public ActionResult Create(ConsigneeModel consigneeModel)
        {
            if (ModelState.IsValid)
            {
                using (var necessitiesContext = new NecessitiesContext())
                {
                    necessitiesContext.Consignees.Add(
                        new Consignee
                            {
                                ConsigneeId = consigneeModel.ConsigneeId,
                                FirstName = consigneeModel.FirstName,
                                LastName = consigneeModel.LastName,
                                AddressOne = consigneeModel.AddressOne,
                                AddressTwo = consigneeModel.AddressTwo,
                                City = consigneeModel.City,
                                State = consigneeModel.State,
                                PostalCode = consigneeModel.PostalCode,
                                PhoneNumber = GetCleanPhoneNumber(consigneeModel.PhoneNumber),
                                Email = consigneeModel.Email,
                                Percentage = consigneeModel.Percentage/100,
                                CreationDate = DateTime.Now,
                                UpdatedDate = DateTime.Now
                            });

                    necessitiesContext.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(consigneeModel);
        }

        private static string GetCleanPhoneNumber(string phoneNumber)
        {
            return Regex.Replace(phoneNumber, "[^0-9]", string.Empty);
        }

        public ActionResult Edit(int consigneeId)
        {
            ConsigneeModel consigneeModel;
            using (var necessitiesContext = new NecessitiesContext())
            {
                var consignee = necessitiesContext.Consignees.First(x => x.ConsigneeId == consigneeId);

                consigneeModel = new ConsigneeModel
                                     {
                                         AddressOne = consignee.AddressOne,
                                         AddressTwo = consignee.AddressTwo,
                                         City = consignee.City,
                                         ConsigneeId = consignee.ConsigneeId,
                                         CreationDate = consignee.CreationDate,
                                         Email = consignee.Email,
                                         FirstName = consignee.FirstName,
                                         LastName = consignee.LastName,
                                         Percentage = consignee.Percentage * 100,
                                         PhoneNumber = consignee.PhoneNumber,
                                         PostalCode = consignee.PostalCode,
                                         State = consignee.State,
                                         UpdatedDate = consignee.UpdatedDate
                                     };
            }

            return View(consigneeModel);
        }

        [HttpPost]
        public ActionResult Edit(ConsigneeModel consigneeModel)
        {
            if (ModelState.IsValid)
            {
                using (var necessitiesContext = new NecessitiesContext())
                {
                    var consignee = necessitiesContext.Consignees.First(x => x.ConsigneeId == consigneeModel.ConsigneeId);

                    consignee.ConsigneeId = consigneeModel.ConsigneeId;
                    consignee.FirstName = consigneeModel.FirstName;
                    consignee.LastName = consigneeModel.LastName;
                    consignee.AddressOne = consigneeModel.AddressOne;
                    consignee.AddressTwo = consigneeModel.AddressTwo;
                    consignee.City = consigneeModel.City;
                    consignee.State = consigneeModel.State;
                    consignee.PostalCode = consigneeModel.PostalCode;
                    consignee.PhoneNumber = GetCleanPhoneNumber(consigneeModel.PhoneNumber);
                    consignee.Email = consigneeModel.Email;
                    consignee.Percentage = consigneeModel.Percentage / 100;
                    consignee.UpdatedDate = DateTime.Now;

                    necessitiesContext.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(consigneeModel);
        }
    }
}
