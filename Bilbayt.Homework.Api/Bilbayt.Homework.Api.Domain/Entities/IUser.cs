namespace Bilbayt.Homework.Api.Domain.Entities
{
    public interface IUser : IBaseEntity
    {
        string UserName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string FullName { get; set; }
    }
}