namespace Mb.Application.Common.Models;

public class ServiceResult
{
    public ServiceResult()
    {
    }

    public ServiceResult(ServiceError error)
    {
        if (error == null)
            error = ServiceError.DefaultError;

        Error = error;
    }

    public bool Succeeded => Error == null;

    public ServiceError Error { get; set; }

    public static ServiceResult Failed(ServiceError error)
    {
        return new(error);
    }

    public static ServiceResult<T> Failed<T>(ServiceError error)
    {
        return new(error);
    }

    public static ServiceResult<T> Failed<T>(T data, ServiceError error)
    {
        return new(data, error);
    }

    public static ServiceResult<T> Success<T>(T data)
    {
        return new(data);
    }
}

/// <summary>
///     A standard response for service calls.
/// </summary>
/// <typeparam name="T">Return data type</typeparam>
public class ServiceResult<T> : ServiceResult
{
    public ServiceResult(T data)
    {
        Data = data;
    }

    public ServiceResult(T data, ServiceError error) : base(error)
    {
        Data = data;
    }

    public ServiceResult(ServiceError error) : base(error)
    {
    }

    public T Data { get; set; }
}