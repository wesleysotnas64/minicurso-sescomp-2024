using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(upKey) && transform.position.y < 2.25f) transform.Translate(0, speed*Time.deltaTime, 0);
        if(Input.GetKey(downKey) && transform.position.y > -3.25f) transform.Translate(0, -speed*Time.deltaTime, 0);
    }
}
