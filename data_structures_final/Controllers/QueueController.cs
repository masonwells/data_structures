﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace data_structures_final.Controllers
{
    public class QueueController : Controller
    {
        static Queue<string> qDisplay = new Queue<string>();

        // GET: Queue
        public ActionResult Index()
        {
            ViewBag.display = qDisplay;
            return View();
        }

        //Adding one to the Queue
        public ActionResult AddOne()
        {
            qDisplay.Enqueue("New Entry " + (qDisplay.Count + 1));
            ViewBag.display = qDisplay;
            return View("Index");
        }

        //Adding 2000 using a for loop to push to the Queue
        public ActionResult AddHugeList()
        {
            qDisplay.Clear();
            for (int i = 0; i < 2000; i++)
            {
                qDisplay.Enqueue("New Entry " + (qDisplay.Count + 1));
            }
            ViewBag.display = qDisplay;
            return View("Index");
        }

        ////Displaying the Queue
        public ActionResult Display()
        {
            ViewBag.display = qDisplay;
            return View("DisplayQueue");
        }

        //Delete from the Queue
        public ActionResult Delete()
        {
            if (qDisplay.Count > 0)
            {
                qDisplay.Dequeue();
            }
            else
            {
                return View("Index");
            }
            ViewBag.display = qDisplay;
            return View("Index");
        }

        //Clear from the Stack
        public ActionResult Clear()
        {
            qDisplay.Clear();
            ViewBag.display = qDisplay;
            return View("Index");
        }

        //Search from the Queue
        public ActionResult Search()
        {
            if (qDisplay.Count > 0)
            {
                string stringSearch = "New Entry 15";
                string Found = "Found";
                string NotFound = "Not Found";
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                ViewBag.Status = NotFound;
                //loop to do all the work
                foreach (string item in qDisplay)
                {
                    if (item.Contains(stringSearch))
                    {
                        sw.Stop();
                        TimeSpan ts = sw.Elapsed;
                        ViewBag.Status = Found;
                        ViewBag.StopWatch = ts;
                    }
                    else
                    {
                        TimeSpan ts = sw.Elapsed;
                        ViewBag.StopWatch = ts;
                    }
                }
                sw.Stop();
            }
            return View("Search");
        }
    }
}