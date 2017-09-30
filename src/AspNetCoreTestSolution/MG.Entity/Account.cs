using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MG.Entity
{
    public partial class Account : BaseEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required, MaxLength(50)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required, MaxLength(200)]
        public string Password { get; set; }

        /// <summary>
        /// 密码盐
        /// </summary>
        [Required, MaxLength(50)]
        public string PasswordSalt { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        [MaxLength(50)]
        public string NickName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [MaxLength(50)]
        public string RealName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [MaxLength(50)]
        public string Tel { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(200)]
        public string Email { get; set; }

        /// <summary>
        /// 是否验证邮箱
        /// </summary>
        [Required]
        public bool EmailChecked { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [Required, MaxLength(50)]
        public string Phone { get; set; }

        /// <summary>
        /// 是否验证手机号码
        /// </summary>
        [Required]
        public bool PhoneChecked { get; set; }

        /// <summary>
        /// 微信OpenId
        /// </summary>
        [MaxLength(200)]
        public string WeixinOpenId { get; set; }

        /// <summary>
        /// 本地头像
        /// </summary>
        [MaxLength(200)]
        public string PicUrl { get; set; }

        /// <summary>
        /// 微信头像
        /// </summary>
        [MaxLength(200)]
        public string HeadImgUrl { get; set; }

        /// <summary>
        /// 性别0：未知，1：男，2：女
        /// </summary>
        [Required]
        public int Sex { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [MaxLength(50)]
        public string QQ { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        [MaxLength(50)]
        public string Country { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        [MaxLength(50)]
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [MaxLength(50)]
        public string City { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        [MaxLength(50)]
        public string District { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [MaxLength(250)]
        public string Address { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [Column(TypeName = "text")]
        public string Note { get; set; }

        /// <summary>
        /// 账号类型
        /// </summary>
        [Required]
        public int Type { get; set; }

        /// <summary>
        /// 当前登陆时间
        /// </summary>
        [Required]
        public DateTime ThisLoginTime { get; set; }

        /// <summary>
        /// 当前登陆IP
        /// </summary>
        [MaxLength(50)]
        public string ThisLoginIP { get; set; }

        /// <summary>
        /// 最后一次登陆时间
        /// </summary>
        [Required]
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 最后一次登陆IP
        /// </summary>
        [MaxLength(50)]
        public string LastLoginIP { get; set; }

        /// <summary>
        /// 最后一次授权时间
        /// </summary>
        public DateTime? LastWeixinSignInTime { get; set; }

        /// <summary>
        /// 钱包余额
        /// </summary>
        [Required]
        public decimal Wallet { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        [Required]
        public DateTime CreateTime { get; set; }

        #region 关联

        public int? OrganizeId { get; set; }

        public virtual SysOrganize Organize { get; set; }

        public List<UserRole> UserRoles { get; set; }

        #endregion
    }
}
