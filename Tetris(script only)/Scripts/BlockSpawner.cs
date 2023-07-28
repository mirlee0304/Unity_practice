using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    //public GameObject blockPrefabs;
    //블럭 프리팹에서 각 블럭들 배열로 만들어두기
    //각 배열에서 랜덤으로 하나 블럭 골라서 복제하고 스폰시키기

    public int count = 7;
    public GameObject[] blocks;
    private Vector2 poolPosition = new Vector2(0, -30);
    private Vector2 spawnPoint = new Vector2(0, 5);

    private int currentIndex;

    private Rigidbody2D blockRigidbody;
    private GameObject currentBlock;

    private bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {

        currentIndex = Random.Range(0, 7);
        currentBlock = Instantiate(blocks[currentIndex], spawnPoint, Quaternion.identity);
        blockRigidbody = currentBlock.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded)
        {
            currentIndex = Random.Range(0, 7);
            currentBlock = Instantiate(blocks[currentIndex], spawnPoint, Quaternion.identity);
            blockRigidbody = currentBlock.GetComponent<Rigidbody2D>();
            isGrounded = false;
        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "wall")
        {
            isGrounded = true;
        }
    }

    
}
