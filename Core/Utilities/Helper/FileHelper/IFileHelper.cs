using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper.FileHelper
{
    public interface IFileHelper
    {
        IResult Upload(IFormFile file);
        IResult Update(IFormFile file, string filePath);
        IResult Delete(string filePath);
    }
}
