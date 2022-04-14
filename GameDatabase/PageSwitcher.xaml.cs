using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


// Reference: https://azerdark.wordpress.com/2010/04/23/multi-page-application-in-wpf/

namespace GameDatabase
{
   /// <summary>
   /// Interaction logic for PageSwitcher.xaml
   /// </summary> 
   public partial class PageSwitcher : Window
   {
      Stack<UserControl> navigationStack = new Stack<UserControl>();

      public PageSwitcher()
      {
        InitializeComponent();
        Switcher.pageSwitcher = this;
        Switcher.Switch(new MainWindow());
      }

      public void Navigate(UserControl nextPage)
      {
         navigationStack.Push(nextPage);
         this.Content = nextPage;
      }

      public void CloseControl(object state)
      {
         _ = navigationStack.Pop();
         UserControl nextPage = navigationStack.Peek();
         ISwitchable s = nextPage as ISwitchable;

         if (s != null) 
            s.ControlActivated(state);
         else
            throw new ArgumentException("NextPage is not ISwitchable! "
              + nextPage.Name.ToString());

         this.Content = nextPage;
      }

      /*
      public void Navigate(UserControl nextPage, object state)
      {
         this.Content = nextPage;
         ISwitchable s = nextPage as ISwitchable;

         if (s != null)
            s.UtilizeState(state);
         else
            throw new ArgumentException("NextPage is not ISwitchable! "
              + nextPage.Name.ToString());
      }
      */
   }
}
