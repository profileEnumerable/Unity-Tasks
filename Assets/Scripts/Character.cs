using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0F;

    [SerializeField]
    private byte livesCount = 6;

    [SerializeField]
    private float jumpForce = 17.0F;

    private Rigidbody rigidbody;
    private Animator animator;

    private SpriteRenderer sprite;

    private void Start()
    {

    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal")) Run();
        if (Input.GetButtonDown("Jump")) Jump();
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void Jump()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
}
