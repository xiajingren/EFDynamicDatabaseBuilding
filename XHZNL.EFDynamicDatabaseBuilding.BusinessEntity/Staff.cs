using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XHZNL.EFDynamicDatabaseBuilding.BusinessEntity
{
    /// <summary>
    /// 员工
    /// </summary>
    public class Staff
    {
        /// <summary>
        /// ID
        /// </summary>
        [Required]
        public Guid ID { get; set; }

        /// <summary>
        /// 员工名称
        /// </summary>
        [Required]
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
