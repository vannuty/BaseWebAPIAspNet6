using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [MaxLength(55)]
        public string? CreatedBy { get; set; }
        [MaxLength(55)]
        public string? UpdatedBy { get; set; }
    }
}
