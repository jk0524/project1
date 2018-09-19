using UnityEngine;
using System.Collections;

public class CreateRandomPoulpi : MonoBehaviour {

  public GameObject enemyPrefab;
  public float numEnemies;
  public float xMin = 19F;
  public float xMax = 134F;
  public float yMin = 3.5F;
  public float yMax = -4.5F;

  void Start () {
  
    GameObject newParent = GameObject.Find("1 - Background Elements");

    for (int i = 0; i < numEnemies; i++)
    {
      Vector3 newPos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
      GameObject octo = Instantiate(enemyPrefab, newPos, Quaternion.identity) as GameObject;
      octo.transform.parent = newParent.transform;
    }
  
  }
}
