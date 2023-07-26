using UnityEngine;

// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어한다.
public class PlayerController : MonoBehaviour {
    public float jumpForce = 700f;

    private int jumpCount = 0;
    private bool isDead = false;
    private bool isGrounded = true;

    public AudioClip deathClip;

    private Rigidbody2D playerRigidbody;
    private AudioSource playerAudio;
    private Animator animator;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(isDead)
        { return; }

        if(Input.GetMouseButtonDown(0)&&jumpCount<2)
        {
            jumpCount++;
            playerAudio.Play();
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0f, jumpForce));

        }
        animator.SetBool("Grounded", isGrounded);
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
        playerRigidbody.velocity = Vector2.zero;
        playerAudio.clip = deathClip;
        playerAudio.Play();

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