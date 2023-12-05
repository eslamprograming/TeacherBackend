using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Sheard
{
    public class Response<T>
    {
        public bool success { get; set; } = false;
        public string? statuscode { get; set; } = "500";
        public string? message { get; set; }
        public List<T>? values { get; set; }
        public T? Value { get; set; }
        public int? groups { get; set; }
        public int? pagging { get; set; } = 10;
    }
}
