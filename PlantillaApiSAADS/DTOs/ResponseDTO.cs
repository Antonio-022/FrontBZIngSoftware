using Microsoft.AspNetCore.Mvc;

namespace PlantillaApiSAADS.DTOs
{
    public class ResponsesDTO<T> : ActionResult
    {
        public T? value { get; set; }
    }

    public class ResponseListDTO<T>
    {
        public int page { get; set; }
        public int total { get; set; }
        public int quanty { get; set; }
        public List<T>? value { get; set; }
    }
    public class ResponseDTO<T>
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? value { get; set; }
    }

    public static class ResponseError<T>
    {
        public static ResponseDTO<T> Set(string message, int statusCode)
        {
            return new ResponseDTO<T>
            {
                Success = false,
                StatusCode = statusCode,
                Message = message,

            };




        }
    }
}
