using Microsoft.AspNetCore.Mvc;
using Treinee.Quake.Domain.Repository;

namespace Treinee.Quake.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryDeath _repository;
        public HomeController(IUnitOfWork unitOfWork, IRepositoryDeath repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var deaths = _repository.GetTenDeaths();

            //https://gist.github.com/labmorales/7ebd77411ad51c32179bd4c912096031

            return View(deaths);
        }

        [HttpGet]
        public IActionResult SearchByName(string search)
        {
            var deaths = _repository.GetDeaths(search);

            return PartialView("_Kills", deaths);
        }
    }
}
