using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float Attackdamage = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("HitEnemy");
            collision.gameObject.GetComponent<Enemy>().GetPlayerHit(Attackdamage);
        }
    }
}
