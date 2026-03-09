namespace MYSTech.API.Exceptions
{
    public class NotFoundException : KeyNotFoundException
    {
        public NotFoundException(string entityName, int id)
            : base($"{entityName} için {id} ID'li kayıt bulunamadı.") { }

        public NotFoundException(string message)
            : base(message) { }
    }
}
