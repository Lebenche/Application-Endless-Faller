using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;
/// <summary> Manages the state of the whole application </summary>
public class GameManager : MonoBehaviour
{
  [SerializeField] private string gameScene;
  [SerializeField] private TextMeshProUGUI highScoreMenu;

  private void Start()
  {
    LevelManager.LoadHighScore();
    highScoreMenu.text = "HighScore : "+LevelManager.highscoreText;

  }
  public void Play()
  {
    SceneManager.LoadScene(gameScene);
  }

 
}