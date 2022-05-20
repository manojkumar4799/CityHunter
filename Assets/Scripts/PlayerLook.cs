using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSentivity = 200f;
    public Transform player;
    float xRotation;
    public Joystick lookJoystick;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMouseLook = lookJoystick.Horizontal* mouseSentivity * Time.deltaTime;
        float yYouseLook = lookJoystick.Vertical* mouseSentivity * Time.deltaTime;

        xRotation -= yYouseLook;
       xRotation= Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.Rotate(Vector3.up*xMouseLook);
           

        
    }
}
