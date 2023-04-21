using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Black_jack
{
    internal class dealer
    {
        readonly Hand Hand = new();
        private card first;
        private int counted;
        private int countedD;

        public bool Stand()
        {
            return true;
        }

        public void Hit(card Card)
        {
            Hand.Setcard(Card);
        }

        public card Givecard(deck deck)
        {
            List<card> cards = deck.Getcards();
            var proceed = true;
            try
            {
                this.first = cards.First(card => card != null);
            }
            catch (InvalidOperationException) 
            {
                Console.WriteLine("There are no more cards in the deck.");
                proceed = false;
                
            }
            catch (ArgumentNullException e) 
            {
                Console.WriteLine(e.Message);
                proceed = false;
            }
            if (proceed)
            {
                return this.first;
            }
            return null;
        }

        public void Shuffle(List<card> cards , deck deck)
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                card temp = cards[k];
                cards[k] = cards[n];
                cards[n] = temp;
            }
            
            deck.Setcards(cards);

        }

        public static bool CheckCards(List<card> cards)
        {
            bool hasAce = false;
            bool hasTen = false;

            foreach (card card in cards)
            {
                var value = Convert.ToInt32(card.getvalue());
                if (card.getnaam() == "Ace")
                {
                    hasAce = true;
                }
                else if (value == 10)
                {
                    hasTen = true;
                }

                if (hasAce && hasTen)
                {
                    return true;
                }
            }

            return false;
        }

        public void checkwon(Hand hand , player player)
        {
            List<card> cards = hand.Getcards();
            bool go_on = true;
            foreach (card card in cards)
            {
                int nummer = Convert.ToInt32(card.getvalue());

                this.counted += nummer;
            }
            List<card> cards2 = this.Hand.Getcards();
            foreach (card card in cards2)
            {
                int nummer = Convert.ToInt32(card.getvalue());

                this.countedD += nummer;
            }

            if (this.counted > 21)
            {
                Console.WriteLine("player lost");
                go_on = false;
            }
            if (go_on = true && this.countedD > 21)
            {
                Console.WriteLine("player wins");
                go_on = false;
                player.playerwon();
            }
            if (go_on = true && this.counted > this.countedD ) 
            {
                Console.WriteLine("player wins");
                go_on = false;
                player.playerwon();
            }
            if (go_on = true && this.counted < this.countedD )
            {
                Console.WriteLine("player lost");
            }
            
        }
    }
}
