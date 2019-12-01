#region 类信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-9-19 22:51:27
* Description: 用户表实体
*
* Modified By : <更新人>
* ModifiedTime: 2019-9-19 22:51:27
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
    [Table("User")]
    public class User
    {
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 登录账户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }

}
