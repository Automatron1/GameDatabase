using System;
using System.Collections.Generic;
using System.Text;

namespace GameDatabase
{
   public class Game
   {
      public string studioName { get; set; }
      public string playerCount { get; set; }
      // public string dateAdded = null;
      public string gameName { get; set; }
   // public string releaseDate = null;
   //public string[] genreList = new string[13];
      public string genre { get; set; }
      public override string ToString()
      {
         if (gameName != null)
         {
            return gameName + " Player Count: " + playerCount + " Studio: " + studioName + "\n";
         }
         else
         {
            return genre+ "\n";
         }
      }
   }
}
