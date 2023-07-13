using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {
    //탄알 만들기
    //탄알 만든 시간 만들 시간
    //탄알 방향 ?
    public GameObject bulletPrefab;
    public float spawnRateMax = 3f;
    public float spawnRateMin = 0.5f;

    private float timeAfterSpawn;
    private float spawnRate;
    private Transform target;

    private void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
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