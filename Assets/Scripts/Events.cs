using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Events : MonoBehaviour
{
//Replay Level
public void ReplayLevel()
{
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
//Quit Game
public void QuitGame()
{
Application.Quit();
}
}