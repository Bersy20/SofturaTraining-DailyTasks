using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCwithADO2.Models;

namespace MVCwithADO2.Controllers
{
    public class CRUDController : Controller
    {
        public ActionResult Index()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayBook();
            return View("Home",dt);
        }
        public ActionResult Insert()
        {
            return View("Create");
        }
        public ActionResult InsertRecord(FormCollection frm,string action)
        {
            if(action=="Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string Title = frm["txtTitle"];
                int aid = Convert.ToInt32(frm["txtAid"]);
                double price = Convert.ToDouble(frm["txtPrice"]);
                int rowIns = mdl.NewBook(Title, aid, price);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult IndexOfAuthors()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayAuthors();
            return View("IndexOfAuthors", dt);
        }
        public ActionResult InsertAuthorLink()
        {
            return View("CreateAuthor");
        }
        public ActionResult InsertAuthor(FormCollection form,string action)
        {
            if(action=="Submit")
            {
                CRUDModel model =new CRUDModel();
                string AuthorName = form["txtAuthorName"];
                int rowInsert = model.InsertNewAuthor(AuthorName);
                return RedirectToAction("IndexOfAuthors");
            }
            else
            {
                return RedirectToAction("IndexOfAuthors");
            }
        }
    }
}