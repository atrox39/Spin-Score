using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGlobal : MonoBehaviour
{
  public GameObject menu;
  public GameObject gameOverMenu;
  public GameObject gameUI;
  public static bool firstInit = true;

  private void Awake()
  {
    Time.timeScale = 0;
  }

  private void Start()
  {
    if (!firstInit)
    {
      InitGame();
    }
  }

  public void InitGame()
  {
    if (firstInit)
    {
      firstInit = false;
    }
    Time.timeScale = 1;
    menu.SetActive(false);
    gameUI.SetActive(true);
  }

  public void RestartGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
}
