using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public bool flip = false;
  public float max = 2.2f;
  public float min = 0.6f;
  public float speed = 1.2f;
  public bool vertical = false;
  float direction = 0;

  private void Awake()
  {
    speed = Random.Range(1, 1.6f);
    if (vertical)
      direction = transform.position.y;
    else
      direction = transform.position.x;
  }

  private void Move()
  {
    if (flip)
    {
      if (direction >= max)
      {
        flip = false;
      }
      direction += Time.deltaTime * speed;
    }
    else
    {
      if (direction <= min)
      {
        flip = true;
      }
      direction -= Time.deltaTime * speed;
    }
  }

  private void VerticalMovement()
  {
    Move();
    transform.localPosition = new Vector3(transform.position.x, direction, transform.position.z);
  }

  private void HorizontalMovement()
  {
    Move();
    transform.localPosition = new Vector3(direction, transform.position.y, transform.position.z);
  }

  void Update()
  {
    if (vertical)
    {
      VerticalMovement();
    }
    else
    {
      HorizontalMovement();
    }
  }
}
