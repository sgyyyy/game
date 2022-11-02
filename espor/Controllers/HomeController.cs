using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer;
using espor.EmailServices;
using espor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace espor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IMapper mapper, IEmailSender emailSender)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var model = new IndexModel()
            {
                Tournaments = _unitOfWork.Tournaments.GetAll()
            };
            return View(model);
        }

        public IActionResult Tournaments()
        {
            return View();
        }

        public IActionResult TournamentDetails(int id)
        {
            if (id != 0)
            {
                var entity = _unitOfWork.Tournaments.GetById(id);


                if (entity != null)
                {
                    var model = _mapper.Map<TournamentsModel>(entity);
                    return View(model);
                }
            }
            return NotFound();
        }

        public IActionResult Gallery()
        {
            return View();
        }

        public IActionResult Fixture()
        {
            //var model = new IndexModel()
            //{
            //    Tournaments = _unitOfWork.Tournaments.GetAll()
            //};
            //return View(model);
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<bool> Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                await _emailSender.SendEmailContactAsync(model.Email, model.Name, model.Subject, model.Message);

                var entity = _mapper.Map<Contact>(model);

                //_unitOfWork.Contacts.Create(entity);

                return true;
            }
            return false;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
