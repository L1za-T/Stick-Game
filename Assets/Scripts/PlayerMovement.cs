using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpHeight = 7f; 
    public LayerMask whatIsGround; 
    public Transform groundCheckPoint; 
    public float groundCheckRadius = 0.2f;

    public AudioClip jumpSound; 
    public AudioClip footstepSound; 

    // [SerializeField] private int attackDamage = 1;
    // [SerializeField] private float attackRange = 1f;
    public Transform attackPoint;
    public LayerMask enemyLayers; 

    private Rigidbody2D body; 
    private Animator animator; 
    private AudioSource audioPlayer; 
    public bool grounded; 
    private bool facingRight = true; 


    
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontalInput*speed, body.velocity.y);
        animator.SetBool("walk", horizontalInput !=0);
        animator.SetBool("Grounded", grounded);

        if(horizontalInput != 0 && grounded)
        {
            PlaySound(footstepSound);
        }

        if(Input.GetKeyDown(KeyCode.W)&& grounded)
        {
            Jump();
        }

        if((horizontalInput>0&& !facingRight)||(horizontalInput<0&&facingRight))
        {
            Flip();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        
    }
    private void Flip(){
        Vector3 currentScale = gameObject.transform.localScale; 
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale; 
        facingRight = !facingRight; 
    }
    private void Jump(){
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        animator.SetTrigger("Jump");
        PlaySound(jumpSound);
    }

    private void PlaySound(AudioClip clip)
    {
        audioPlayer.clip = clip; 
        audioPlayer.Play();
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
        // Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayers);
        // foreach(Collider2D enemy in hitEnemies)
        // {
        //     EnemyController enemyController = enemy.GetComponent<EnemyController>();
        //     if(enemyController !=null)
        //     {
        //         enemyController.TakeDamage(attackDamage);
        //         Debug.Log("Enemy Damaged");

        //     }
        // }
    }
    // void OnDrawGizmosSelected() {
    // Gizmos.color = Color.red; 
    // Gizmos.DrawWireSphere(transform.position,attackRange);    
    // }
}