using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_jack
{
    internal class deck
    {
        private List<card> cards = new List<card>();
        private readonly string[] naam = { "Clubs", "Diamonds", "Hearts", "Spades" };
        private readonly string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10" };

        public deck()
        {
            foreach (string currentname in naam)
            {
                cards.Add(new card(currentname + " Ace", "1 / 10"));
                foreach (string value in values)
                {
                    cards.Add(new card(currentname + " " + value, value));
                }
                cards.Add(new card(currentname + " Jack", "10"));
                cards.Add(new card(currentname + " Queen", "10"));
                cards.Add(new card(currentname + " King", "10"));
            }
        }
    }
}
