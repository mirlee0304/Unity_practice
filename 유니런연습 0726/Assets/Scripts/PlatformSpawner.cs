using UnityEngine;

// 발판을 생성하고 주기적으로 재배치하는 스크립트
public class PlatformSpawner : MonoBehaviour {
    public GameObject platformPrefab;

    public float timeBetSpawnMin = 1.25f;
    public float timeBetSpawnMax = 2.25f;
    private float timeBetSpawn;

    private int count = 3;

    private float lastSpawnTime;
    private GameObject[] platforms;

    private Vector2 poolPosition = new Vector2(0, -25);
    private int currentIndex = 0;

    private float xPos = 20f;
    public float yMin = -3.5f;
    public float yMax = 1.5f;

    private void Start()
    {
        timeBetSpawn = 0f;
        lastSpawnTime = 0f;

        platforms = new GameObject[count];

        for (int i = 0; i < count; i ++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }
    }

    private void Update()
    {
        if (GameManager.instance.isDead)
        { return; }

        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            float yPos = Random.Range(yMin, yMax);

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);

            currentIndex++;

            if(currentIndex>=count)
            {
                currentIndex = 0;
            }
        }
    }
}