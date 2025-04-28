using Database.Context;

namespace Business
{
    public class Result
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "Successful";
        public object? Data { get; set; }

        public Result()
        { }

        public Result(bool success, string message, object? data = null)
        {
            this.Success = success;
            this.Message = message;
            this.Data = data;
        }

        public Result DBCommit(LabInventoryContext labInventoryContext, string successMessage, string? failedMessage = null, object? data = null)
        {
            try
            {
                labInventoryContext.SaveChanges();
                return new Result(true, successMessage, data);
            }
            catch (Exception ex)
            {
                return new Result(false, failedMessage ?? ex.Message);
            }
        }
    }
}
