using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermitRequestApp.Core.Enum;
public enum Workflow
{
  None = 0,
  Pending = 10,
  Approved = 20,
  Rejected = 30,
  Exception = 100
}
