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

      private void Button_Click(object sender, RoutedEventArgs e)
      {
         var dbCon = DBConnection.Instance();
         dbCon.Server = "209.106.201.103";
         dbCon.DatabaseName = "dbstudent4";
         dbCon.UserName = "dbstudent4";
         dbCon.Password = "slimydrum98";
         if (dbCon.IsConnect())
         {
            //suppose col0 and col1 are defined as VARCHAR in the DB
            string query = "SELECT Games.gameName, Genres.genreName, Studios.studioName, Games.dateAdded FROM Games JOIN GenreList ON Games.gameID = GenreList.gameID JOIN Genres ON GenreList.genreID = Genres.genreID JOIN Studios ON Studios.gameID = Games.GameID;";
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, dbCon.Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               string someStringFromColumnZero = reader.GetString(0);
               //string someStringFromColumnOne = reader.GetString(1);
               MessageBox.Show(someStringFromColumnZero);
            }
            this.Hide();
            dbCon.Close();
         }
      }

      private void Button_Click_1(object sender, RoutedEventArgs e)
      {
         this.Hide();
         MainWindow.Current.ShowDialog();
         // MainWindow.Visibility = Visibility.Visible;
      }
   }
}
