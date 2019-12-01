#region 类信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-11-7 18:56:57
* Description: <功能描述>
*
* Modified By : <更新人>
* ModifiedTime: 2019-11-7 18:56:57
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
    [Table("UserRole")]
    public class UserRole
    {
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleID { get; set; }
    }
}
