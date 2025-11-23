using System.Drawing.Text;

namespace Role_One_Code_Editor
{
    public partial class RoleOneEditor : Form
    {
        private string currentFilePath = string.Empty; //This took a long time to figure out where to put, but this is what we use to make sure we can do both a "save" and "save as" thing.
        public RoleOneEditor()
        {
            InitializeComponent();
            menuStrip1.ForeColor = Color.Lime;
            menuStrip1.BackColor = Color.Black;

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainEntryWindow.Clear(); //Clears out everything from the rich text box to start a whole new file.  
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath)) //checks if you've saved before.  If not, it shuffles you on down to Save As
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                System.IO.File.WriteAllText(currentFilePath, mainEntryWindow.Text); //if you've got a filename, it just saves what you've done already.

            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog(); // This opens up a standard dialog to save a file in a manner that is pretty much 
                                                            // ubiquitous in the Microsoft sphere of influence.
            saveFile.Filter = "Text Files *.txt|*.txt|All Files *.*|*.*"; //I actually put this one in after the open dialog, but it functions the same way as the one listed below.
            if (saveFile.ShowDialog() == DialogResult.OK)  //This checks to see if the user clicked "OK" in the dialog box.
            {
                System.IO.File.WriteAllText(saveFile.FileName, mainEntryWindow.Text); //This takes the contents of the rich text box and saves it 
                                                                                      //to the path established by the user.
                currentFilePath = saveFile.FileName; //this updates the file path, so if you save it as you go, you don't get the whole Save As dialog again.
            }
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog(); // This does pretty much the same thing as the save dialog, but for opening files instead of saving them.
            openFile.Filter = "Text Files *.txt|*.txt|All Files *.*|*.*"; //This one took a bit of getting used to, since it looks like any standard string, but it's essentialls "whatever you want the user to see as an option, " vertical line, the actual filter, 
            if (openFile.ShowDialog() == DialogResult.OK) //Checks if the user clicked "OK," same as with saving
            {
                mainEntryWindow.Text = System.IO.File.ReadAllText(openFile.FileName);
            }

            currentFilePath = openFile.FileName; //If you're opening a file, this updates the file path to ensure that you're not having to go back and rename the saved file.
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainEntryWindow.Cut(); // The edit menu stuff was the probably the easiest part to code because it's all built into 
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainEntryWindow.Redo();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainEntryWindow.Undo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainEntryWindow.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainEntryWindow.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainEntryWindow.SelectAll();
        }


        //This whole thing took a lot of trips to Stack Overflow and Reddit and just good old-fashioned experimentation to figure out
        //Essentially what it does is creates a whole new form to serve as a search window, along with its own text box, label, and a button
        //very similar to how we did with the XO simulator, except we're digging more into the "dot commands" instead of fiddling with a
        //dozen other variables.
        private void findToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            findForm findForm = new findForm(mainEntryWindow);
            findForm.Show(this); //
        }

        ///Since we want to have our lines numbered, this handles that for us in side-panel
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            int firstCharacterIndex = mainEntryWindow.GetCharIndexFromPosition(new Point(0, 0)); //Starts the numbering from the first character, giving it a coordinate of 0,0 on the X,Y axes
            int firstLine = mainEntryWindow.GetLineFromCharIndex(firstCharacterIndex); //ensures our line 1 is based on the first line we have something populated in and gives it a name.

            Point lastPoint = new Point(0, mainEntryWindow.Height); //For this point, we still use 0 as the X coordinate, but we can set the Y coordinate to the height of what's been made in the main editor window.

            int lastCharacterIndex = mainEntryWindow.GetCharIndexFromPosition(lastPoint); //Same as the index number for the first location, but we're using the final point.  The start point only required two lines
                                                                                          //because it's done from the origin.
            int lastLine = mainEntryWindow.GetLineFromCharIndex(lastCharacterIndex); //This just looks at the last line in the entry window and gives it a name.

            //This part requires a bit of drawing since it seems there's no way to just automatically populate line numbers.  At least not dynamically and based on what you've entered.
            Graphics graphics = e.Graphics; //OMG SO THAT'S WHAT THE E WAS FOR!  It's always been there, but I finally have an excuse to use it since it's where we get the graphics tool we need to get it to draw the line numbers
            Font font = new Font("Another Mans Treasure MIII 64C", 14); //This is a font that mimics the old TRS-80
            Brush brush = new SolidBrush(Color.Lime); //Gotta' have that Green Phosphor look!


            ///Okay, with all of the setup done, we can actually run the loop to draw the line numbers.
            for (int i = firstLine; i <= lastLine; i++) //runs this from the first line to the last line.
            {
                Point position = mainEntryWindow.GetPositionFromCharIndex(mainEntryWindow.GetFirstCharIndexFromLine(i)); //looks at which line the first character of a row is on and gives it a name

                StringFormat stringFormat = new StringFormat();//This helps to ensure we're not writing the next line number over top of line 1.
                stringFormat.Alignment = StringAlignment.Far; //The lines up the number line to the right
                stringFormat.LineAlignment = StringAlignment.Center;//This gives us a nice centered alignment to keep the line numbers and the lines themselves even.
                graphics.DrawString((i + 1).ToString(), font, brush, new RectangleF(0, position.Y, panel1.Width - 10, 20), stringFormat); //this does the actually drawing, ensuring it's a sting.  The +1 is getting pretty intuitive at this point, especially with the word "index."
            }

            ///these two lines area actually more about memory management than anything else. They just "puts the tools away."
            brush.Dispose();
            font.Dispose();
        }
        private void mainEntryWindow_TextChanged(object sender, EventArgs e)
        {
            panel1.Invalidate(); //if something has changed, it has to draw it all over.  This ensures that we get new line numbers or get rid of unused ones
        }

        private void mainEntryWindow_VScroll(object sender, EventArgs e)
        {
            panel1.Invalidate(); //It seems kinda' odd that I would do this just because we scrolled up or down, but
                                 //the intuition behind it is that the panel with the line numbers is drawn, even though it's
                                 //drawn as a string.  This means that if we scroll the editor up and down, the line numbers would
                                 //get out of line with the actual lines, soooo...yeah.  It's only one line of code though, so it's worth it!
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //I mean...pretty much exactly what it says it'll  do.
        }

        private void mainEntryWindow_SelectionChanged(object sender, EventArgs e)
        {
            ///this generates the information for the line and column numbers based on where your cursor is
            ///if you have something highlighted, it'll just return the index of the first character you have highlighted.
            ///Now this gets a bit tricky, because every character has its own index number.  If you have 100 characters typed, you'll
            ///have index locations 0-99.  In order to figure out which column we're on, we have to see what index number our line
            ///starts on and subtract it from the index.  That difference is our column number.
            int index = mainEntryWindow.SelectionStart;
            int lineNumber = mainEntryWindow.GetLineFromCharIndex(index);
            int columnNumber = index - mainEntryWindow.GetFirstCharIndexFromLine(lineNumber);

            positionLabel.Text = $"Line: {lineNumber + 1}, Column: {columnNumber + 1}"; //the + 1 is essential because we index based on 0.
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainEntryWindow.WordWrap = !mainEntryWindow.WordWrap; //This toggles word wrap on and off
        }
    }
}
