using UnityEngine;
using System.Collections;

public class AI_PlayerPanel : MonoBehaviour {
    public GameObject[] buttons;
     
	// Use this for initialization
	void Start () {
        switch (GameManager.NumHumanPlayers)
        {
            case 1:
                break;
            case 2:
                buttons[3].SetActive(false);
                break;
            case 3:
                buttons[3].SetActive(false);
                buttons[2].SetActive(false);
                break;
            case 4:
                buttons[3].SetActive(false);
                buttons[2].SetActive(false);
                buttons[1].SetActive(false);
                break;
            case 5:
                buttons[3].SetActive(false);
                buttons[2].SetActive(false);
                buttons[1].SetActive(false);
                buttons[0].SetActive(false);
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetAI_Player(int i)
    {
        GameManager.NumAI_Players = i;
        UnityEngine.SceneManagement.SceneManager.LoadScene("main scene");
        
    }
}
