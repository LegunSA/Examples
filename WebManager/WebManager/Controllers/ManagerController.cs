using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using DTO.Interfaces;
using DTO.PresentationModels;
using System.Collections.Generic;
using System;
using AutoMapper;
using WebManager.Models;

namespace WebManager.Controllers
{
    [Authorize(Roles ="admin")]
    public class ManagerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ManagerController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: ManagerSets
        [AllowAnonymous]
        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.SortParm = sortOrder = sortOrder == "Name" ? "Name desc" : "Name";
            var managers = _unitOfWork.ManagerRepository.GetAll();
            ICollection<ManagerModel> result = new List<ManagerModel>();
            foreach (var manager in managers)
            {
                result.Add(_mapper.Map<Manager, ManagerModel>(manager));
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

        // GET: ManagerSets/Details
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager =_mapper.Map<Manager,ManagerModel>( _unitOfWork.ManagerRepository.Find(new Manager() { Id = (int)id }));

            if (manager == null)
            {
                return NotFound();
            }

            return View(manager);
        }

        // GET: ManagerSets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManagerSets/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] ManagerModel manager)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ManagerRepository.Create(_mapper.Map<ManagerModel,Manager>( manager));
                _unitOfWork.ManagerRepository.Save();
                return RedirectToAction("Index");
            }
            return View(manager);
        }

        // GET: ManagerSets/Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager =_mapper.Map<Manager,ManagerModel>( _unitOfWork.ManagerRepository.Find(new Manager() { Id = (int)id }));
            if (manager == null)
            {
                return NotFound();
            }
            return View(manager);
        }

        // POST: ManagerSets/Edit       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] ManagerModel manager)
        {
            if (id != manager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.ManagerRepository.Edit(_mapper.Map<ManagerModel,Manager> (manager));
                    _unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManagerSetExists(manager.Id))
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
            return View(manager);
        }

        // GET: ManagerSets/Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager =_mapper.Map<Manager,ManagerModel>( _unitOfWork.ManagerRepository.Find(new Manager() { Id = (int)id }));

            if (manager == null)
            {
                return NotFound();
            }

            return View(manager);
        }

        // POST: ManagerSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var manager = _unitOfWork.ManagerRepository.Find(new Manager() { Id = id });
            _unitOfWork.ManagerRepository.Delete(manager);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        private bool ManagerSetExists(int id)
        {
            return _unitOfWork.ManagerRepository.GetAll().Any(e => e.Id == id);///TODO: Check
        }
    }
}
