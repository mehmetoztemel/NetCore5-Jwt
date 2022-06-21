using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NetCore5_Jwt.Models
{
    public class CustomResponse
    {
        public object Results { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public CustomErrorResponse Error { get; private set; }

        public static CustomResponse ReturnSuccess(object data, int statusCode)
        {
            return new CustomResponse { Results = data, StatusCode = statusCode, IsSuccess = true };
        }
        public static CustomResponse ReturnSuccessNoData(int statusCode)
        {
            return new CustomResponse { Results = null, StatusCode = statusCode, IsSuccess = true };
        }
        public static CustomResponse ReturnError(CustomErrorResponse errorResponse , int statusCode)
        {
            return new CustomResponse
            {

                Error = errorResponse,
                StatusCode = statusCode,
                IsSuccess = false
            };
        }
        public static CustomResponse ReturnError(string errorResponse, int statusCode,bool show)
        {
            CustomErrorResponse error = new CustomErrorResponse(errorResponse, show);
            return new CustomResponse
            {
                Error = error,
                IsSuccess = false,
                StatusCode = statusCode
            };
        }
    }
}
