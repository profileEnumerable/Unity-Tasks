using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 9.5F;
    private new SpriteRenderer renderer;
    private Vector3 direction;

    public Vector3 Direction { set => direction = value; }

    private void Awake()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.5F);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, bulletSpeed * Time.deltaTime);
    }
}
