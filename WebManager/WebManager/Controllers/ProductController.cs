using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataBase.Models;
using DTO.Interfaces;
using DTO;
using DTO.PresentationModels;
using AutoMapper;
using WebManager.Models;

namespace WebManager.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: Product
        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";
            ViewBag.SortParmCost = sortOrder == "Cost" ? "Cost desc" : "Cost";
            var products = _unitOfWork.ProductRepository.GetAll();
            ICollection<ProductModel> result = new List<ProductModel>();
            foreach (var product in products)
            {
                result.Add(_mapper.Map<Product, ProductModel>(product));
            }
            switch (sortOrder)
            {
                case "Name desc":
                    result = result.OrderByDescending(s => s.ProductName).ToList();
                    break;
                case "Cost desc":
                    result = result.OrderByDescending(s => s.Cost).ToList();
                    break;
                case "Cost":
                    result = result.OrderBy(s => s.Cost).ToList();
                    break;
                default:
                    result = result.OrderBy(s => s.ProductName).ToList();
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(x => x.ProductName.Contains(searchString)).ToList();
            }

            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // GET: Product/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product =_mapper.Map<Product, ProductModel> (_unitOfWork.ProductRepository.Find(new Product() { Id = (int)id }));

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()=> View();
        

        // POST: Product/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ProductName,Cost")] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepository.Create(_mapper.Map<ProductModel,Product>(product));
                _unitOfWork.ProductRepository.Save();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product =_mapper.Map<Product, ProductModel> (_unitOfWork.ProductRepository.Find(new Product() { Id = (int)id }));
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,ProductName,Cost")] ProductModel product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.ProductRepository.Edit(_mapper.Map<ProductModel, Product> (product));
                    _unitOfWork.ProductRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSetExists(product.Id))
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
            return View(product);
        }

        // GET: Product/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product =_mapper.Map<Product, ProductModel> (_unitOfWork.ProductRepository.Find(new Product() { Id = (int)id }));
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _unitOfWork.ProductRepository.Find(new Product() { Id = (int)id });
            _unitOfWork.ProductRepository.Delete(product);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        private bool ProductSetExists(int id)
        {
            return _unitOfWork.ProductRepository.GetAll().Any(e => e.Id == id);///TODO: Check
        }
    }
}
