/*
** BurakQuartz v1.0.0 ()
** Copyright © 2022 BurakQuartz. All rights reserved.
*/
using System.ComponentModel.DataAnnotations;

namespace EFCore.CU.GenericRepository.Common.Entities
{
    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; } = default!;
    }
}