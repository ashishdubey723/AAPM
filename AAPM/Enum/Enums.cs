using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAPM.Enum
{
    [Flags]
    public enum RoleTypeEnum
    {
        Admin = 1,
        Supervisor = 2,
        Employee = 3,
        Agent = 4
    }

}