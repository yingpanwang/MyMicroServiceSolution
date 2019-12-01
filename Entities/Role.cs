#region 类信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-9-22 23:03:46
* Description: <功能描述>
*
* Modified By : <更新人>
* ModifiedTime: 2019-9-22 23:03:46
* ModifiedNote:
===================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
    }
}
