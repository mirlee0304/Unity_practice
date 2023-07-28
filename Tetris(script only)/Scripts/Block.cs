using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //블럭 떨어지게 하기
    public float speed = 60f;
    private Rigidbody2D blockRigidbody;
    
    void Start()
    {
        blockRigidbody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
