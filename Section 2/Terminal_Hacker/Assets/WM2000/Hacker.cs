using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game config data
    string[] level1Passwords = {"password", "book", "easy"};
    string[] level2Passwords = {"moneymoney", "cash", "medium"};
    string[] level3Passwords = {"yesmrpresident", "hard", "lonegunman"};
    

    //game state
    int level;
    string password;
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
        Terminal.ClearScreen();
        Terminal.WriteLine("Please enter your password:");
    }
    //for deciding what to do with user input
    void OnUserInput(string input){
        if (input == "menu"){ //we can always go direct to main menu
            showMainMenu();
        }
        else if (currentScreen == Screen.MainMenu){
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password){
            passwordCheck(input);
        }
    }
    void RunMainMenu(string input){
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber){
            level = int.Parse(input);
            StartGame();
        }
        else{
            Terminal.WriteLine("Please choose a valid level");
        }
    }
    void passwordCheck(string input){
        bool match = false;
        switch(level){
            case 1:
                foreach(string s in level1Passwords){
                    if (input == s)
                        match = true;    
                }
                if (match)
                    displayWinScreen();
                else
                    Terminal.WriteLine("Password Incorrect, try again");
                break;
            
            case 2:
                foreach(string s in level2Passwords){
                    if (input == s)
                        match = true;    
                }
                if (match)
                    displayWinScreen();
                else
                    Terminal.WriteLine("Password Incorrect, try again");
                break;
            case 3:
                foreach(string s in level3Passwords){
                    if (input == s)
                        match = true;    
                }
                if (match)
                    displayWinScreen();
                else
                    Terminal.WriteLine("Password Incorrect, try again");
                break;
        }
           
    }
    void displayWinScreen(){
        currentScreen = Screen.Win;
        Terminal.ClearScreen();  
        showLevelReward();  
    }
    void showLevelReward(){
        switch(level){
            case 1:
                Terminal.WriteLine("Have a Book...");
                Terminal.WriteLine(@"
                _________
               /       //)
              / Book  ///
             /_______/// 
             \_______\/ 
                ");
                break;
            
            case 2:
                Terminal.WriteLine("cracked the safe...");
                break;
            
            case 3:
                Terminal.WriteLine("Nuclear Weapons Codes...");
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
