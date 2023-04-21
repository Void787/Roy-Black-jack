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
        readonly Hand Hand = new Hand();
        private card first;

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
    }
}
