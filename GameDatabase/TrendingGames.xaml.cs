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
   /// Interaction logic for TrendingGames.xaml
   /// </summary>
   public partial class TrendingGames : Window
   {
      
      public static TrendingGames Current;
      List<Game> gameList = new List<Game>();
     
      public TrendingGames(Window lastWindow)
      {
         InitializeComponent();
         Current = this;
      }
      // back button
      private void Button_Click(object sender, RoutedEventArgs e)
      {
         //previous page
         this.Hide();
         Preselected.Current.ShowDialog();
      }

      private void Button_Click_1(object sender, RoutedEventArgs e)
      {
         var dbCon = DBConnection.Instance();
         dbCon.Server = "209.106.201.103";
         dbCon.DatabaseName = "dbstudent4";
         dbCon.UserName = "dbstudent4";
         dbCon.Password = "slimydrum98";
         if (dbCon.IsConnect())
         {
            //suppose col0 and col1 are defined as VARCHAR in the DB
            string query = "SELECT Games.gameName, Studios.studioName, Games.playerCount " + 
               "FROM Games JOIN Studios ON Studios.gameID = Games.GameID WHERE Games.isTrending = 1;";
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, dbCon.Connection);
            var reader = cmd.ExecuteReader();
            gameList.Clear();
            while (reader.Read())
            {
               Game nextGame = new Game();
               nextGame.gameName = reader.GetString(0);
               nextGame.studioName = reader.GetString(1);
               nextGame.playerCount = reader.GetString(2);
               gameList.Add(nextGame);
               PopulateGameList();
               //string someStringFromColumnZero = reader.GetString(0);
               //ListBox.Show(someStringFromColumnZero);
            }
            reader.Close();
           // dbCon.Close();
            // querey 2
            string query1 = "SELECT Genres.genreName FROM GenreList JOIN Games ON Games.gameID = GenreList.gameID JOIN Genres ON GenreList.genreID = Genres.genreID WHERE Games.isTrending = '1';";
            var cmd1 = new MySql.Data.MySqlClient.MySqlCommand(query1, dbCon.Connection);
            var reader1 = cmd1.ExecuteReader();
            gameList.Clear();
            while (reader1.Read())
            {
               Game nextGame = new Game();

               nextGame.genre = reader1.GetString(0);

               gameList.Add(nextGame);
               PopulateGenreList();
            }
            dbCon.Close();
         }
         
      }
      private void PopulateGameList()
      {
         gameDisplay.Items.Clear();
         foreach (Game g in gameList)
         {
            gameDisplay.Items.Add(g);
         }
      }
      private void PopulateGenreList()
      {
         genreList.Items.Clear();
         foreach (Game g in gameList)
         {
            genreList.Items.Add(g);
         }
      }
   }
}
