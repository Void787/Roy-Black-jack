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

        public bool Stand() {
            return true; 
        }

        public void hit(card Card)
        {
            Hand.Setcard(Card);
        }

        public void playerwon()
        {
            this.winstreak++;
        }
    }
}
