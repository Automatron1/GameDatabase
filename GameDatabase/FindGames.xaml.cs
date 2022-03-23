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

namespace GameDatabase
{
   /// <summary>
   /// Interaction logic for FindGames.xaml
   /// </summary>
   public partial class FindGames : Window
   {
      public static FindGames Current;
      public FindGames(Window lastWindow)
      {
         InitializeComponent();
         Current = this; 
      }
      //Preselected games button
      private void Button_Click(object sender, RoutedEventArgs e)
      {
         Window lastWindow = this;
         //page to go to
         Preselected preselected = new Preselected(lastWindow);
         this.Hide();
         preselected.ShowDialog();
         preselected.Show();
      }
      //back button
      private void Button_Click_1(object sender, RoutedEventArgs e)
      {
         //previous page
         this.Hide();
         MainWindow.Current.ShowDialog();
      }
   }
}
