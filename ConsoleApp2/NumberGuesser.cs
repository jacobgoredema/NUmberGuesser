using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    /// <summary>
    /// Ask the user to guess a number between certain a range
    /// </summary>
    public class NumberGuesser
    {
        public int MaximumNumber { get; set; }
        public int CurrentNumberOfGuesses { get; private set; }
        public int CurrentGuessMinimum { get; private set; }
        public int CurrentGuessMaximum { get; private set; }

        public NumberGuesser()
        {
            this.MaximumNumber = 100;
        }

        public void InformUser()
        {
            Console.WriteLine($"Enter a number between 0 and {this.MaximumNumber}: ");
            Console.ReadLine();
        }

        public void DiscoverNumber()
        {
            this.CurrentNumberOfGuesses = 0;
            this.CurrentGuessMinimum = this.MaximumNumber / 2;

            while (this.CurrentGuessMinimum != this.CurrentGuessMaximum)
            {
                //increase guess amount by 1
                this.CurrentNumberOfGuesses++;

                //ask the user if their number is between the guess range
                Console.WriteLine($"Is your number between {this.CurrentGuessMinimum} and {this.CurrentGuessMaximum}");

                string response = Console.ReadLine().ToLower();
                bool hasResponse = (response != null && response.Length > 0);
                if (hasResponse && (response[0] == 'y'))
                {
                    // set the next new max number
                    this.MaximumNumber = this.CurrentGuessMaximum;

                    this.CurrentGuessMaximum = this.CurrentGuessMaximum - (this.CurrentGuessMaximum - this.CurrentGuessMinimum) / 2;
                }
                else
                {
                    // The new min is one above the old max
                    this.CurrentGuessMinimum = this.CurrentGuessMaximum + 1;

                    // guess the bottom half of the new range:
                    int remainingDifference = this.MaximumNumber - this.CurrentGuessMaximum;

                    // Math.Celing will round up the remaining difference to 2, if the difference 
                    this.CurrentGuessMaximum += (int)Math.Ceiling(remainingDifference / 2f);
                }

                // if we are onlylefy with 2 numbers guess 1 on them
                if (this.CurrentGuessMinimum + 1 == this.MaximumNumber)
                {
                    this.CurrentNumberOfGuesses++;

                    // Ask the number is the lowe number
                    Console.WriteLine($"Is you number {this.CurrentGuessMinimum}?");
                    response = Console.ReadLine();

                    // if the user cnfirms their number is the lower number
                    if (response?.ToLower().FirstOrDefault() == 'y')
                    {
                        break;
                    }
                    else
                    {
                        // that means the number number be the higher of the two
                        this.CurrentGuessMinimum = MaximumNumber;
                        break;
                    }
                }
            }
        }

        public void AnnounceResults()
        {
            //Tell the user their number
            Console.WriteLine($"Your number is {this.CurrentGuessMinimum}");

            // let the user know how many guesses it took
            Console.WriteLine($"Guessed in { this.CurrentNumberOfGuesses } number of guesses");

            Console.ReadLine();
        }
    }
}
