namespace Core.Models
{
	public class EntityResult<T> where T : class
	{
		public T? Entity { get; private set; } = null;
		public string ErrorMessage { get; private set; } = string.Empty;
		public bool IsSuccess { get; private set; }

		private EntityResult(string errorMessage)
		{
			ErrorMessage = errorMessage;
			IsSuccess = false;
		}

		private EntityResult(T entity)
		{
			Entity = entity;
			IsSuccess = true;
		}

		private EntityResult()
		{
			
		}

		public static EntityResult<T> CreateSuccessfulResult(T entity) => new(entity);
		public static EntityResult<T> CreateErrorResult(string errorMessage) => new(errorMessage);
	}
}
