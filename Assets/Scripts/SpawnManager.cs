using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRate = 1.5f;
    private float startDelay = 1.5f;
    private float spawnRateInterval = 0.02f;
    private GameManager gameManager;

    public GameObject[] spawnPos;

    public GameObject stone;
    public GameObject animal;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(SpawnObstacle());
        
    }

    void Spawn()
    {
        int random_Index = Random.Range(0, spawnPos.Length);

        Vector3 animal_SpawnPos = spawnPos[random_Index].transform.position;
   

        for (int i=0; i<spawnPos.Length;i++)
        {
            if(i== random_Index)
            {
                Instantiate(animal, animal_SpawnPos, animal.transform.rotation);
            }

            else
            {
                Instantiate(stone, spawnPos[i].transform.position, stone.transform.rotation);
            }
        }
    }

    IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(startDelay);

        while(gameManager.is_activate)
        {
            Spawn();
            yield return new WaitForSeconds(spawnRate);
            spawnRate -= spawnRateInterval;
        }


    }


}
