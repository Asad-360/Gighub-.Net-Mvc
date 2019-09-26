using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.Core.CustomValidation
{
    /// <summary>
    /// This class is for custom file uploading , to check wether file type is valid or not
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ValidFile : ValidationAttribute
    {
        /// <summary>  
        /// Gets or sets file size property. Default is 1GB (the value is in Bytes).  
        /// </summary>  
        public int FileSize { get; set; } = (5000*5000)+(5000*5000);
        /// <summary>
        /// Gets or sets the file size property. Default is mp3.
        /// </summary>
        public string FileType { get; set; } = "audio/mpeg";

        /// <summary>  
        /// Is valid method.  
        /// </summary>  
        /// <param name="value">Value parameter</param>  
        /// <returns>Returns - true is specify extension matches.</returns>  
        public override bool IsValid(object value)
        {
            // Initialization  
            HttpPostedFileBase file = value as HttpPostedFileBase;
            bool isValid = false;

            // Settings.  
            int allowedFileSize = this.FileSize;
            var allowedfileTypeContent = this.FileType;

            // Verification.  
            if (file != null)
            {
                // Initialization.  
                var fileSize = file.ContentLength;
                var fileType = file.ContentType;

                // Settings.  
                isValid = (fileSize <= allowedFileSize) &&( fileType == allowedfileTypeContent);
            }

            // Info  
            return isValid;
        }

    }
}