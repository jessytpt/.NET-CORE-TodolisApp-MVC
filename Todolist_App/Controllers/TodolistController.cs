using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todolist_App.Models;

namespace Todolist_App.Controllers
{
    public class TodolistController : Controller
    {
        private readonly TodolistContext _context; //contexto de la base de datos, debe estar en modesl con la terminación context

        public TodolistController(TodolistContext context)
        {
            _context = context;
        }

        //Http Get Index
        public IActionResult Index()
        {
            IEnumerable<Tarea> listaTareas = _context.Tareas;
            return View(listaTareas);
        }

        //Http Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Http Post Create
        [HttpPost]
        public IActionResult Create(Tarea tarea)
        {
            if (ModelState.IsValid) {
                tarea.EstadoTarea = false;
                _context.Tareas.Add(tarea);
                _context.SaveChanges();

                TempData["mensaje"] = "Tarea creada correctamente!";
                return RedirectToAction("Index");
            }
            return View();
        }

        //Http Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) {
                return NotFound();

            }

            var tarea = _context.Tareas.Find(id);

            if (tarea == null)
            {
                return NotFound();
            }

            return View(tarea);
        }

        //Http Post Edit
        [HttpPost]
        public IActionResult Edit(Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                tarea.EstadoTarea = false;
                _context.Tareas.Update(tarea);
                _context.SaveChanges();

                TempData["mensaje"] = "Tarea actualizada correctamente!";
                return RedirectToAction("Index");
            }
            return View();
        }

        //Http Get Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {

            //-------------
            if (id == null || id == 0)
            {
                return NotFound();

            }

            var tarea = _context.Tareas.Find(id);

            if (tarea == null)
            {
                return NotFound();
            }

            return View(tarea);
        }

        //Http Post Delete
        [HttpPost]
        public IActionResult Eliminar(int? id)
        {
            var tarea = _context.Tareas.Find(id);

            if (tarea == null)
            {
                return NotFound();
            }

            _context.Tareas.Remove(tarea);
            _context.SaveChanges();

            TempData["mensaje"] = "Tarea eliminada!";
            return RedirectToAction("Index");
        }

        //Http Post Delete
        [HttpPost]
        //  [ActionName("Delete")]
        public ActionResult DeleteTarea(IFormCollection formCollection)
        {
            int _idTarea = Convert.ToInt32(formCollection["IdTarea"]);

            var tarea = _context.Tareas.Find(_idTarea);

            if (tarea == null)
            {
                return NotFound();
            }

             _context.Tareas.Remove(tarea);
             _context.SaveChanges();

             TempData["mensaje"] = "Tarea eliminada!";
             return RedirectToAction("Index");
        

        }        
        /*
        //Http Post Delete
        [HttpPost]
      //  [ActionName("Delete")]
        public ActionResult DeleteTarea(int id)
        {
            var tarea = _context.Tareas.Find(id);

            if (tarea == null ) {
                return NotFound();
            }
           
                _context.Tareas.Remove(tarea);
                _context.SaveChanges();

                TempData["mensaje"] = "Tarea eliminada!";
                return RedirectToAction("Index");
            
        }*/

    }
}
