using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    void Update()
    {
        float h = Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
        float v = Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
        transform.position = new Vector2(transform.position.x+h,transform.position.y+v);
        faceMouse();
    }

    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x,mousePosition.y - transform.position.y);

        transform.up = direction;
    }
}
