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

      public DBConnection DatabaseConnection()
      {
         var dbCon = DBConnection.Instance();
         dbCon.Server = "209.106.201.103";
         dbCon.DatabaseName = "dbstudent4";
         dbCon.UserName = "dbstudent4";
         dbCon.Password = "slimydrum98";
         return dbCon;
      }
      public NewGames(Window lastWindow)
      {
         InitializeComponent();
         Current = this;
         PopulateGameList();
      }
      private void gameDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         gameList.Clear();
         Game thisGame = (Game)gameDisplay.SelectedItem;
         string myGameID = thisGame.gameID;
         genreList.Items.Clear();

         var dbCon = DatabaseConnection();
         if (dbCon.IsConnect())
         {
            string genreQuery = "SELECT Genres.genreName FROM Genres NATURAL JOIN GenreList NATURAL JOIN Games WHERE Games.gameID = 6";
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(genreQuery, dbCon.Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               String nextGenre = reader.GetString(0);
               genreList.Items.Add(nextGenre);
            }
            //PopulateGenreList(myGameID);
            reader.Close();
            dbCon.Close();
         }
      }
      private void PopulateGameList()
      {
         var dbCon = DatabaseConnection();
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
            }
            //Game nextGame = new Game();
            //nextGame.gameName = "name";
            //gameList.Add(nextGame);
            //PopulateGameList();
            //THIS IS SAMPLE TEST DATA 
            gameDisplay.Items.Clear();
            foreach (Game g in gameList)
            {
               g.displayCase = 3;
               gameDisplay.Items.Add(g);
            }
            reader.Close();
            dbCon.Close();
         }
      }
      private void PopulateGenreList(string gameID)
      {
         genreList.Items.Clear();
      }
      private void backButton_Click(object sender, RoutedEventArgs e)
      {
         //previous page
         this.Hide();
         Preselected.Current.ShowDialog();
      }
   }
}