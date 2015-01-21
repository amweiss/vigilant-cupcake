#Vigilant Cupcake
![Vigilant Cupcake](https://amweiss.github.io/vigilant-cupcake/images/VC2-nobg-whitecake.png)

##Get v0.3.0 [here!](https://cdn.rawgit.com/amweiss/vigilant-cupcake/v0.3.0/VigilantCupcake/bin/Release/VigilantCupcake.exe)

##What is it?
Vigilant Cupcake is a tool to manage your hosts file.

[![Example Usage](https://amweiss.github.io/vigilant-cupcake/images/example.png)](https://amweiss.github.io/vigilant-cupcake/images/example.png)

##Features
* Combine multiple "fragments" to produce your hosts file
* Sync fragments with remote URLs
* Download and save files while running in the background

##Usage
The fragment list on the left is a collection of all the possible hosts file fragments you can use.

Go to `File` > `New` to create a new fragment.

Select a row to view it.

While viewing a row, you can add a Remote URL where the fragment will always sync from.
If you do this, you will not be able to edit the fragment manually.

Double click or right click an existing row to rename it.

Check the box to make the fragment active.

Right click a row and select delete to delete the fragment.

###Hotkeys
The file windows support the following hotkeys:
Main tools:
* **Ctrl+N** - create a new fragment
* **Ctrl+S** - save and flush DNS
* **Ctrl+D** - flush dns
* **Ctrl+O** - show current hosts file

In fragment editors:
* **Left, Right, Up, Down, Home, End, PageUp, PageDown** - moves caret
* **Shift+(Left, Right, Up, Down, Home, End, PageUp, PageDown)** - moves caret with selection
* **Ctrl+F, Ctrl+H** - shows Find and Replace dialogs
* **F3** - find next
* **Ctrl+G** - shows GoTo dialog
* **Ctrl+(C, V, X)** - standard clipboard operations
* **Ctrl+A** - selects all text
* **Ctrl+Z, Alt+Backspace, Ctrl+R** - Undo/Redo opertions
* **Tab, Shift+Tab** - increase/decrease left indent of selected range
* **Ctrl+Home, Ctrl+End** - go to first/last char of the text
* **Shift+Ctrl+Home, Shift+Ctrl+End** - go to first/last char of the text with selection
* **Ctrl+Left, Ctrl+Right** - go word left/right
* **Shift+Ctrl+Left, Shift+Ctrl+Right** - go word left/right with selection
* **Ctrl+-, Shift+Ctrl+-** - backward/forward navigation
* **Ctrl+U, Shift+Ctrl+U** - converts selected text to upper/lower case
* **Ctrl+Shift+C** - inserts/removes comment prefix in selected lines
* **Ins** - switches between Insert Mode and Overwrite Mode
* **Ctrl+Backspace, Ctrl+Del** - remove word left/right
* **Alt+Mouse, Alt+Shift+(Up, Down, Right, Left)** - enables column selection mode
* **Alt+Up, Alt+Down** - moves selected lines up/down
* **Shift+Del** - removes current line
* **Ctrl+B, Ctrl+Shift-B, Ctrl+N, Ctrl+Shift+N** - add, removes and navigates to bookmark
* **Esc** - closes all opened tooltips, menus and hints
* **Ctrl+Wheel** - zooming
* **Ctrl+M, Ctrl+E** - start/stop macro recording, executing of macro
* **Alt+F [char]** - finds nearest [char]
* **Ctrl+(Up, Down)** - scrolls Up/Down
* **Ctrl+(NumpadPlus, NumpadMinus, 0)** - zoom in, zoom out, no zoom
* **Ctrl+I** - forced AutoIndentChars of current line

##Requirements
* .NET 4.5 runtime

##Coming Soon
* Automatically identify conflicts
* Intelligent filtering
* Filter the merged hosts file to exclude entries you don't want
* Install from [Chocolatey](http://chocolatey.org/)
* OSX and Linux support via [Mono](http://www.mono-project.com/)

-----
Created by [Adam Weiss](https://github.com/amweiss) and [Matt Gaczewski](https://github.com/mgaczewski)

Logo created by [Todd Burnett](toddjburnett@gmail.com)

Domain donated by [Tim Finucane](https://github.com/speljamr)

Name donated by [Greg Houston](https://github.com/ghoustonjr)

------
Uses [FastColoredTextBox](https://github.com/PavelTorgashov/FastColoredTextBox)
