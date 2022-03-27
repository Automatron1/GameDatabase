using System;
using System.Collections.Generic;
using System.Text;

namespace GameDatabase
{
   public class Game
   {
      public string studioName { get; set; }
      public string playerCount { get; set; }
      public DateTime dateAdded = new DateTime();
      public string gameName { get; set; }
   // public string releaseDate = null;
   //public string[] genreList = new string[13];
      public string genre { get; set; }
      public int displayCase;
      public override string ToString()
      {
         
         /*
         if (displayCase == 1)
         {
            return gameName + " Player Count: " + playerCount + " Studio: " + studioName + "\n";
         }
         else
         {
            return genre+ "\n";
         }
         */
         switch (displayCase)
         {
            case 1:
            {
               return gameName + " Player Count: " + playerCount + " Studio: " + studioName + "\n";
            }
            case 2:
            {
               return genre + "\n";
            }
            case 3:
            {
               return gameName + " Date Added: " + dateAdded + " Studio: " + studioName + "\n";
            }
            default:
               return "error default case";

         }
      }
   }
}
