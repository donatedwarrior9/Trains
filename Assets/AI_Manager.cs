using UnityEngine;
using System.Collections;

public class AI_Manager : MonoBehaviour {

    // Use this for initialization
    void Start() {

        // Initiate Game
        InitGame(DifficultyPanel.difficulty);
    }


    void InitGame(string i)
    {
        if (DifficultyPanel.difficulty == "Easy")
        {
            // The Initial move will be an AI player must keep at least two route cards, but may keep all three route cards if he chooses.

            // From the second move on, it needs to check the cards in the AI Player's hand for the correct number of resource 
            // cards to place tracks independent of other player's moves.

            // Note: We can randomize number of cards drawn or discarded not considering of their train or route cards. (Dumb AI)

            // Remember we need to check if the tracks are adjacent because the AI Player(s) cannot block both ways in between cities.
        }

        if (DifficultyPanel.difficulty == "Hard")
        {

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}