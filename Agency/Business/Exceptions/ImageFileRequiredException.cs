using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class ImageFileRequiredException:Exception
    {
        public string PropertyName { get; set; }
        public ImageFileRequiredException(string propertyName,string? message) : base(message)
        {
            PropertyName = propertyName;
        }

        

    }
}
