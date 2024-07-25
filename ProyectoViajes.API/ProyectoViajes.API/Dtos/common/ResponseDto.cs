using Newtonsoft.Json;
namespace ProyectoViajes.API.Dtos.common
{

    public class ResponseDto<T>
     {
     public T Data { get; set; }
    public string Message { get; set; }

    [Newtonsoft.Json.JsonIgnore]

    public int StatusCode { get; set; }
    public bool Status { get; set; }
}
}
