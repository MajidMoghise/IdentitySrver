using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.DTOs
{
    public class ResponseModel<T> : ResponseModel
    {
        public T Model { get; set; }

    }
    public class ResponseModel
    {
        public bool Success { get; set; }
        public HttpStatusCode HttpstatusCode { get; set; }
        public string Message { get; set; }
    }
}
