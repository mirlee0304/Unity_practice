using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody barRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        barRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        Vector3 newVelocity = new Vector3(xInput * speed, 0f, 0f);
        barRigidbody.velocity = newVelocity;
    }
}
