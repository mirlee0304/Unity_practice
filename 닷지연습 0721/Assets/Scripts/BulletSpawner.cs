using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {
    //총알 생성

    public float spawnRateMax = 3f;
    public float spawnRateMin = 0.5f;
    public GameObject bulletPrefab;

    private float spawnRate;
    private float timeAfterSpawn;
    private Transform target;

    private void Start()
    {
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        timeAfterSpawn = 0f;
        target = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject Bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Bullet.transform.LookAt(target);
            

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}