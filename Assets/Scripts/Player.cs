using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
  public float speed = 70;
  public GameObject center;
  public GameObject gameOverMenu;
  public GameObject playerBlink;
  public GameObject pointSpawner;
  public GameObject gameUI;
  public TextMeshProUGUI scoreText;
  public TextMeshProUGUI lifesText;
  private bool left = false;
  private TrailRenderer trailPlayer;
  public int lifes = 3;
  public int score = 0;

  private Spawner spawner;

  private void Start()
  {
    int random = Random.Range(0, 1);
    if (random == 0)
    {
      left = false;
    }
    else
    {
      left = true;
    }
    trailPlayer = GetComponent<TrailRenderer>();
    spawner = pointSpawner.GetComponent<Spawner>();
    spawner.Spawn();
  }

  void OnTouch()
  {
    if (Input.touchCount > 0)
    {
      Touch touch = Input.GetTouch(0);
      if (touch.phase == TouchPhase.Began)
      {
        left = !left;
      }
    }
  }

  private void Blink()
  {
    Invoke("BlinkOn", 0f);
    Invoke("BlinkOff", 0.1f);
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Enemy"))
    {
      lifes -= 1;
      lifesText.text = string.Format("LIFES: {0}", lifes);
      Blink();
    }
    if (collision.gameObject.CompareTag("Column"))
    {
      score += 1;
      scoreText.text = score.ToString();
      spawner.Spawn();
    }
  }

  private void BlinkOn()
  {
    playerBlink.SetActive(true);
    if (trailPlayer != null)
    {
      trailPlayer.enabled = false;
    }
  }

  private void BlinkOff()
  {
    playerBlink.SetActive(false);
    if (trailPlayer != null)
    {
      trailPlayer.enabled = true;
    }
  }

  void Update()
  {
    if (lifes <= 0)
    {
      Time.timeScale = 0;
      gameOverMenu.SetActive(true);
      gameUI.SetActive(false);
      // GameOver Maxscore
      int max = PlayerPrefs.GetInt("score", 0);
      if (score > max)
      {
        PlayerPrefs.SetInt("score", score);
      }
      PlayerPrefs.SetInt("current", score);
      gameOverMenu.GetComponent<GameOver>().UpdateScore();
    }
    OnTouch();
    float direction = speed * Time.deltaTime;
    if (!left)
    {
      center.transform.Rotate(0, 0, direction);
    }
    else
    {
      center.transform.Rotate(0, 0, direction * -1);
    }
  }
}
