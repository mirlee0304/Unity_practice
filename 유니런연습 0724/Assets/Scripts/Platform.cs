using UnityEngine;

// 발판으로서 필요한 동작을 담은 스크립트
public class Platform : MonoBehaviour
{
    //플레이어가 발판 밟으면 점수 추가
    private bool stepped = false;
    public GameObject[] obstacles;

    private void OnEnable()
    {
        stepped = false;
        for (int i = 0; i < obstacles.Length;i++)
        {
            if(Random.Range(0, 3)==0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player"&&!stepped)
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }
}