using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public string gameStartScene;

    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }
}
