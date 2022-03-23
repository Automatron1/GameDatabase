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
   /// Interaction logic for NewGames.xaml
   /// </summary>
   public partial class NewGames : Window
   {
      public static NewGames Current;
      public NewGames(Window lastWindow)
      {
         InitializeComponent();
         Current = this;
      }

      private void backButton_Click(object sender, RoutedEventArgs e)
      {
         //previous page
         this.Hide();
         Preselected.Current.ShowDialog();
      }
   }
}
