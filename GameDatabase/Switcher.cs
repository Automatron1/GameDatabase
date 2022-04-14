using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace GameDatabase

{

   public static class Switcher
   {
      public static PageSwitcher pageSwitcher;

      public static void Switch(UserControl newPage)
      {
         pageSwitcher.Navigate(newPage);
      }

      public static void CloseControl(object state)
      {
         pageSwitcher.CloseControl(state);
      }


      /*
      public static void Switch(UserControl newPage, object state)
      {
         pageSwitcher.Navigate(newPage, state);
      }
      */
   }
}
