using UnityEngine;

// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어한다.
public class PlayerController : MonoBehaviour {
    //player death, movement, audio, animator,

    public float jumpForce = 700f;
    public AudioClip deathClip;

    private AudioSource playerAudio;
    private Animator animator;
    private Rigidbody2D playerRigidbody;

    private bool isDead = false;
    private bool isGrounded = true;
    private int jumpCount = 0;


    private void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(isDead)
        { return; }

        if(Input.GetMouseButtonDown(0)&&jumpCount<2)
        {
            jumpCount++;
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0f, jumpForce));

            playerAudio.Play();
        }
        animator.SetBool("Grounded", isGrounded);
    }

    void Die()
    {
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerRigidbody.velocity = Vector2.zero;
        isDead = true;

        GameManager.instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isDead && collision.tag == "Dead")
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