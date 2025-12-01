namespace GameInventory.Results;


public record ServiceResult<T>(bool IsSuccess, string Message, T Data = default)
{
	public static ServiceResult<T> Success(T data, string message = "Success")
		=> new(true, message, data);

	public static ServiceResult<T> Failed(string message="Fail")
		=> new(false, message);

	public static ServiceResult<object> Success(string message = "Success")
		=> new(true, message, null);
}