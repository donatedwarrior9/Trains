using UnityEngine;
using System.Collections;

public class DifficultyPanel : MonoBehaviour
{
    public static string difficulty;              

    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }


    public void SetDifficulty(string i)                  // SetDifficulty function that was attched to button to get the difficulty from
    {
        difficulty = i;                                  // Sets difficulty 

        // Load main scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("main scene");
    }
}