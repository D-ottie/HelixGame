using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public float ySpawn = 0;
    public float ringInterval = 5;
    public int numberOfRings;
    void Start()
    {
        //spawn as many rings as number of Rings
        numberOfRings = GameManager.currentLevelIndex + 6;
        SpawnRing(0);

        for(int i = 0 ; i < numberOfRings ; i++)
        {
            SpawnRing(Random.Range(1, helixRings.Length -1));
        }

        //spawn the last ring
        SpawnRing(helixRings.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRing(int ringIndex)
    {
        GameObject go = Instantiate(helixRings[ringIndex] , transform.up*ySpawn , Quaternion.identity);
        go.transform.parent = transform;
        ySpawn -= ringInterval;
    }
}
