using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_jack
{
    internal class Hand
    {
        private List<card> cards = new List<card>();

        public void Setcard(card Card)
        {
            cards.Add(new card( Card.getnaam() , Card.getvalue()));
        }

        public List<card> Getcards() {  return cards; }
    }
}
