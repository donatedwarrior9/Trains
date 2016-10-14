using UnityEngine;
using System.Collections;

public class OptionSelect : MonoBehaviour
{
    public static string option;               

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetOption(string i)                  // SetOption function that was attached to button to get the option from
    {
        option = i;                                  // Sets option 

        // Load main scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("main scene");
    }
}
