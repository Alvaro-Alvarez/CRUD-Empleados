using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDEmpleados.Models;
using System.IO;
using System.Data.Entity;

namespace CRUDEmpleados.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(ObtenerAllEmpleados());
        }

        IEnumerable<empleado> ObtenerAllEmpleados()
        {
            using (empleadosdbEntities db = new empleadosdbEntities())
            {
                return db.empleado.ToList<empleado>();
            }
        }

        public ActionResult AgregaroEditar(int id = 0)
        {
            empleado emp = new empleado();
            if (id != 0)
            {
                using (empleadosdbEntities db = new empleadosdbEntities())
                {
                    emp = db.empleado.Where(x => x.id == id).FirstOrDefault<empleado>();
                }
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult AgregaroEditar(empleado emp)
        {
            try
            {
                if (emp.CargaImagen != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(emp.CargaImagen.FileName);
                    string extension = Path.GetExtension(emp.CargaImagen.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.RutaImagen = "~/CargaArchivos/Imagenes/" + fileName;
                    emp.CargaImagen.SaveAs(Path.Combine(Server.MapPath("~/CargaArchivos/Imagenes/"), fileName));
                }
                using (empleadosdbEntities db = new empleadosdbEntities())
                {
                    if(emp.id == 0)
                    {
                        db.empleado.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", ObtenerAllEmpleados()), message = "Enviado satisfactoriamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                return Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                using (empleadosdbEntities db = new empleadosdbEntities())
                {
                    empleado emp = db.empleado.Where(x => x.id == id).FirstOrDefault<empleado>();
                    db.empleado.Remove(emp);
                    db.SaveChanges();
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", ObtenerAllEmpleados()), message = "Eliminado satisfactoriamente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}