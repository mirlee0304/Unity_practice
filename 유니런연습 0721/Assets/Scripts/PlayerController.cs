using UnityEngine;

// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어한다.
public class PlayerController : MonoBehaviour {
    //오디오 관리. 점프하면 점프 오디오 , 사망하면 사망 오디오 클립 할당 
    //플레이어 움직임 구(쩜프 힘, 점프 횟수 제한 , 바닥에 닿앗는지 , 사망Die deadzone에서 ,
    //죽음을 면밀하게 구현함 벽이랑 바닥 구분해서 바닥에 충돌한 경우만 사망처리 
    public AudioClip deathClip;
    public float jumpForce = 700f;
    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private AudioSource playerAudio;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isDead)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0)&&jumpCount<2)
        {
            jumpCount++;
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
            
        }
        else if(Input.GetMouseButtonUp(0)&&playerRigidbody.velocity.y>0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
        animator.SetBool("Grounded", isGrounded);
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerRigidbody.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Dead" && !isDead)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}