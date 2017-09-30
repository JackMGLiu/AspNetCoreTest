using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MG.Entity
{
    public class SysRole : BaseEntity
    {
        [Required]
        [MaxLength(36)]
        [Column("Guid")]
        public string GuidId { get; set; }

        [MaxLength(50)]
        public string EnCode { get; set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        public short? Type { get; set; }

        [Required, MaxLength(50)]
        public string RoleName { get; set; }

        public bool? AllowEdit { get; set; }

        public int? SortCode { get; set; }

        [MaxLength(50)]
        public string CreateUser { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }

        [MaxLength(50)]
        public string ModifyUser { get; set; }

        public DateTime? ModifyTime { get; set; }

        [MaxLength(50)]
        public string Remark { get; set; }

        #region 关联

        public List<UserRole> UserRoles { get; set; }

        #endregion
    }
}