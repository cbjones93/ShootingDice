using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootingDice
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            player1.Name = "Bob";

            Player player2 = new Player();
            player2.Name = "Sue";

            player2.Play(player1);

            Console.WriteLine("-------------------");

            Player player3 = new Player();
            player3.Name = "Wilma";

            player3.Play(player2);

            Console.WriteLine("-------------------");

            Player large = new LargeDicePlayer();
            large.Name = "Bigun Rollsalot";

            SmackTalkingPlayer smack = new SmackTalkingPlayer();
            smack.Name = "Hugo";
            smack.Taunt = "Your father smells of elderberries!";

            OneHigherPlayer higher = new OneHigherPlayer();
            higher.Name = "Cheater";

            HumanPlayer human = new HumanPlayer();
            human.Name = "Chad";

            CreativeSmackTalkingPlayer creative = new CreativeSmackTalkingPlayer();
            creative.Name = "Charles";
            creative.Taunts.Add("No need for insults, your face says it all.");
            creative.Taunts.Add("It’s not that I’m smarter than you, it’s just that you’re dumber than everyone else.");
            creative.Taunts.Add("I like half of you half as well as I should like, and I like less than half of you half as well as you deserve!");

            SoreLoserPlayer king = new SoreLoserPlayer();
            king.Name = "King Henry";

            SoreLoserUpperHalfPlayer cheaterKing = new SoreLoserUpperHalfPlayer();
            cheaterKing.Name= "Queen of Hearts";

            player1.Play(large);



            Console.WriteLine("-------------------");

            List<Player> players = new List<Player>() {
                player1, player2, player3, large, smack, higher, human, creative, king, cheaterKing
            };

            PlayMany(players);
        }

        static void PlayMany(List<Player> players)
        {
            Console.WriteLine();
            Console.WriteLine("Let's play a bunch of times, shall we?");

            // We "order" the players by a random number
            // This has the effect of shuffling them randomly
            Random randomNumberGenerator = new Random();
            List<Player> shuffledPlayers = players.OrderBy(p => randomNumberGenerator.Next()).ToList();

            // We are going to match players against each other
            // This means we need an even number of players
            int maxIndex = shuffledPlayers.Count;
            if (maxIndex % 2 != 0)
            {
                maxIndex = maxIndex - 1;
            }

            // Loop over the players 2 at a time
            for (int i = 0; i < maxIndex; i += 2)
            {
                Console.WriteLine("-------------------");

                // Make adjacent players play noe another
                Player player1 = shuffledPlayers[i];
                Player player2 = shuffledPlayers[i + 1];
                player1.Play(player2);
            }
        }
    }
}