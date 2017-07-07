using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DTO.Interfaces;
using DTO.PresentationModels;
using AutoMapper;
using WebManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebManager.Controllers
{
    [Authorize(Roles = "admin")]
    public class ReportController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: Report
        [AllowAnonymous]
        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";
            ViewBag.SortParmDate = sortOrder == "Date" ? "Date desc" : "Date";
            var reports = _unitOfWork.ReportRepository.GetAll();
            ICollection<ReportModel> result = new List<ReportModel>();
            foreach (var report in reports)
            {
                result.Add(_mapper.Map<Report, ReportModel>(report));
            }
            switch (sortOrder)
            {
                case "Name desc":
                    result = result.OrderByDescending(s => s.Manager.Name).ToList();
                    break;
                case "Date desc":
                    result = result.OrderByDescending(s => s.Date).ToList();
                    break;
                case "Date":
                    result = result.OrderBy(s => s.Date).ToList();
                    break;
                default:
                    result = result.OrderBy(s => s.Manager.Name).ToList();
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(x => x.Manager.Name.Contains(searchString)).ToList();
            }
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // GET: Report/Details/5
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = _mapper.Map<Report, ReportModel>(_unitOfWork.ReportRepository.Find(new Report() { Id = (int)id }));
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // GET: Report/Create
        public IActionResult Create()
        {
            ViewData["ManagerId"] = new SelectList(_unitOfWork.ManagerRepository.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Report/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Date,ManagerId")] ReportModel report)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ReportRepository.Create(_mapper.Map<ReportModel, Report>(report));
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewData["ManagerId"] = new SelectList(_unitOfWork.ManagerRepository.GetAll(), "Id", "Name", report.ManagerId);
            return View(report);
        }

        // GET: Report/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = _mapper.Map<Report, ReportModel>(_unitOfWork.ReportRepository.Find(new Report() { Id = (int)id })); //await _context.ReportSet.SingleOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                return NotFound();
            }
            ViewData["ManagerId"] = new SelectList(_unitOfWork.ManagerRepository.GetAll(), "Id", "Name", report.Manager.Id);
            return View(report);
        }

        // POST: Report/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Date,ManagerId")] ReportModel report)
        {
            if (id != report.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.ReportRepository.Edit(_mapper.Map<ReportModel, Report>(report));
                    _unitOfWork.Save();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportSetExists(report.Id))
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
            ViewData["ManagerId"] = new SelectList(_unitOfWork.ManagerRepository.GetAll(), "Id", "Name", report.Manager.Id);
            return View(report);
        }

        // GET: Report/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = _unitOfWork.ReportRepository.Find(new Report() { Id = (int)id });
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // POST: Report/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var report = _unitOfWork.ReportRepository.Find(new Report() { Id = (int)id });
            _unitOfWork.ReportRepository.Delete(report);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        private bool ReportSetExists(int id)
        {
            return _unitOfWork.ReportRepository.GetAll().Any(e => e.Id == id);
        }
    }
}
