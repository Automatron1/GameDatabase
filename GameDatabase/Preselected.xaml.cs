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
   /// Interaction logic for Preselected.xaml
   /// </summary>
   public partial class Preselected : Window
   {
      public static Preselected Current;
      public Preselected(Window lastWindow)
      {
         InitializeComponent();
         Current = this;
      }

      private void trendingGames_Click(object sender, RoutedEventArgs e)
      {
         Window lastWindow = this;
         //page to go to
         TrendingGames trendGames = new TrendingGames(lastWindow);
         this.Hide();
         trendGames.ShowDialog();
         trendGames.Show();
      }

      private void newAdditions_Click(object sender, RoutedEventArgs e)
      {
         Window lastWindow = this;
         //page to go to
         NewGames newGames = new NewGames(lastWindow);
         this.Hide();
         newGames.ShowDialog();
         newGames.Show();
      }

      private void backButton_Click(object sender, RoutedEventArgs e)
      {
         this.Hide();
         //previous page
         FindGames.Current.ShowDialog();
      }
   }
}
