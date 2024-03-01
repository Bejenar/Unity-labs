using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void StartFirstLevel()
    {
        SceneManager.LoadScene("Game 3/Assets/Levels/Level 1");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Game 3/Assets/Levels/Main Menu");
    }
}
