using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// This struct holds all player info
public class PlayerInfo
{
    // May hold a bool to indicate if player is human or not
    public bool isHuman = true; 
    int cards = 0;
    int points = 0;
    int trainCars = 0;
    public Color PLayerColor = Color.white;
}



public class PlayerList : MonoBehaviour {

    // Holds all Player info 
    // Populates this at start of game
    public static PlayerInfo[] PlayerInfos;
    
    public GameObject[] playerEntries;
    

   //----------------------------------------------------------------------------------------------------------------------------
	// Assumes GameManager.NumHumanPlayers and NumAIPlayers is already set
	void Start () {

        // Sets number of PlayerInfos 
        PlayerInfos = new PlayerInfo[GameManager.NumHumanPLayers + GameManager.NumAIPLayers];

        // Orders human players and bot players
        for (int i = 0; i < playerEntries.Length; i++)
        {
            if (i < GameManager.NumHumanPLayers)
                SetupLabel(playerEntries[i], i, false);

            else if (i < GameManager.NumHumanPLayers + GameManager.NumAIPLayers)
                SetupLabel(playerEntries[i], i+GameManager.NumAIPLayers, true);

            else
                playerEntries[i].SetActive(false);
        }
    }

    // Intializes Player labels
    void SetupLabel(GameObject label, int playerNumber, bool isBot)
    {
        // Creates new PlayerInfo struct to represent that particular player
        PlayerInfos[playerNumber] = new PlayerInfo();

        
        // UI Stuff
        label.name = label.name = (isBot) ? "Bot player" : "Human player";
        label.GetComponentInChildren<Text>().text = ((isBot) ? "Bot player " : "Human player ") + playerNumber.ToString();
        label.GetComponent<Image>().color = (playerNumber == 0) ? Color.green : (playerNumber == 1) ? Color.red : (playerNumber == 2) ? Color.blue : (playerNumber == 3) ? Color.yellow : Color.grey;



        // Initializes player color.
        PlayerInfos[playerNumber].PLayerColor = label.GetComponent<Image>().color;
        PlayerInfos[playerNumber].isHuman = !isBot;
    }


}
