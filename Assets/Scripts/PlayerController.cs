using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    public float bounceForce = 6;
    private AudioManager audioManager;

    void Start() 
    {
        playerRb = GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnCollisionEnter(Collision collision) 
    {
        audioManager.Play("bounce");
        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce , playerRb.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if(materialName == "Safe (Instance)")
        {
            Debug.Log("Safe");
        }
        else if(materialName == "Unsafe (Instance)")
        {
            audioManager.Play("gameover");
            GameManager.gameOver = true;
        }
        else if(materialName == "LastRing (Instance)" && !GameManager.levelComplete) 
        {
            audioManager.Play("win");
            GameManager. levelComplete = true;
        }
    }

}
