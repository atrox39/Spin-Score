using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  public GameObject spawn1;
  public GameObject spawn2;
  public GameObject spawn3;
  public GameObject spawn4;
  public GameObject objectToSpawn;

  private int GetRandom()
  {
    System.Random random = new System.Random();
    return random.Next(0, 3);
  }

  public void Spawn()
  {
    Vector3 position = Vector3.zero;
    int choise = GetRandom();
    if (choise == 0) position = new Vector3(spawn1.transform.position.x, spawn1.transform.position.y, spawn1.transform.position.z);
    if (choise == 1) position = new Vector3(spawn2.transform.position.x, spawn2.transform.position.y, spawn2.transform.position.z);
    if (choise == 2) position = new Vector3(spawn3.transform.position.x, spawn3.transform.position.y, spawn3.transform.position.z);
    if (choise == 3) position = new Vector3(spawn4.transform.position.x, spawn4.transform.position.y, spawn4.transform.position.z);
    Instantiate(objectToSpawn, position, Quaternion.identity);
    Debug.Log(string.Format("Spaned {0} {1} {2}", position.x, position.y, position.z));
  }
}
