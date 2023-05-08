using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DiDemoConsole
{
    public class ProductController
    {
        private string message = "";

        public void Index()
        {
            message = "Hello World!!";   
        }

        public void Privacy()
        {
            Console.WriteLine(message);
        }
    }
}
