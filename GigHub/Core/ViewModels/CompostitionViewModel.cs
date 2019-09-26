using GigHub.Core.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.Core.ViewModels
{
    public class CompostitionViewModel
    {
        [Required]
        public string FileName { get; set; }
        [ValidFile(FileSize = 5 * 1024 * 1024,FileType ="audio/ogg", ErrorMessage = "Maximum allowed file size is 5 MB")]
        public HttpPostedFileBase fileBase { get; set; }
    }
}