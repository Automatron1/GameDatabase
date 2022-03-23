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
            string query = "SELECT Games.gameName, Studios.studioName, Games.playerCount FROM Games JOIN Studios ON Studios.gameID = Games.GameID WHERE Games.isTrending = 1;";
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
               PopulateList();
               //string someStringFromColumnZero = reader.GetString(0);
               //ListBox.Show(someStringFromColumnZero);
            }
            dbCon.Close();
         }
      }
      private void PopulateList()
      {
         gameDisplay.Items.Clear();
         foreach (Game g in gameList)
         {
            gameDisplay.Items.Add(g);
         }
      }
   }
}
