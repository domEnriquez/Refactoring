using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class GameRunner
    {

        private static bool notAWinner;

        public static void Main(String[] args)
        {
            List<Questions> q =  new List<Questions>() { new PopQuestions(),
                                           new ScienceQuestions(),
                                           new SportsQuestions(),
                                           new RockQuestions() };
            Game aGame = new Game(q);

            aGame.Add(new Player("Chet"));
            aGame.Add(new Player("Pat"));
            aGame.Add(new Player("Sue"));

            Random rand = new Random();

            do
            {

                aGame.rollEvent(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                {
                    notAWinner = aGame.wrongAnswer();
                }
                else
                {
                    notAWinner = aGame.wasCorrectlyAnswered();
                }



            } while (notAWinner);
        }


    }

}

