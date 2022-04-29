using System.ComponentModel.DataAnnotations;

namespace EFCore.GenericRepository.Common.Entities
{
    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; } = default!;
    }
}