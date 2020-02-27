using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XHZNL.EFDynamicDatabaseBuilding.MasterEntity
{
    /// <summary>
    /// 企业
    /// </summary>
    public class Enterprise
    {
        /// <summary>
        /// ID
        /// </summary>
        [Required]
        public Guid ID { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        [Required]
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 企业数据库名称
        /// </summary>
        [Required]
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(100)]
        public string DBName { get; set; }

        /// <summary>
        /// 企业 账号
        /// </summary>
        [Required]
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(20)]
        public string AdminAccount { get; set; }

        /// <summary>
        /// 企业 密码
        /// </summary>
        [Required]
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(50)]
        public string AdminPassword { get; set; }
    }
}
