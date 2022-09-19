using AnimalsCollection.Data;
using AnimalsCollection.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsCollection.Controllers
{
    public class CreaturesController : Controller
    {
        public IActionResult Index()
        {
            List<CreatureModel> creatures = new List<CreatureModel>();
            CreatureDAO creatureDAO = new CreatureDAO();
            creatures = creatureDAO.FetchAll();


            return View("Index", creatures);
        }

        public IActionResult Details(int id)
        {
            CreatureDAO creatureDAO = new CreatureDAO();
            CreatureModel creature = creatureDAO.FetchOne(id);

            return View("Details", creature);
        }

        public IActionResult Create()
        {
            return View("CreatureForm");
        }
        public IActionResult Delete(int Id)
        {
            CreatureDAO creatureDAO = new CreatureDAO();
            creatureDAO.Delete(Id);


            List<CreatureModel> creatures = creatureDAO.FetchAll();

            return View("CreatureForm", creatures);
        }
        public IActionResult Edit(int Id)
        {
            CreatureDAO creatureDAO = new CreatureDAO();
            CreatureModel creature = creatureDAO.FetchOne(Id);

            return View("CreatureForm", creature);

        }

        public IActionResult ProcessCreate(CreatureModel creatureModel)
        {
            CreatureDAO creatureDAO = new CreatureDAO();
            creatureDAO.CreateOrUpdate(creatureModel);

            return View("Details", creatureModel);
        }
    }
}
