using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float enemyhurt = 1  ;
    public float enemyHp = 6f;
    public float Force = 300f;
    public GameObject player;
    public float knockback = 5;
    public Renderer rend;
    public Color color;

    public bool playercanhit = true;
    public bool isFrozen = false;


    private void Start()
    {
        color = rend.material.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerHealth.instance.ChangeHp(enemyhurt);
            
            if(playercanhit)
            {
                Playerhitback();
                playercanhit = false;
            }
            StartCoroutine(CanhitPlayer());

            StartCoroutine(Invulnerable());

        }
    }

    void Playerhitback()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        player.GetComponent<Rigidbody2D>().AddForce(direction * knockback);
    }

    IEnumerator CanhitPlayer()
    {
        Debug.Log("A1");
        yield return new WaitForSeconds(1f);
        playercanhit = true;
        Debug.Log("A2");
    }

    IEnumerator Invulnerable()
    {
        Debug.Log("B1");
        Physics2D.IgnoreLayerCollision(8, 9, true);
        color.a = 0.5f;
        rend.material.color = color;
        yield return new WaitForSeconds(0.5f);
        color.a = 1f;
        rend.material.color = color; 
        Physics2D.IgnoreLayerCollision(8, 9, false);
        Debug.Log("B2");
    }


    void EnemyhitBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, -player.transform.position.normalized, Force * Time.deltaTime);
    }

    public void GetPlayerHit(float damage)
    {
        Debug.Log("GetHit");
        if(enemyHp <= 0)
        {
            Destroy(transform.gameObject);
        }
        enemyHp -= damage;
        EnemyhitBack();
    }

}
