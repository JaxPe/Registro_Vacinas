using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    internal class teste
    {
        static void Mai(string[] args)
        {
            string c;
            string d;
            Console.WriteLine("RG");
            c = Console.ReadLine();
            d = FormatCnpjRg.FormatRG(c);
            Console.WriteLine(d); 
        }
    }
}
