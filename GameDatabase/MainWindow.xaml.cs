using System;
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

namespace GameDatabase
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
      }

      private void Button_Click(object sender, RoutedEventArgs e)
      {
         var dbCon = DBConnection.Instance();
         dbCon.Server = "209.106.201.103";
         dbCon.DatabaseName = "group2";
         dbCon.UserName = "dbstudent4";
         dbCon.Password = "slimydrum98";
         if (dbCon.IsConnect())
         {
            //suppose col0 and col1 are defined as VARCHAR in the DB
            string query = "SELECT col0,col1 FROM YourTable";
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, dbCon.Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               string someStringFromColumnZero = reader.GetString(0);
               string someStringFromColumnOne = reader.GetString(1);
               Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
            }
            dbCon.Close();
         }
      }
   }
}
