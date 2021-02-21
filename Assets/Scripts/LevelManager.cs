using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using System.Xml;
using System;
using System.Xml.Serialization;
using System.IO;
/// <summary> Manages the state of the level </summary>
public class LevelManager : MonoBehaviour
{
  public int Score { get; private set; }
  public int HighScore { get; private set; }

  public bool isGameOver = false;

  [Header("Texts used ingame")]
  [SerializeField]
  private TextMeshProUGUI scoreGameText;

  [SerializeField]
  private TextMeshProUGUI scoreMenuText;

  [SerializeField]
  private TextMeshProUGUI highScoreMenuText;

  [SerializeField]
  private GameObject highScoreNotification;

  [Header("Particle used when HighScore reached")]
  [SerializeField]
  private ParticleSystem highScoreParticlePlayer;

  //XML 
 static XmlDocument xmlTexts = new XmlDocument();
  XmlNodeList nodelist;
  static XmlNode HighScoreNode;
  public static string highscoreText;

  void Start()
  {

    Reset();
    LoadHighScore();
    HighScore = int.Parse(highscoreText);
    highScoreParticlePlayer.Stop();
    highScoreNotification.SetActive(false);
  }

  //<summary> We increment the score and we check if player reached the High Score </summary>
  public void IncrementScore()
  {
    Score++;
    scoreGameText.text = "Score : " + Score;
    scoreMenuText.text = scoreGameText.text;

    if (Score > HighScore) {
      highScoreNotification.SetActive(true);
      highScoreParticlePlayer.Play();

    }
  }

  //<summary>Allows to reset the game ant set the score to 0 for the next party</summary>
  public void Reset()
  {
    isGameOver = false;
    Score = 0;
    // reset logic
  }


  //<summary>
  //Called when the game is over, we check if the player made another Highscore.
  //In any case we display the HighScore in the game over menu
  //</summary>
  public void GameOver()
  {
    isGameOver = true;
    if (Score > HighScore) {
      HighScore = Score;
      SaveHighScore();
    }
    highScoreMenuText.text = "HighScore : " + HighScore.ToString();
  }

  //<summary> We load the high Score Value stored in the xml file </summary>
  public static void LoadHighScore()
  {
    xmlTexts.Load("highscore.xml");

    HighScoreNode = xmlTexts.SelectSingleNode("int");

    try {

      highscoreText = HighScoreNode.InnerText;
      
    }
    catch (Exception e) {
      print("Error in reading XML parameters : " + e);
    }
  }

  //<summary> Method which allows to overwrite the xml file. Called when High Score get another value </summary>
  public void SaveHighScore()
  {
    var xmlSerializer = new XmlSerializer(typeof(int));
    var fileStream = new FileStream("highscore.xml", FileMode.Create);

    xmlSerializer.Serialize(fileStream, HighScore);

    fileStream.Close();
  }
}
