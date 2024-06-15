using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject knife;
    public float minX = -2.5f, maxX = 2.5f;
    public float spawnTimeMin = 0.5f, spawnTimeMax = 1f;

    void Start()
    {
        StartCoroutine(SpawnKnife());
      //Invoke("SpawnKnife",Random.Range(spawnTimeMin, spawnTimeMax));
    }

  /*void SpawnKnife()
    {
        float x = Random.Range(minX, maxX);
      //Quaternion knifeRot = Quaternion.Euler(0, 0, 90);
        GameObject k = Instantiate(knife, new Vector2(x, transform.position.y), knife.transform.localRotation);
        Invoke("SpawnKnife", (Random.Range(spawnTimeMin, spawnTimeMax)));

    }*/


    IEnumerator SpawnKnife()
    {
        yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));
        GameObject k = Instantiate(knife);
        float x = Random.Range(minX, maxX);
        k.transform.position = new Vector2(x, transform.position.y);
        StartCoroutine(SpawnKnife());
    }


}
