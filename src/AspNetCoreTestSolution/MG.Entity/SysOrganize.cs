using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MG.Infrastructure.Core;

namespace MG.Entity
{
    /// <summary>
    /// 组织机构
    /// </summary>
    public class SysOrganize : BaseEntity
    {
        [Required]
        [MaxLength(36)]
        [Column("Guid")]
        public string GuidId { get; set; }

        public int? ParentId { get; set; }

        public int? Layer { get; set; }

        [MaxLength(50)]
        public string EnCode { get; set; }

        [Required, MaxLength(50)]
        public string FullName { get; set; }

        public short? Type { get; set; }

        [MaxLength(50)]
        public string ManagerId { get; set; }

        [MaxLength(50)]
        public string TelePhone { get; set; }

        [MaxLength(200)]
        public string WeChat { get; set; }

        [MaxLength(50)]
        public string Fax { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

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

        public List<Account> Accounts { get; set; }

        #endregion
    }
}