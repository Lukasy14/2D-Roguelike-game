using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUp : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject weapon;
    public Transform father;

    private Collider2D coll;

    public bool enter = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && enter == true)
        {
            Pick(coll);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.tag == "Weapon")
        {
            enter = true;
            coll = collision;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Weapon")
        {
            enter = false;
            coll = null;
        }
    }

    void Pick(Collider2D collision)
    {
        
        {

            var newweapon = Instantiate(weapon, collision.transform.position, collision.transform.rotation = Quaternion.identity);
            newweapon.GetComponent<Collider2D>().enabled = true;
            Vector3 way = rb.position;
            Destroy(weapon);
            weapon = collision.gameObject;
            collision.transform.SetParent(father);
            collision.transform.position = way;
            collision.transform.rotation = father.rotation;
            

        }
    }
}
