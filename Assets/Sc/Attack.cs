using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float dash = 5000f;
    public float fixedtimer;
    public float timer;
    private Collider2D Coll;

    public GameObject dao;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        timer = fixedtimer;

    }


    void Update()
    {
        Coll = dao.transform.GetChild(0).gameObject.GetComponent<Collider2D>();
        Coll.enabled = false;
        timer -= Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && timer <= 0)
        {
            
            ACK();
            timer = fixedtimer;
            
        }
        
    }

    private void ACK() 
    {

        Vector3 mouse = Input.mousePosition;
        //获取物体坐标，物体坐标是世界坐标，将其转换成屏幕坐标，和鼠标一直  
        Vector3 obj = Camera.main.WorldToScreenPoint(dao.transform.position);
        //屏幕坐标向量相减，得到指向鼠标点的目标向量，即黄色线段  
        Vector3 direction = mouse - obj;
        direction = direction.normalized;
        StartCoroutine(Atk());
        Coll.enabled = true;
        rb.AddForce(new Vector2(direction.x * dash, direction.y * dash));
        StartCoroutine(getInvulnerable());
    }

    IEnumerator getInvulnerable()
    {
        yield return new WaitForSeconds(0.3f);
        Coll.enabled = false;
    }

    IEnumerator Atk()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        yield return new WaitForSeconds(0.3f);
        Physics2D.IgnoreLayerCollision(8, 9, false);


    }



}
