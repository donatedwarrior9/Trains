using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// This struct holds all player info
public class PlayerInfo
{
    // May hold a bool to indicate if player is human or not
    public bool isHuman = true; 
    public int traincards = 0;
    public int routeCards = 0;
    public int points = 0;
    public int trainCars = 0;
    public Color playerColor = Color.white;
}


public class PlayerList : MonoBehaviour
{

    // Holds all Player info 
    // Populates this at start of game
    public static PlayerInfo[] playerInfos;

    public GameObject[] playerEntries;


    //----------------------------------------------------------------------------------------------------------------------------
    // Assumes GameManager.NumHumanPlayers and NumAI_Players is already set
    void Start()
    {

        // Sets number of PlayerInfos 
        playerInfos = new PlayerInfo[GameManager.NumHumanPlayers + GameManager.NumAI_Players];

        // Orders human players and bot players
        for (int i = 0; i < playerEntries.Length; i++)
        {
            if (i < GameManager.NumHumanPlayers)
                SetupLabel(playerEntries[i], i, false);

            else if (i < GameManager.NumHumanPlayers + GameManager.NumAI_Players)
                SetupLabel(playerEntries[i], i, true);

            else
                playerEntries[i].SetActive(false);
        }
    }

    // Intializes Player labels
    void SetupLabel(GameObject label, int playerNumber, bool isBot)
    {
        // Creates new PlayerInfo struct to represent that particular player
        playerInfos[playerNumber] = new PlayerInfo();


        // UI Human and Bot Tiles
        label.name = label.name = (isBot) ? "Bot player" : "Human player";
        label.GetComponentInChildren<Text>().text = ((isBot) ? "Bot player " : "Human player ") + playerNumber.ToString();
        label.GetComponent<Image>().color = (playerNumber == 0) ? Color.green : (playerNumber == 1) ? Color.red : (playerNumber == 2) ? Color.blue : (playerNumber == 3) ? Color.yellow : Color.grey;



        // Initializes player color.
        playerInfos[playerNumber].playerColor = label.GetComponent<Image>().color;
        playerInfos[playerNumber].isHuman = !isBot;
    }
}