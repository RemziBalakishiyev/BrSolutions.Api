using BrSolution.Application.Wrappers;
using BrSolution.Domain.Entities.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSolution.Application.Helpers
{
    public static class UploadedFileHelper
    {
        public static UploadFile AsUploadedFile(
           FileContentWrapper fileContentWrapper,
           string relativePath)
           => new()
           {
               FileName = fileContentWrapper.FileName,
               ContentType = fileContentWrapper.ContentType,
               RelativePath = relativePath
           };
    }
}
