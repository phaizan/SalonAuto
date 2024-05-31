using Storage.Models;

namespace Storage.Extensions.Models
{
    public static class UserExtensions
    {
        public static string GetFio(this User user)
        {
            return string.Join(" ", (new string[]
            {
                user.SurName,
                user.Name,
                user.LastName
            }).Where(x => !string.IsNullOrEmpty(x)));       //возвращает те, которые не нулевые


        }
    }
}
