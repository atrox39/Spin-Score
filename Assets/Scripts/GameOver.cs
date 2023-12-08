using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
  public TextMeshProUGUI maxScore;
  public TextMeshProUGUI currentScore;
  

  public void UpdateScore()
  {
    int max = PlayerPrefs.GetInt("score", 0);
    int current = PlayerPrefs.GetInt("current", 0);
    maxScore.text = string.Format("MAX SCORE\n{0}", max);
    currentScore.text = string.Format("CURRENT SCORE\n{0}", current);
  }
}
