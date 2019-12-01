#region 类信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-9-19 23:07:04
* Description: <功能描述>
*
* Modified By : <更新人>
* ModifiedTime: 2019-9-19 23:07:04
* ModifiedNote:
===================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public IList<RoleDTO> Roles { get; set; }
    }
}
