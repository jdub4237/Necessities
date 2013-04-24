using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Necessities.Data;
using Necessities.Models;

namespace Necessities.Controllers
{
    [System.Web.Http.Authorize]
    public class ItemTypesController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<ItemTypeModel> itemTypeModels;
            using (var necessitiesContext = new NecessitiesContext())
            {
                itemTypeModels = necessitiesContext.ItemTypes.ToList().Select(
                    str => new ItemTypeModel
                               {
                                   ItemTypeId = str.ItemTypeId,
                                   Description = str.Description,
                                   Active = str.Active
                               });
            }
            return View(itemTypeModels);
        }

        public ActionResult Create()
        {
            return View(new ItemTypeModel());
        }

        [HttpPost]
        public ActionResult Create(ItemTypeModel itemTypeModel)
        {
            using (var necessitiesContext = new NecessitiesContext())
            {
                necessitiesContext.ItemTypes.Add(
                    new ItemType
                        {
                            Description = itemTypeModel.Description,
                            Active = true
                        });

                necessitiesContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int itemTypeId)
        {
            ItemType itemType;
            using (var necessitiesContext = new NecessitiesContext())
            {
                itemType = necessitiesContext.ItemTypes.First(x => x.ItemTypeId == itemTypeId);
            }

            return View(itemType);
        }

        [HttpPost]
        public ActionResult Edit(ItemTypeModel itemTypeModel)
        {
            using (var necessitiesContext = new NecessitiesContext())
            {
                var itemType = necessitiesContext.ItemTypes.First(x => x.ItemTypeId == itemTypeModel.ItemTypeId);

                itemType.Description = itemTypeModel.Description;
                itemType.Active = itemTypeModel.Active;

                necessitiesContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
