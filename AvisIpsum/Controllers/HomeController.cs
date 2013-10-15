using AvisIpsum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvisIpsum.Controllers
{
    public class HomeController : Controller
    {

        protected IIpsumParagraphProvider textProvider;

        public HomeController ()
        {
            textProvider = new IpsumParagraphProvider();
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            var requestParams = new IpsumRequestParams() { NumberOfParagraphs = 3, WordsPerParagraph = 40 };
            return View(requestParams);
        }

        public PartialViewResult IpsumText (IpsumRequestParams requestParams)
        {
            var AvisIpsumText = textProvider.GetParagraphs(requestParams.NumberOfParagraphs, requestParams.WordsPerParagraph);

            return PartialView(AvisIpsumText);
        }

    }
}
