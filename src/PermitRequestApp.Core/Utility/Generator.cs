using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermitRequestApp.Core.Utility;
public class Generator
{

  public static Guid IdGenerator()
  {
    return Guid.NewGuid();
  }
  
}
