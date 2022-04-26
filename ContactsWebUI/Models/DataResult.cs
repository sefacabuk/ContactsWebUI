using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsWebUI.Models
{
        public class DataResult<T>
        {
            [JsonConstructor]
            public DataResult(T data, bool success, string message)
            {
                Data = data;
                Success = success;
                Message = message;
            }

            public DataResult(bool success, string message)
            {
                Success = success;
                Message = message;
            }

            public DataResult(T data, bool success)
            {
                Data = data;
            }

            public DataResult(T data)
            {
                Data = data;
            }

            public T Data { get; }
            public bool Success { get; }
            public string Message { get; }
        }
}
