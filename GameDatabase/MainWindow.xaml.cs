/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql;
using System.IO;

namespace GameDatabase
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window //UserControl , ISwitchable
   {
      public static MainWindow Current;
      public MainWindow()
      {
         InitializeComponent();
         Current = this;
      }
      // Find Games Button
      private void Button_Click(object sender, RoutedEventArgs e)
      {
         Window lastWindow = this;
         //page to go to
         FindGames findGames = new FindGames(lastWindow);
         this.Hide();
         findGames.ShowDialog();
         findGames.Show();
      }
      public void ControlActivated(object state)
      {

      }
   }
}
*/