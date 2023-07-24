using UnityEngine;

// 왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치하는 스크립트
public class BackgroundLoop : MonoBehaviour {
    private float width;

    private void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }

    private void Update()
    {
        if(transform.position.x <= -width)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        transform.position = (Vector2)transform.position + new Vector2(width * 2f, 0);
    }
}