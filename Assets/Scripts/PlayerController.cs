using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.5f;
    bool isJumping;
    bool isGrounded;

    Animator animator   ;
    public int coin;
    public TextMeshProUGUI coinText;
 
    public float speed;
    bool facingRight = true;

    Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();

        facingRight = true;
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {


        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y);

        if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveHorizontal < 0 && facingRight)
        {
            Flip();
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
            isJumping = true;
        }
        if (isJumping && isGrounded == true)
        {
            isJumping = false;
        }

        if (moveHorizontal == 0)
        {
            animator.SetBool("Hareket", false);
        }
        else
        {
            animator.SetBool("Hareket", true);
        }

     coinText.text = coin.ToString();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spikes"))
        {

            Debug.Log("Player hit a spike!");
            SceneManager.LoadScene(0); // Reload the current scene 
        }
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player hit a enemy!");
            SceneManager.LoadScene(0);

        }
        
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
