using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Black_jack
{
    internal class player
    {
        Hand Hand = new Hand();
        private int winstreak;
        public bool klaar = false;

        public void Stand() 
        {
            this.klaar = true; 
        }

        public void hit(card Card)
        {
            Hand.Setcard(Card);
        }

        public void playerwon()
        {
            this.winstreak++;
        }

        public void playershowhand()
        {
            List<card> cards = Hand.Getcards();
            foreach (card card in cards)
            {
                string first = card.getnaam();
                string second = card.getvalue();
                Console.WriteLine("card Name: " + first + " Value: " + second);
            }
        }

        public Hand gethand()
        {
            return this.Hand;
        }
    }
}
