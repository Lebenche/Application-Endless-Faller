using UnityEngine;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

// <summary> Manages the behaviour of the platform </summary> 
public class MovingPlatform : MonoBehaviour
{
  [SerializeField] private float speed;
  private float topHeight =7.5f;
  [Header("Y Position of platform spawner")]
  [SerializeField] private float platformInitialY = -15;

  private float currentDifficulty = 1.1f;

  private float time = 0f;
  private float previousTime;

  private static int spawnRate =0;
  private static float timeUntilSpeedIncrease = 15;


  //XML 
  static XmlDocument xmlTexts = new XmlDocument();
  static XmlNode spawnRateNode;
  void Start()
  {
    previousTime = time;
    LoadSpawnRate();
  }

    // Update is called once per frame
  void Update()
  {
    
    time += Time.deltaTime;
    //Each seconds defined in timeUntilSpeedIncrease the speed of the platform increase.
    if (time > previousTime + timeUntilSpeedIncrease) {
      currentDifficulty += .5f;
      previousTime = time;
      /* if (spawnRate<3) {
        spawnRate += 1;
        print("spawn Rate : "+spawnRate);
      } */

    }
    transform.position += Vector3.up * Time.deltaTime * speed * currentDifficulty;

    if (gameObject.transform.position.y >topHeight) 
    {
      gameObject.transform.position = new Vector3(Random.Range(-6.54f, 1.25f), platformInitialY+spawnRate, 0.01f);
    }
 }

  //<summary> We load the spawn Rate Value stored in the xml file </summary>
  public static void LoadSpawnRate()
  {

    xmlTexts.Load("config.xml");
    
    spawnRateNode = xmlTexts.SelectSingleNode("int");

    try {

      spawnRate = int.Parse(spawnRateNode.InnerText);

    }
    catch (System.Exception e) {
      print("Error in reading XML parameters : " + e);
    }

  }

}