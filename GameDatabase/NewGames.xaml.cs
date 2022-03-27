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

      public NewGames(Window lastWindow)
      {
         InitializeComponent();
         Current = this;

         var dbCon = DBConnection.Instance();
         dbCon.Server = "209.106.201.103";
         dbCon.DatabaseName = "dbstudent4";
         dbCon.UserName = "dbstudent4";
         dbCon.Password = "slimydrum98";
         if (dbCon.IsConnect())
         {
            //suppose col0 and col1 are defined as VARCHAR in the DB
            string query = " SELECT Games.gameName, Studios.studioName, Games.dateAdded " +
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
               gameList.Add(nextGame);
               PopulateGameList();
               //string someStringFromColumnZero = reader.GetString(0);
               //ListBox.Show(someStringFromColumnZero);
            }
            reader.Close();
            // dbCon.Close();
            // querey 2
            string query1 = "SELECT Genres.genreName FROM GenreList JOIN Games ON Games.gameID = GenreList.gameID " +
               "JOIN Genres ON GenreList.genreID = Genres.genreID WHERE Games.dateAdded > CURDATE() - INTERVAL 12 MONTH;";
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
            reader.Close();
            reader1.Close();
            //dbCon.Close();
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
      private void PopulateGenreList()
      {
         genreList.Items.Clear();
         foreach (Game g in gameList)
         {
            g.displayCase = 2;
            genreList.Items.Add(g);
         }
      }
      private void backButton_Click(object sender, RoutedEventArgs e)
      {
         //previous page
         this.Hide();
         Preselected.Current.ShowDialog();
      }

   }

}
