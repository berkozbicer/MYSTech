namespace MYSTech.API.Exceptions
{
    public class ConflictException : InvalidOperationException
    {
        public ConflictException(string message)
            : base(message) { }
    }
}
