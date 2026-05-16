namespace Zentrack.Api.Models;

public class ApiResponse<T>
{
    public int StatusCode { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    public ApiResponse()
    {
    }

    public ApiResponse(int statusCode, bool success, string message, T? data = default)
    {
        StatusCode = statusCode;
        Success = success;
        Message = message;
        Data = data;
    }

    public static ApiResponse<T> Ok(T? data = default, string message = "Success")
    {
        return new ApiResponse<T>(200, true, message, data);
    }

    public static ApiResponse<T> Created(T? data = default, string message = "Created")
    {
        return new ApiResponse<T>(201, true, message, data);
    }

    public static ApiResponse<T> BadRequest(string message)
    {
        return new ApiResponse<T>(400, false, message);
    }

    public static ApiResponse<T> Unauthorized(string message)
    {
        return new ApiResponse<T>(401, false, message);
    }

    public static ApiResponse<T> NotFound(string message)
    {
        return new ApiResponse<T>(404, false, message);
    }

    public static ApiResponse<T> Error(string message, int statusCode = 500)
    {
        return new ApiResponse<T>(statusCode, false, message);
    }
}
