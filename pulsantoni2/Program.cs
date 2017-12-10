using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pulsantoni2
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static Form fmain;
        [STAThread]
        static void Main(string[] args)
        {
            if(args.Length!=1)
            {
                Console.WriteLine("Specificare il percorso al file di configurazione");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            fmain = new FMain(args[0]);
            Application.Run(fmain);

        }
    }
}
