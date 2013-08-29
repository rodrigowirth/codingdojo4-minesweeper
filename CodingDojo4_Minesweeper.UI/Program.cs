﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CodingDojo4_Minesweeper.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Bye Bye");
            }
            
        }
    }
}
