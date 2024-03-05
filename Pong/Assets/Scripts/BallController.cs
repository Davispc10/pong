using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
  public Rigidbody2D rb;
  public Vector2 velocityVector;
  public Transform mainCamera;

  public float velocity = 5f;
  public float limitH = 12f;

  public AudioClip boing;

  public float delay = 2f;
  private bool gameStarted = false;

  void Start()
  {
    
  }

  void Update()
  {
    delay = delay - Time.deltaTime;

    if (delay <= 0 && gameStarted == false)
    {
      gameStarted = true;

      int direction = Random.Range(0, 4);

      switch (direction)
      {
        case 0:
          velocityVector.x = velocity;
          velocityVector.y = velocity;
          break;
        case 1:
          velocityVector.x = -velocity;
          velocityVector.y = velocity;
          break;
        case 2:
          velocityVector.x = -velocity;
          velocityVector.y = -velocity;
          break;
        case 3:
          velocityVector.x = velocity;
          velocityVector.y = -velocity;
          break;
      }

      rb.velocity = velocityVector;
    }

    if (transform.position.x > limitH || transform.position.x < -limitH)
    {
      SceneManager.LoadScene(0);
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    AudioSource.PlayClipAtPoint(boing, mainCamera.position);
  }
}
