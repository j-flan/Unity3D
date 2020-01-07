using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //game state
    int level;
    enum Screen{ MainMenu, Password, Win };
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {      
        showMainMenu();
    }
    void showMainMenu(){
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("H4ck Hack Hax\n\nPress 1 for the Library\nPress 2 for the bank\n"
            + "Press 3 for the Pentagon\n\nEnter your selection:");
    }
    void StartGame(){
        currentScreen = Screen.Password;
        Terminal.WriteLine("You ahve chosen level " + level + "\n Please enter your password:");
    }
    //for deciding what to do with user input
    void OnUserInput(string input){
        if (input == "menu"){ //we can always go direct to main menu
            showMainMenu();
        }
        else if (currentScreen == Screen.MainMenu){
            RunMainMenu(input);
        }
    }
    void RunMainMenu(string input){
         if (input == "1"){
            level = 1;
            StartGame();
        }
        else if (input == "2"){
            level = 2;
            StartGame();
        }
        else if (input == "3"){
            level = 3;
            StartGame();
        }
        else{
            Terminal.WriteLine("Please choose a valid level");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
