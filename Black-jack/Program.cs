namespace Black_jack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dealer dealer = new();
            deck deck = new();
            List<player> playerlist = new List<player>();
            Console.WriteLine("welkom bij deze blackjack simulatie trainee!");
            Console.WriteLine("In dit spel gaan we je de basis leren van blackjack.");
            while (true) { 
            Console.WriteLine("als eerst beginnen we met hoeveel spelers er komen spelen? max 4");
            while (true)
            {
                var anwser = Console.ReadLine();
                int number = Convert.ToInt32(anwser);
                if (number > 4)
                {
                    Console.WriteLine("sorry maar er kunnen er maximaal 4 spelers meedoen.");
                }
                else
                {
                    for (int i = 0; i < number; i++)
                    {
                        playerlist.Add(new player());
                    }
                    break;
                }
            }
            Console.WriteLine("okie dokie, nou dat we de dealer (jij) en de spelers hebben beginnen we het spel");
            Console.WriteLine("met het shufflen van het deck kaarten.");
            Console.WriteLine("/dealer shuffled kaarten/");
            dealer.Shuffle(deck.Getcards(), deck);
            Console.WriteLine("nou dat we dat hebben gedaan kunnen we beginnen met het spel.");
            Console.WriteLine("De dealer (jij) begint met het uitdelen van kaarten 2 per speler en dealer.");
            foreach (var player in playerlist)
            {
                for (int i = 0; i < 2; i++)
                {
                    card card = dealer.Givecard(deck);
                    player.hit(card);
                }

            }
            for (int i = 0; i < 2; i++)
            {
                card dealercard = dealer.Givecard(deck);
                dealer.Hit(dealercard);
            }
            Console.WriteLine("/dealer geeft elke speler 2 kaarten en zichzelf 2 kaarten/");
            Console.WriteLine("nog 1 ding voordat we beginnen met een speler de beurt geven,");
            Console.WriteLine("de dealer moet altijd de eerste kaart");
            Console.WriteLine("met de voorkant naar boven zodat de spelrs kunnen zien wat voor kaart het is.");
            Console.WriteLine("okie dokie, laten we beginnen.");
            foreach (var player in playerlist)
            {
                Console.WriteLine("alse speler heb je (als basis) 2 keuzes,");
                Console.WriteLine("je kan hit of stand doen");
                Console.WriteLine("met hit pak je een extra kaart");
                Console.WriteLine("en met stand laat je het voor wat het is een begint de volgende speler");
                Console.WriteLine("(als deze er zijn) en dan komt de dealer.");
                while (player.klaar == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("speler:");
                    Console.WriteLine("hit of stand?");
                    Console.WriteLine("jouw kaarten:");
                    player.playershowhand();
                    string choice2 = Console.ReadLine();
                    if (choice2 == "hit")
                    {
                        card card = dealer.Givecard(deck);
                        player.hit(card);
                    }
                    if (choice2 == "stand")
                    {
                        player.Stand();
                    }
                }
                player.klaar = false;
            }
            while (dealer.klaar == false)
            {
                Console.WriteLine();
                Console.WriteLine("dealer:");
                Console.WriteLine("hit of stand?");
                Console.WriteLine("jouw kaarten:");
                dealer.dealerhand();
                string choice3 = Console.ReadLine();
                if (choice3 == "hit")
                {
                    card card = dealer.Givecard(deck);
                    dealer.Hit(card);
                }
                if (choice3 == "stand")
                {
                    dealer.Stand();
                }
            }
            dealer.klaar = false;

            Console.WriteLine("oke nu dat iedereen hun keuze heeft gemaakt gaan we kijken wie er gewonnen heeft.");
            foreach (player player in playerlist)
            {
                dealer.checkwon(player.gethand(), player);
            }
            Console.WriteLine("wil je nog een keer oefenen?");
            string choice = Console.ReadLine();
            if (choice == "ja")
            {
                Console.WriteLine("oke nog een keer.");
            }
            if (choice == "nee")
            {
                break;
            }
        }
        }
    }
}