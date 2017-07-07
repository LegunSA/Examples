using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTO.Interfaces;
using DTO.PresentationModels;
using AutoMapper;
using WebManager.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Data.SqlClient;

namespace WebManager.Controllers
{
    public class ClientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: Client
        public IActionResult Index(string sortOrder, string searchString)
        {
            ICollection<Client> clients;
            ViewBag.SortParm = sortOrder = sortOrder == "Name" ? "Name desc" : "Name";
            try
            {
                clients = _unitOfWork.ClientRepository.GetAll();
            }
            catch (SqlException)
            {
                return NotFound();
            }
            ICollection<ClientModel> result = new List<ClientModel>();

            foreach (var client in clients)
            {
                result.Add(_mapper.Map<Client, ClientModel>(client));
            }

            switch (sortOrder)
            {
                case "Name desc":
                    result = result.OrderByDescending(s => s.Name).ToList();
                    break;
                default:
                    result = result.OrderBy(s => s.Name).ToList();
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(x => x.Name.Contains(searchString)).ToList();
            }

            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // GET: Client/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _unitOfWork.ClientRepository.Find(new Client() { Id = (int)id });

            if (client == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<Client, ClientModel>(client));
        }

        // GET: Client/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client/Create       
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] ClientModel client)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ClientRepository.Create(_mapper.Map<ClientModel, Client>(client));
                _unitOfWork.ManagerRepository.Save();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Client/Edit
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = _mapper.Map<Client, ClientModel>(_unitOfWork.ClientRepository.Find(new Client() { Id = (int)id }));
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Client/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] ClientModel client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.ClientRepository.Edit(_mapper.Map<ClientModel, Client>(client));
                    _unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientSetExists(client.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Client/Delete/5
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _mapper.Map<Client, ClientModel>(_unitOfWork.ClientRepository.Find(new Client() { Id = (int)id }));

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Client/Delete
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var client = _unitOfWork.ClientRepository.Find(new Client() { Id = (int)id });
            _unitOfWork.ClientRepository.Delete(client);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        private bool ClientSetExists(int id)
        {
            return _unitOfWork.ClientRepository.GetAll().Any(e => e.Id == id);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckUser(string name)
        {
            var clientName = _unitOfWork.ClientRepository.Find(new Client() { Name = name });
            if (clientName != null)
            {
                return Json(false);
            }

            return Json(true);
        }
    }
}
