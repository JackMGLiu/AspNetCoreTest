using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MG.Entity
{
    public class UserRole
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(36)]
        [Column("Guid")]
        public string GuidId { get; set; }

        [Required]
        public int UserId { get; set; }

        public Account User { get; set; }

        [Required]
        public int RoleId { get; set; }

        public SysRole Role { get; set; }

        public int? SortCode { get; set; }

        [MaxLength(50)]
        public string CreateUser { get; set; }

        [Required, Column(TypeName = "datetime")]
        public DateTime CreateTime { get; set; }
    }
}