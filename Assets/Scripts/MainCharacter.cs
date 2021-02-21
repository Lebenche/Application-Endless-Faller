using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//<summary>Manages the behaviour of the character </summary>
public class MainCharacter : MonoBehaviour
{
  public LevelManager lm;
  [Header("Character's speed")]
  [SerializeField] private float speed;

  private Rigidbody rb;
  private Renderer rd;


  private float time;
  void Start()
  {
    time = 0f;
    rb = GetComponent<Rigidbody>();
    rd = GetComponent<Renderer>();
    
  }

  void Update()
  {
    if (time <= 1) {
      time += Time.deltaTime;
    }

    // Input for character's movement
    if (Input.GetKey(KeyCode.LeftArrow))
     {
      rb.AddForce(Vector2.left * Time.deltaTime *speed, ForceMode.Impulse);
    } 
    else if (Input.GetKey(KeyCode.RightArrow))
     {
      rb.AddForce(Vector2.right * Time.deltaTime * speed, ForceMode.Impulse);
     }

    // When the character is not visible from the camera he loose
    // The time conditions is to let the camera to render all the scene and the character
    if (!rd.isVisible && time > 1) {
      lm.GameOver();
    }

  }

  //<summary>When the player reaches the hole to go down a floor we increment the score value stored in the LevelManager's snstance </summary>

  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "scoreTrigger") {
      lm.IncrementScore();

    }
  }
}
