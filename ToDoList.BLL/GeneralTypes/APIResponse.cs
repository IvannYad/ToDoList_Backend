using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.BLL.GeneralTypes
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string>? ErrorMessages { get; set; }
        public object? Result { get; set; }

        public void Generate200OK(object? data)
            => GenerateResponse(true, null, HttpStatusCode.OK, data);

        public void Generate400BadRequest(List<string>? errorMessages)
            => GenerateResponse(false, errorMessages, HttpStatusCode.BadRequest, null);

        public void Generate404NotFound(List<string>? errorMessages)
            => GenerateResponse(false, errorMessages, HttpStatusCode.NotFound, null);


        private void GenerateResponse(bool isSuccess
            , List<string>? errorMessages
            , HttpStatusCode statusCode
            , object? data)
        {
            this.IsSuccess = isSuccess;
            this.ErrorMessages = errorMessages;
            this.StatusCode = statusCode;
            this.Result = data;
        }
    }
}
