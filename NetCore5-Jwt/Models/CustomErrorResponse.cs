using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore5_Jwt.Models
{
    public class CustomErrorResponse
    {
        public List<string> Errors { get; private set; } = new List<string>();
        public bool IsShow { get; set; }
        public CustomErrorResponse(string error , bool show)
        {
            Errors.Add(error);
            IsShow = show; 
        }
        public CustomErrorResponse(List<string> errors, bool show)
        {
            Errors = errors;
            IsShow = show;
        }
    }
}
