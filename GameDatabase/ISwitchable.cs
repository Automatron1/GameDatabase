using System;
using System.Collections.Generic;
using System.Text;

namespace GameDatabase
{
   public interface ISwitchable
   {
      void ControlActivated(object state);
   }
}
