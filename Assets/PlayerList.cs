using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerList : MonoBehaviour {

    public GameObject[] playerEntries;

	// Assumes GameManager.NumHumanPlayers and NumAIPlayers is already set
	void Start () {
        for (int i = 0; i < playerEntries.Length; i++)
        {
            if (i < GameManager.NumHumanPLayers)
                SetupLabel(playerEntries[i], i, false);
            else if (i < GameManager.NumHumanPLayers + GameManager.NumAIPLayers)
                SetupLabel(playerEntries[i], i, true);
            else
                playerEntries[i].SetActive(false);
        }
    }

    void SetupLabel(GameObject label, int playerNumber, bool isBot)
    {
        label.name = label.name = (isBot) ? "Bot player" : "Human player";
        label.GetComponentInChildren<Text>().text = ((isBot) ? "Bot player " : "Human player ") + playerNumber.ToString();
        label.GetComponent<Image>().color = (playerNumber == 0) ? Color.green : (playerNumber == 1) ? Color.red : (playerNumber == 2) ? Color.blue : (playerNumber == 3) ? Color.yellow : Color.grey;
    }
}
