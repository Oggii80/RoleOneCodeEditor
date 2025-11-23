using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Role_One_Code_Editor
{
    public partial class findForm : Form
    {
        private RichTextBox editorTextBox;
        public findForm(RichTextBox textBox)
        {
            InitializeComponent();
            editorTextBox = textBox;
        }

        //This section was probably the trickiest to piece together
        private void searchButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchBox.Text)) //First we need to make sure that something is actually in the search box.
            {                                          //This only runs if the search box is not empty
                
                ///First we have to declare a couple of variables.  The int startPosition looks at the actual editor
                ///to see if anything is already highlighted from any previous runs, that way each press of the find 
                ///button gets us something new...or just starts over if we've gotten to the end.  The int index is where we
                ///get the actual starting position from.  Now, these things are treated like arrays, so if it finds nothing
                ///at all, it returns a value of -1, not 0. Otherwise, if it does return something, the index number
                ///is the point where that thing is found.
                int startPosition = editorTextBox.SelectionStart + editorTextBox.SelectionLength;
                int index = editorTextBox.Text.IndexOf(searchBox.Text, startPosition);

                if (index == -1) 
                {
                    ///If we get a -1 on the first pass, we check to make sure we didn't forget anything, so it goes back 
                    ///to the start of the document
                    index = editorTextBox.Text.IndexOf(searchBox.Text, 0); 
                }

                if(index != -1)
                {
                    ///If we have an index of something other than -1, we know we found something.
                    ///the "select" thing handles the highlighting, starting from the index number and ending at whatever the
                    ///length of the text in the search box is.  Scroll to Caret ensures that the screen autmomatically scrolls down to 
                    ///whatever we found in our search, and Focus brings our cursor to that point.
                    editorTextBox.Select(index, searchBox.Text.Length);
                    editorTextBox.ScrollToCaret();
                    editorTextBox.Focus();
                }
                else
                {
                    MessageBox.Show("No Results Found"); //If we've searched from the beginning and still come up with nothing,  
                                                         //we get a little pop-up box.
                }
            }
        }
    }
}
