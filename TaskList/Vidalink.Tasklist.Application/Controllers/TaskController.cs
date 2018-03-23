using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidalink.Tasklist.Application.Models;
using Vidalink.Tasklist.Repository.Models;
using Vidalink.Tasklist.Services;

namespace Vidalink.Tasklist.Application.Controllers
{
    public class TaskController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        TaskService taskService = new TaskService();
        

        [HttpPost]
        public ActionResult Find(string consulta)
        {
            return View("Index", taskService.List()
                .Where( w => w.Titulo.Contains(consulta) ||
                             w.Descricao.Contains(consulta)));
        }
        
        [Authorize]
        public ActionResult Index()
        {
            return View(taskService.List().OrderBy(o => o.DataExecucao));
        }

        [Authorize]
        public ActionResult Home()
        {            
            return View(taskService.List().Where(w => w.DataExecucao >= DateTime.Now).OrderBy(o => o.DataExecucao).Take(5).ToList());
        }

       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Descricao,DataExecucao")] Task task)
        {
            if (ModelState.IsValid)
            {
                taskService.Add(task);
                return RedirectToAction("Index");
            }

            return View(task);
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Task task = taskService.Find(Convert.ToInt32(id));
            if (task == null)
            {
                return HttpNotFound();
            }

            ViewBag.DataExecucao = task.DataExecucao.ToShortDateString();

            if (task.DataExecucao <= DateTime.Now)
            {
                ModelState.AddModelError("", "Somente é permitido alterar tarefas futuras.");
                return View("View", task);
            }
            else
            {
                return View(task);
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Descricao,DataExecucao")] Task task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    taskService.Edit(task);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                Response.Write("<script>alert('Erro" + e.Message+ "');</script>");
            }
            return View(task);
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var task = taskService.Find(Convert.ToInt32(id));

            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            taskService.Remove(Convert.ToInt32(id));
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
