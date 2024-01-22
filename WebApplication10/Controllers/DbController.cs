using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using WebApplication10.Data;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class DbController : Controller
    {
        private ApplicationDbContext _context;
        public DbController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index(int? id)
        {
            return View(_context.doos.ToList());



        }




        //start edit

        public IActionResult Edit(int? id)
        {
            if (id == null || _context.doos == null)
            {
                return NotFound();
            }


            var doos = _context.doos.FirstOrDefault(x => x.id == id);
            if (doos == null)
            {
                return NotFound();
            }



            return View(doos);
        }
        [HttpPost]
        public IActionResult Edit(int id,Do doo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doo);
                    _context.SaveChanges();
                }
                catch(Exception)
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }



        //end edit


        //start delete

        public IActionResult Delete(int? id)
        {
            if (id == null || _context.doos == null)
            {
                return NotFound();

            }
            var doos = _context.doos.FirstOrDefault(x => x.id == id);
            if (doos == null)
            {
                return NotFound();
            }
            return View(doos);


        }

        //start post delete
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteCo(int? id)
        {
            if (id == null || _context.doos == null)
            {
                return NotFound();

            }
            var doos = _context.doos.FirstOrDefault(x => x.id == id);
            if (doos == null)
            {
                return NotFound();
            }
            _context.doos.Remove(doos);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        //end delete

        //start detalis
        public IActionResult Detalis(int? id)
        {


            var doos = _context.doos.FirstOrDefault(x => x.id == id);
            if (doos == null)
            {
                return NotFound();
            }



            return PartialView("_Detalis",doos);
        }
        //end detalis


        //start create
        public IActionResult create()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult create(Do dd)
        {
            if (ModelState.IsValid)
            {

                _context.doos.Add(dd);
               
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                   
                
                
            }
            return RedirectToAction("Index");
        }
        //end create

        

    }//end controller

}//end model
