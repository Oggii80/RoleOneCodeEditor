using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Role_One_Code_Editor
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_KeyDown(object sender, KeyEventArgs e)
        {
            this.Hide(); //Once you've pressed the a key, this hides the splash screen
            RoleOneEditor roleOneEditor = new RoleOneEditor(); //This creates an instance of the main editor form
            roleOneEditor.ShowDialog(); //Makes sure we actually get to see the main program
            this.Close(); //once the program itself is closed, this makes sure the splash screen is also closed and not lurking about.
        }
    }
}
