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
      List<Game> gameList = new List<Game>();
      List<String> gamesGenres = new List<String>();
      public NewGames(Window lastWindow)
      {
         InitializeComponent();
         Current = this;

         var dbCon = DBConnection.Instance();
         dbCon.Server = "*******";
         dbCon.DatabaseName = "*****";
         dbCon.UserName = "******";
         dbCon.Password = "*****";
         if (dbCon.IsConnect())
         {
            //suppose col0 and col1 are defined as VARCHAR in the DB
            string query = " SELECT Games.gameName, Studios.studioName, Games.dateAdded, Games.gameID " +
               "FROM Games JOIN Studios ON Studios.gameID = Games.gameID WHERE Games.dateAdded > CURDATE() - INTERVAL 12 MONTH;";
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, dbCon.Connection);
            var reader = cmd.ExecuteReader();
            gameList.Clear();
            while (reader.Read())
            {
               Game nextGame = new Game();
               nextGame.gameName = reader.GetString(0);
               nextGame.studioName = reader.GetString(1);
               nextGame.dateAdded = reader.GetDateTime(2);
               nextGame.gameID = reader.GetString(3);
               gameList.Add(nextGame);
               PopulateGameList();
            }
            reader.Close();
            dbCon.Close();
         }
      }
      private void PopulateGameList()
      {
         gameDisplay.Items.Clear();
         foreach (Game g in gameList)
         {
            g.displayCase = 3;
            gameDisplay.Items.Add(g);
         }
      }
      private void PopulateGenreList(string gameID)
      {
         genreList.Items.Clear();

         var dbCon1 = DBConnection.Instance();
         dbCon1.Server = "209.106.201.103";
         dbCon1.DatabaseName = "dbstudent4";
         dbCon1.UserName = "dbstudent4";
         dbCon1.Password = "slimydrum98";
         if (dbCon1.IsConnect())
         {
            string genreQuery = "SELECT Genres.genreName FROM Genres NATURAL JOIN GenreList NATURAL JOIN Games WHERE Games.gameID = " + gameID;
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(genreQuery, dbCon1.Connection);
            var reader2 = cmd.ExecuteReader();
            gameList.Clear();
            while (reader2.Read())
            {
               String nextGenre = reader2.GetString(0);
               gamesGenres.Add(nextGenre);
            }
            reader2.Close();
            dbCon1.Close();
         }
      }
      private void backButton_Click(object sender, RoutedEventArgs e)
      {
         //previous page
         this.Hide();
         Preselected.Current.ShowDialog();
      }

      private void gameDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
            gameList.Clear();
            Game thisGame = (Game)gameDisplay.SelectedItem;
            string myGameID = thisGame.gameID;
            PopulateGenreList(myGameID);
      }
   }
}
