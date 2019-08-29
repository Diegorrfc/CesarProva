using System;
using System.Collections.Generic;
using System.Text;

namespace Cesar.Domain.CesarContext.Dtos
{
    public class ResultDto
    {
        public ResultDto()
        {           
        }
        public ResultDto(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
