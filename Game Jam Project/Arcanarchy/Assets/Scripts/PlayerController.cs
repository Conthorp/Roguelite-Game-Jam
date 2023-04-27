using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hp = 10;
    public float exp = 0;
    public float damage = 1;
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

        if(Input.GetMouseButtonDown(1))
        {
            Ability();
        }

        moveDirection = new Vector2(moveDirectionX, moveDirectionY).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
        aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(bullet, wandPosition.position, wandPosition.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(wandPosition.up * shootForce, ForceMode2D.Impulse);
    }

    void Ability()
    {
        
    }

    public void Death()
    {
        Debug.Log("You Die");
    }

    }
