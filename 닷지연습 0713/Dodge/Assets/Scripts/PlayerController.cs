using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어 이동 사망 구현

public class PlayerController : MonoBehaviour {
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //addforce 말고 다른 방법 사용하기 리지드바디의 속도 변경
        Vector3 newVelocity = new Vector3(xInput * speed, 0f, zInput * speed);
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        gameObject.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}