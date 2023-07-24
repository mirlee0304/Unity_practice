using UnityEngine;

// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어한다.
public class PlayerController : MonoBehaviour {
    //플레이어 움직임 사망 구현, 데드존에 닿으면 사망처리
    //오디오 관리

    public AudioClip deathClip;
    public float jumpForce = 700f;
    

    private Rigidbody2D playerRigidbody;
    private AudioSource playerAudio;
    private Animator animator;

    private bool isDead;
    private bool isGrounded;
    private int jumpCount;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        isDead = false;
        isGrounded = true;
        jumpCount = 0;
    }

    private void Update()
    {
        if(isDead)
        {
            return;
        }

        if(Input.GetMouseButtonDown(0)&&jumpCount<2)
        {
            jumpCount++;
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce));

            playerAudio.Play();
        }
        /*
        else if (Input.GetMouseButtonUp(0)&&playerRigidbody.velocity.y > 0)
        {

        }
        */
        animator.SetBool("Grounded", isGrounded);
    }

    private void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerRigidbody.velocity = Vector2.zero;

        GameManager.instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Dead"&&!isDead)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.contacts[0].normal.y>0.7f)
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