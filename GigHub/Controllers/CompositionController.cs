using GigHub.Core;
using GigHub.Core.Models;
using GigHub.Core.ViewModels;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class CompositionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompositionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Action Method for Index Composition Page
        /// </summary>
        /// <returns>Strongly Typed View Of CompositionViewModel</returns>        
        public ActionResult Index()
        {
            var evm = new CompostitionViewModel {
                fileBase = null, 
                FileName = null 
            };
            return View(evm);
        }
       
        /// <summary>
        /// Action Method to Upload Audio
        /// </summary>
        /// <param name="cvm">Composition View Model</param>
        /// <returns>Json Result</returns>
        [HttpPost]
        public JsonResult UploadAudio(CompostitionViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                var fileBase = cvm.fileBase;
                string path = Server.MapPath("~/Audio/");
                string fileName = Path.GetFileName(fileBase.FileName);
                string fullPath = Path.Combine(path, fileName);
                fileBase.SaveAs(fullPath);
                _unitOfWork.Composition.Add(new Composition
                {
                    FilePath = "~/Audio/" + fileName,
                    Name = cvm.FileName,
                    ArtistId = User.Identity.GetUserId()
                });
                _unitOfWork.Complete();

                return Json("File Uploaded Successfully");
            }
            else
            {
                return Json("Please Upload Correct File Upto 50mb");
            }
                   
        }

        /// <summary>
        /// Action Method for Getting All Artist Compostion
        /// </summary>
        /// <returns>View Result Of Composition</returns>
        [HttpGet]
        public ActionResult GetComposition()
        {
            var userId = User.Identity.GetUserId();
            var composition = _unitOfWork.Composition.GetAllComposition(userId);
            return View(composition);
        }    

    }
}