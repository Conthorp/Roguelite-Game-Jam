using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hp, exp, damage;
    public float shootForce = 5;
    public float speed = 2.5f;
    private Rigidbody2D rb;
    public Transform wandPosition;
    private Vector2 moveDirection;
    private Vector2 mousePosition;
    private Vector2 aimDirection;

    public Camera sceneCamera;
    public GameObject bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveDirectionX = Input.GetAxisRaw("Horizontal");
        float moveDirectionY = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        moveDirection = new Vector2(moveDirectionX, moveDirectionY).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        Move();
        aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(bullet, wandPosition.position, wandPosition.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(wandPosition.up * shootForce, ForceMode2D.Impulse);
    }
}
