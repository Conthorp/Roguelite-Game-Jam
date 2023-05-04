using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                break;
            case "Enemy":
                break;
            case "Spell":
                break;
            default:
                Destroy(other.gameObject);
                break;
        }
    }
}
