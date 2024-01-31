using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace CoupenAPI.Models.Dto
{
    public class ResponseDto
    {
        public object Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessages { get; set; }
    }
}
