using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public PlayerController player;
    public Transform target;
    public XPBar myXP;
    public HealthBar myHealthBar;

    public float maxhp = 3;
    private float hp;
    public float damage = 3;
    public float speed = 3;
    public float rotateSpeed = 0.01f;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        hp = maxhp;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }

    }

    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Spell":
                hp = hp - player.damage;
                if (hp <= 0)
                {
                    Destroy(this.gameObject);
                }
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                player = collision.gameObject.GetComponent<PlayerController>();
                player.hp = player.hp - damage;
                if (player.hp <= 0)
                {
                    player.Death();
                }
                break;
        }
    }

    void TakeDamage(float currenthp, float damageTaken)
    {
        currenthp = currenthp - damageTaken;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            myXP.XPGain(100);
        }
    }

    void DealDamage(float playerHealth, float damageDealt)
    {
        playerHealth = playerHealth - damageDealt;
        myHealthBar.playerDamaged(damageDealt);
        if (playerHealth <= 0)
        {
            player.Death();
        }
    }

}
