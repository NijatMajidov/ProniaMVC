using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaMVC.Business.Exceptions
{
    public class DublicateCategoryException : Exception
    {
        public string PropertyName { get; set; }
        public DublicateCategoryException(string name,string? message) : base(message)
        {
            PropertyName = name;
        }
    }
}
