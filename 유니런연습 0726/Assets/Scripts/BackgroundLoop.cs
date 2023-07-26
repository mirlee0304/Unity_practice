using UnityEngine;

// 왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치하는 스크립트
public class BackgroundLoop : MonoBehaviour {
    private float width;

    private void Awake()
    {
        BoxCollider2D boxcollider = GetComponent<BoxCollider2D>();
        width = boxcollider.size.x;
    }

    private void Update()
    {
        if(transform.position.x <= -width)
        {
            transform.position = (Vector2)transform.position + new Vector2(width * 2f, 0f);
        }
    }
}