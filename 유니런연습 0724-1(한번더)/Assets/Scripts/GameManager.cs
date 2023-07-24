using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 게임 오버 상태를 표현하고, 게임 점수와 UI를 관리하는 게임 매니저
// 씬에는 단 하나의 게임 매니저만 존재할 수 있다.
public class GameManager : MonoBehaviour {
    public GameObject gameoverText;
    public Text scoreText;

    private int score = 0;
    public static GameManager instance;
    public bool isGameover = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("two instance exist");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void Addscore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }

    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverText.SetActive(true);
    }
    
}