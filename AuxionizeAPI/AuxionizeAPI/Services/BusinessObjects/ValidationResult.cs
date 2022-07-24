using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuxionizeAPI.Services.BusinessObjects
{
    public class ValidationResult
    {
        public ValidationResult(string message = null)
        {
            Message = message;
        }

        public string Message { get; private set; }
        public bool Success => string.IsNullOrEmpty(Message);
    }
}
