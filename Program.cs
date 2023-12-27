using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyramide
{
    internal class Program
    {
        static int Main(string[] args)
        {
            Console.Write("Hi, please enter a number(1-40) to create a pyramide:");
            string temp = Console.ReadLine();
            int n = 0;
            try
            {
                n = Convert.ToInt32(temp);
            }
            catch (Exception h)
            {
                Console.WriteLine("Please provide number only");
                Console.ReadLine();
                return 0;
            }
            n = Convert.ToInt32(temp);
            if (n > 40 || n < 1)
            {
                Console.WriteLine("Invalid input!");
                Console.ReadLine();
                return 0;
            }

            Console.WriteLine($"n:{n}");
            //return fixed string if n is 1.
            if (n == 1) {
                Console.WriteLine(" ./\\ \n\\/__\\");
                Console.ReadLine();
                return 0;
            }

            //str to store patterns
            var str = new char[2 * n][];

            //pattern generator
            void gen(string s, int a, int b, int c, int d)
            {
                //info checking
                //Console.WriteLine($"s{s},a{a},b{b},c{c},d{d}");
                for (int i = b; i <= c; i++)
                    str[a][i] = s[(i - b + d) % s.Length];
            }

            //top side, top front, top back
            var ts = 0; var tf = 0; var tb = 0;

            for (int i = 0; i < 2 * n; i++)
            {
                str[i] = new char[5 * n];
                //top
                ts = (i < n) ? 3 * (n - i) - 2 : i - n;
                tf = (n * 3) - i - 1;
                tb = (n * 3) + i;

                //Left side pyramide
                str[i][ts] = (i < n) ? '.' : '\\';
                gen(@"`\", i, ts + 1, tf, 0);

                //front view pyramide, edge and middle
                str[i][tf] = '/';
                gen("_|_", i, tf + 1, tb - 1, i);
                str[i][tb] = '\\';
            }
            //the space at the start of left side pyramide
            for (int i = 3; i <= n; i += 2)
                str[i][(n - i) * 3 + 1] = ' ';

            //inside front view pyramide
            gen("__", 1, (n * 3) - 1, n * 3, 0);
            //3rd row replacement
            gen("__:_", 2, (n * 3) - 2, (n * 3) + 1, 0);

            //print result, comment below out because "Max Buffer Size Reached (1.5 MiB)"
            //Console.WriteLine(string.Join("\n", str.Select(x => new string(x).Replace('\0',' '))));
            //join elements inside str with "\n", but frist replace nul character with empty space.
            Console.WriteLine(string.Join("\n", str.Select(x => new string(x).Replace('\0', ' '))));
            Console.WriteLine("Press enter to exit :)");
            Console.ReadLine();
            return 0;
        }
    }
}
