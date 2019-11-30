using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharState
{
    Idle,
    Run,
    Jump,
    Sit
}

public class Character : Unit 
{
    [SerializeField] private float speed = 3.0F;

    [SerializeField] private byte livesCount = 6;

    [SerializeField] private float jumpForce = 0F;

    private bool isGrounded = false;

    private bool isSittingDown = false;

    private Bullet bullet; 

    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;

    private SpriteRenderer sprite;

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        bullet = Resources.Load<Bullet>("Bullet");
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (isGrounded) State = CharState.Idle;

        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
        if (isGrounded && (Input.GetKey(KeyCode.DownArrow))) Sit();
        if (Input.GetButtonDown("Fire1")) Shoot();
    }

    private void Run()
    {
        if (isGrounded) State = CharState.Run;

        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;

    }

    private void Jump()
    {
        State = CharState.Jump;

        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Sit()
    {
        State = CharState.Sit;       
    }

    private void Shoot()
    {
        Vector3 position = transform.position; position.y += 0.8F;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
    }


    private void CheckGround()
    {
        if (!isGrounded) State = CharState.Jump;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);

        isGrounded = colliders.Length > 1;
    }
}