using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//<summary> Manages the states of the different menus 
public class UiManager : MonoBehaviour
{
  [Header("Instance of Level Manager")]
  public LevelManager lm;

  [Header("Menus")]
  [SerializeField]  private GameObject pauseMenu;
  [SerializeField]  private GameObject gameOverMenu;

  void Start()
  {
    Time.timeScale = 1;
  }

  void Update()
  {
    // When player presses 'Esc' we open the pause menu
    if (Input.GetKeyDown(KeyCode.Escape)) {
      OpenMenu(pauseMenu);
    }

    // If the game is over we open the Game Over Menu
    if (lm.isGameOver==true) {
      OpenMenu(gameOverMenu);
    }
  }

  //<summary>We open the menu we put in paramaters and we Pause the game</summary>
  public void OpenMenu (GameObject menu)
  {
    menu.SetActive(true);
    Time.timeScale = 0;
  }

  //<summary>We close the menu we put in paramaters and we resume the game</summary>
  public void Close(GameObject menu)
  {
    menu.SetActive(false);
    Time.timeScale = 1;
  }


  //<summary>We load the scene we put in parameters </summary>
  public void LoadScene(string sceneName)
  {
    SceneManager.LoadScene(sceneName);
    Time.timeScale = 1;

  }
}
