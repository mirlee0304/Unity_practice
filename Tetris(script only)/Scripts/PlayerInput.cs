using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //input

    public float xHor;
    public float yVer;
    public bool zRot;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xHor = Input.GetAxis("Horizontal");
        yVer = Input.GetAxis("Vertical");
        zRot = Input.GetKeyDown(KeyCode.Space);
    }
}
