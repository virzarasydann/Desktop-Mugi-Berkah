namespace ResponseMessageLibrary
{
    public class ActionResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        
        public static ActionResponse<T> Success(T data, string message = "Berhasil")
        {
            return new ActionResponse<T> { IsSuccess = true, Data = data, Message = message };
        }

       
        public static ActionResponse<T> Error(string message)
        {
            return new ActionResponse<T> { IsSuccess = false, Message = message };
        }
    }
}
