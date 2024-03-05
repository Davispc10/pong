using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadleController : MonoBehaviour
{
  private Vector3 myPosition;
  public float positionY;
  public float velocity = 5f;
  public float limit = 4f;
  
  public bool playerOne;
  
  public bool enableIA = false;

  public Transform ball;

  void Start()
  {
    myPosition = transform.position;
  }

  void Update()
  {
    myPosition.y = positionY;
    transform.position = myPosition;

    float deltaVelocity = velocity * Time.deltaTime;

    if (!enableIA)
    {
      if (playerOne)
      {
        if (Input.GetKey(KeyCode.W))
          positionY += deltaVelocity;
        else if (Input.GetKey(KeyCode.S))
         positionY -= deltaVelocity;
      }
      else
      {
        if (Input.GetKey(KeyCode.Return))
          enableIA = true;

        if (Input.GetKey(KeyCode.UpArrow))
          positionY += deltaVelocity;
        else if (Input.GetKey(KeyCode.DownArrow))
          positionY -= deltaVelocity;
      }
    } else
    {
      if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        enableIA = false;
      
      positionY = Mathf.Lerp(positionY, ball.position.y, 0.03f);
    }

    if (positionY < -limit)
      positionY = -limit;
    else if (positionY > limit)
      positionY = limit;
  }
}
