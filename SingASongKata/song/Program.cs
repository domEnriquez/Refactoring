using System;
using System.Collections.Generic;

namespace song
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> animals = new List<string> { "fly", "spider", "bird", "cat", "dog", "cow", "horse" };
            Console.WriteLine(GenerateSong(animals));
        }

        private static string GenerateSong(List<string> animals)
        {

            string oldLadySwallowed = "There was an old lady who swallowed a ";
            string dontKnowWhySheSwallowed = "I don't know why she swallowed a ";

            return
                oldLadySwallowed + "fly."
                + "\n" +
                dontKnowWhySheSwallowed + "fly - perhaps she'll die!"

                + "\n\n" +

                oldLadySwallowed + "spider;"
                + "\n" +
                "That wriggled and wiggled and tickled inside her."
                + "\n" +
                "She swallowed the spider to catch the fly;"
                + "\n" +
                dontKnowWhySheSwallowed + "fly - perhaps she'll die!"

                + "\n\n" +

                oldLadySwallowed + "bird;"
                + "\n" +
                "How absurd to swallow a bird."
                + "\n" +
                "She swallowed the bird to catch the spider,"
                + "\n" +
                "She swallowed the spider to catch the fly;"
                + "\n" +
                dontKnowWhySheSwallowed + "fly - perhaps she'll die!"

                + "\n\n" +

                oldLadySwallowed + "cat;"
                + "\n" +
                "Fancy that to swallow a cat!"
                + "\n" +
                "She swallowed the cat to catch the bird,"
                + "\n" +
                "She swallowed the bird to catch the spider,"
                + "\n" +
                "She swallowed the spider to catch the fly;"
                + "\n" +
                dontKnowWhySheSwallowed + "fly - perhaps she'll die!"

                + "\n\n" +

                oldLadySwallowed + "dog;"
                + "\n" +
                "What a hog, to swallow a dog!"
                + "\n" +
                "She swallowed the dog to catch the cat,"
                + "\n" +
                "She swallowed the cat to catch the bird,"
                + "\n" +
                "She swallowed the bird to catch the spider,"
                + "\n" +
                "She swallowed the spider to catch the fly;"
                + "\n" +
                dontKnowWhySheSwallowed + "fly - perhaps she'll die!"

                + "\n\n" +

                oldLadySwallowed + "cow;"
                + "\n" +
                "I don't know how she swallowed a cow!"
                + "\n" +
                "She swallowed the cow to catch the dog,"
                + "\n" +
                "She swallowed the dog to catch the cat,"
                + "\n" +
                "She swallowed the cat to catch the bird,"
                + "\n" +
                "She swallowed the bird to catch the spider,"
                + "\n" +
                "She swallowed the spider to catch the fly;"
                + "\n" +
                dontKnowWhySheSwallowed + "fly - perhaps she'll die!"

                + "\n\n" +

                oldLadySwallowed + "horse..."
                + "\n" +
                "...She's dead, of course!";
        }
    }
}
