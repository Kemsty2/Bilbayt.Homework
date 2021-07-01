using System.ComponentModel.DataAnnotations;

namespace Bilbayt.Homework.Api.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
