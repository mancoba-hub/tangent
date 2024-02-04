using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liso.Tangent
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
