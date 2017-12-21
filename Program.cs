using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisEvaluationListener
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/api/logmessage";

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine($"Listening for messages at: {baseAddress}");
                Console.WriteLine("Press enter to finish");
                Console.WriteLine();
                Console.Read();
            }
        }
    }
}
