using UnityEngine;
using System.Collections;

public class HumanPlayerPanel : MonoBehaviour {
    public GameObject BotPlayerPanel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetHumanPlayer(int i)
    {
        GameManager.NumHumanPlayers = i;
        BotPlayerPanel.SetActive(true);
        gameObject.SetActive(false);
    } 
}