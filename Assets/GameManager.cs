using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * This class is in charge of handling the game after it starts
 * It handles the initial turn and every turn after that 
 * 
 * For every turn it accepts a decision from the player to either draw a card or place track
 *      It will make calls to the Player_Manager after an action is selected
 *      In the case the turn is given to an AI, it will handle calls to the AI_Manager based off certain AI conditions
 *      If a deck of cards is empty it automatically replenish the deck before the draw is made
 *      
 * The cards are handled by the Cards.cs class
 *      This includes the setup of the decks at the start of the game
 * 
 * The list of players is setup by the PlayerList class upon start up
 * 
 * Things checked at the end of the turn: 
 *      1) If the game ending condition has been met
 *          a) If so, start the ending process for the game
 *          b) After every player has had their last turn, display results
 *   
 *      
 */

public class GameManager : MonoBehaviour {

    // Variables to hold the number of players
    // Both initialized to two for testing 
    public static int NumHumanPlayers = 2;
    public static Player_Manager humans = new Player_Manager();

    public static int NumAI_Players = 2;
    public static AI_Manager ai = new AI_Manager(); 



    // Not entirely sure if this is actually needed. Since I do not think the game manager will be referenced in other scripts.
    // I think the GameManager is going to be the one making calls to all the other scripts. 
    // We should check with Jarrett / Paul. If this is not needed than neither is the awake function.
    // - KWH
    public static GameManager instance = null;              // Static instance of GameManager which allows it to be accessed by any other script.


    //******************************************************************************************************************************************************
    // Standard Awake function for a game manager in unity.

    // May not need this since the board canvas is always one instance. (In other words, they are no different "levels" of the board).


    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------


    // Use this for initialization
    void Start()
    {

        // Sets up the starting hands for each human and AI player
        // Need to add code to allow it to implment for AI
        // Means adding a way to make AI_Manager extend Player_Manager
        for (int i = 1; i < NumHumanPlayers + NumAI_Players+1; i++)
        {

            if (i < NumHumanPlayers)
            {
                // Gives players 4 train cards
                for (int j = 0; j < 4; j++)
                {
                    humans.drawResource(i);
                }

                // Gives players 3 route cards
                for (int k = 0; k < 3; k++)
                {
                    humans.drawRoute(i);
                }
            }
        }


    }


    // Update is called once per frame
    void Update () {
	
	}
}