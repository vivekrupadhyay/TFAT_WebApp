using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Utility;
using Resources.Concrete;

namespace ResourceBuilder 
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new Resources.Utility.ResourceBuilder();
            string filePath = builder.Create(new DbResourceProvider(), 
                summaryCulture: "en");

            Console.WriteLine("Created file {0}", filePath);            

        }
    }
}
