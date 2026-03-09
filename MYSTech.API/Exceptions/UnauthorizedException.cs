namespace MYSTech.API.Exceptions
{
    public class UnauthorizedException : UnauthorizedAccessException
    {
        public UnauthorizedException(string message = "Bu işlem için yetkiniz bulunmamaktadır.")
            : base(message) { }
    }
}
