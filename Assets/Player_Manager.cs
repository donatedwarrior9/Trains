using UnityEngine;
using System.Collections;

/*
 * Class is used to handle actions a player decides to take 
 * 
 * Plan on having this class extended by the AI_Manager
 * 
 * Info for players is stored in a static variable created in PlayerList
 * 
 */
public class Player_Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    public Player_Manager()
    {
    }
    // Called by game manager
    // states this player wants to draw a car
    // !!! NEED TO ADD RESTRICTION FOR DRAWING CARDS
    public void drawResource(int playerNumber)
    {
        ResourceCard drawn = Cards.resourceDeck.Draw();

        PlayerList.playerInfos[playerNumber].resourceCards.Add(drawn);

    }


    // Called by game manager
    // States this player wants to draw a card 
    public void drawRoute (int playerNumber)
    {

    }

    // Called by game manager
    // States the player wants to place track 
    public void placeTrack(int playerNumber)
    {

    }


	// Update is called once per frame
	void Update () {
	
	}
}
