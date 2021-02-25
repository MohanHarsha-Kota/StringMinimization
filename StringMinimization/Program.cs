using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMinimization
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int midp = input.Length / 2;

            StringBuilder lftpart = new StringBuilder(input.Substring(0, midp));
            StringBuilder rgtpart = new StringBuilder(input.Substring(midp));

            int counterv = 0;
            DateTime st = DateTime.Now;
            StringBuilder newjoiner = new StringBuilder(String.Empty);
            newjoiner.Append(rgtpart);
            newjoiner.Append(lftpart);
            for (int i = 0; i < midp; i++)
            {
                midp = newjoiner.Length / 2;
                char temp = newjoiner[midp];
                for (int j = midp - 1; j < newjoiner.Length; j++ )
                {
                    char v = newjoiner[j]; //Checking if the end character is equal to the mid
                    if (v == temp )
                    {
                        counterv++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (counterv != 0)
                {
                    lftpart.Clear();
                    rgtpart.Clear();
                    //Removing the repeated characters
                    lftpart.Append(newjoiner.ToString().Substring(0, midp - 1));
                    rgtpart.Append(newjoiner.ToString().Substring(midp - 1+counterv));
                    newjoiner.Clear();
                    //Generating the new Minitifed string
                    newjoiner.Append(lftpart);
                    newjoiner.Append(rgtpart);
                    counterv = 0;
                }

            }

            DateTime et = DateTime.Now;
            Console.WriteLine("Minified String: {0} , its Length: {1} and Time Taken(in ms) : {2}", newjoiner, newjoiner.Length, 
                (et-st).TotalMilliseconds);
            Console.ReadKey();

        }
    }
}
