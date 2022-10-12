using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasPassedRing : MonoBehaviour
{
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > player.transform.position.y)
        {
            FindObjectOfType<AudioManager>().Play("whoosh");
            GameManager.numberOfPassedRings++;
            GameManager.score += 3;
            Destroy(gameObject);
        }
    }
}
