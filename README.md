# RoleOneCodeEditor
This is a simple text editor, much like one would find with Notepad although with stylistic changes to reflect my own personal tastes
The Role One Flight Simulations internal code editor has finally arrived!

Let's talk about what this bad boy can do:

We've kept the standard File, Edit, and View menu bars, but this also automatically populates line numbers as you type.
If you want tok know where you are in the document, it also displays the line number and the column number in a status bar at the bottom.

We've added the "Another Man's Treasure" font to mimic the old TRS-80 computer of the early 1980's, specifically that of the Model 3 (there were four models built, each with a similar, font, but with minor differences.  The 3 was the one I owned as a child.
Under File, we have both Save and Save As functions, which was surprisingly more difficult to do than I'd first imagined it would be, although there are a lot of concepts that I was able to utilize throughout the creation of the code.  Under 'View', we are able to turn Word Wrapping off and on, and the Edit and File menus feature most of the standard selections one would expect to find in a tool bar, along with their respective shortcut keys.

The code for this contains three forms - the first is the one I'm using to type this right here, utilizing the built-in features of the Rich Text Box.  The second is used by the Find function.  The third came about almost as an afterthought, and I almost elected not to use it becuase it required a lot of fiddling with ASCII text that I've not used since the 1990's and eventually had to simply copy/paste it into the Text Box of of the Form Designer.

There is no real functional reason behind the choice of font and styling other than simple enjoyment.  I do find the green phosphor effect to be somewhat easy on the eyes though, and it does sort of add that, "secret squirrel ninja hacker" type of vibe when using the text editor.

When running the dialog to open a file or save a file (whether that be through using Save As or the first time Save os selected with a new document), the user is presented with the classical file path dialog common across Microsoft products, and it is set up to filter out either .txt files or just show you everything.  Future iterations of this program will likely include other types of files as well, but I wanted to try and stay at least somewhat minimal-ish with this version.
