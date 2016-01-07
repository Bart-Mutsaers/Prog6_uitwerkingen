using LeagueStore.Models;
using LeagueStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueStore.Controllers
{
    public class BundleController : Controller
    {
        // GET: Bundle
        public ActionResult Index()
        {

            using (var context = new MyContext())
            {

                List<Bundle> bundles = context.Bundles
                    .Include("Products").ToList();

                return View(bundles);
            } 
        }

        public ActionResult Create()
        {
            using (var context = new MyContext())
            {
                var bundle = new Bundle();
                bundle.BannerUrl = "~/Content/img/default.jpg";
                var products = context.Products.ToList();
                return View(new BundleVM { Bundle = bundle, Products = products });
            }
        }

        [HttpPost]
        public ActionResult Create(BundleVM bundleVM)
        {
            SaveBundle(bundleVM);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int bundleId)
        {
            using (var context = new MyContext())
            {

                Bundle bundle = context.Bundles.Find(bundleId);
                var products = context.Products.ToList();
                return View(new BundleVM { Bundle = bundle, Products = products });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BundleVM bundleVM)
        {
            SaveBundle(bundleVM);
            return RedirectToAction("Index");
        }

        private void SaveBundle(BundleVM bundleVM)
        {
            Bundle bundle;
            using (var context = new MyContext())
            {
                if(bundleVM.Bundle.Id == 0){
                    bundle = new Bundle();
                    context.Bundles.Add(bundle);
                }
                else{
                    bundle = context.Bundles.Include("Products")
                        .First(b => b.Id == bundleVM.Bundle.Id);
                }

                bundle.Name = bundleVM.Bundle.Name;
                bundle.Description = bundleVM.Bundle.Description;
                bundle.RiotPoints = bundleVM.Bundle.RiotPoints;
                bundle.BannerUrl = bundleVM.Bundle.BannerUrl;
                bundle.Products = bundleVM.ProductIds.Select(pi => context.Products.Find(pi)).ToList();
                context.SaveChanges();
            }
        }
    }
}