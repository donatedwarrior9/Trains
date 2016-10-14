using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerInfo
{
    int Player;

    // Do not need this according to Jarret, it is all handled in the Card.cs

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
    // Count of train cards in draw pile
    int TrainCardsDrawPile = 0;


    // Count of train cards disposed
    int TrainCardsDisposePile = 0;                           // Note: 
                                                             // The count of the train cards disposed and the train cards still in the draw pile must be "tracked"
                                                             // so it will know when to reshuffle the train card draw pile.

    // Count of destination cards disposed
    int DestCardsDrawPile = 0;


    // Count of trains card dispose pile
    int TrainCardsDisposed = 0;
    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
}

public class GameManager : MonoBehaviour {

    public static int NumHumanPlayers = 2;                  // These were originally initialized to two, why? 
    public static int NumAI_Players = 2;

    public static GameManager instance = null;              // Static instance of GameManager which allows it to be accessed by any other script.

    public static PlayerInfo[] playerInfoArray;

    public static ResourceCard[] trainCards;

    public static ResourceCard[] routeCards;

    public static Deck<ResourceCard> PlayerDeck = new Deck<ResourceCard>();

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

        // Shuffle Resource Cards (AKA: Train Cards)
        Cards.resourceDeck.Shuffle();                    // I believe this is handled in the card class in the start function though.


        // Sets the number of arrays of PlayerInfos structs
        playerInfoArray = new PlayerInfo[GameManager.NumHumanPlayers + GameManager.NumAI_Players];

        // Sets an Array of 4 train cards
        trainCards = new ResourceCard[4];

        // Sets an Array of 3 route cards
        routeCards = new ResourceCard[3];


        for (int i = 1; i < NumHumanPlayers + NumAI_Players+1; i++)
        {
            // Sets each players count of train cards to four since that is the initial number of train cards given
            playerInfoArray[i].traincards = 4;

            // Sets each players count of route cards to three since that is the initial number of route cards given
            playerInfoArray[i].routeCards = 3;

            // Gives players 4 train cards
            for (int j = 0; j < 4; j++)
            {
                trainCards[j] = PlayerDeck.Draw();
            }

            // Gives players 3 route cards
            for (int k = 0; k < 3; k++)
            {
                trainCards[k] = PlayerDeck.Draw();
            }
        }

        // Shuffle Route Cards (AKA: Destination Cards)  // Does a deck for route (destination) cards exist in the cards.cs?

        // Give players their Route cards
        Cards.resourceDeck.Draw(4);

        // Draw river                                    // I believe this is handled in the card class in the start function though.
    }


    // Update is called once per frame
    void Update () {
	
	}
}