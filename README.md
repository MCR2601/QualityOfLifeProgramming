# QualityOfLifeProgramming (AKA SimpleMenu)

This repository currently contains a simple Menu utility for Console projects. It allows for quick and easy creation of Menus without having to write any repetetive code yourself.

The Menu Builder provides fast changability of the menu for testing.

## How to use it

The builder-design-pattern is used to create a menu

Important to note is that it is required to use methods with the structure void (object putentialUserInput, object providedData)

Here is a simple example

    public static void PrintANumber(object num, object data)
    {
        Console.WriteLine("Number "+num);
    }
    
We want to use the method above through our menu. It has the require signature so here is the code for creating the menu

    SimpleMenu menu = new SimpleMenu.SimpleMenuBuilder("Test Menu") // Name of the menu
        .AddTopic("Number", PrintANumber, SimpleMenu.InputType.Int) // <Name of the Entry>,<Method to call>,<input type for user data>[,<additional information you want to provide to the method yourself>]
        .EnableQuickInput() // makes menus with less than 10 entries trigger without [Return] key
        .Build(); // builds the Menu

Only through these few lines we have a fully functional menu. Show it by calling the "CallMenu" method on the menu object

    menu.CallMenu();
    
The entire example can be found in the TestingApp folder
