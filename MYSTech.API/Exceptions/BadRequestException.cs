namespace MYSTech.API.Exceptions
{
    public class BadRequestException : ArgumentException
    {
        public BadRequestException(string message)
            : base(message) { }
    }
}
