using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberGuesser = new NumberGuesser();
            numberGuesser.MaximumNumber=100;

            numberGuesser.InformUser();

            numberGuesser.DiscoverNumber();

            //Announce the results
            numberGuesser.AnnounceResults();

        }
    }
}
