using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed = 50;
    void Start()
    {
        /*Disables Cursor in playmode*/
        // Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(!GameManager.isGameStarted)
            return;
        
        #if UNITY_EDITOR

        if(Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Rotate(0, -mouseX * rotateSpeed * Time.deltaTime , 0);
        }

        #endif

        #if UNITY_ANDROID
        
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            float xDelta = Input.GetTouch(0).deltaPosition.x;
            transform.Rotate(0, -xDelta * rotateSpeed * Time.deltaTime , 0);
        }

        #endif
    }
}
