using HW2.Models;
using HW2.Servies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW2.Controllers
{
    public class ShList : Controller
    {
       public static List<DoList> mylist = new();
        IListServies ser;
        public ShList(IListServies serr)
        {
            ser = serr;
        }
        public IActionResult Index()
        {
            return View(nameof(Index), ser.List());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind] DoList clist)
        {
            ser.Add(clist);
            return Index();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var elist = ser.Get(id);
            if (elist == null)
                return NotFound();
            return View(elist);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind] DoList clist)
        {
            try
            {
                ser.Edit(id, clist);
                return Index();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var dlist = ser.Get(id);
            if (dlist == null)
                return NotFound();

            return View(dlist);
        }

        [HttpPost("[Controller]/Delete/{id}")]
        public IActionResult PostDelete(int id)
        {
            try
            {
                ser.Delete(id);
                return Index();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }



    }
}
