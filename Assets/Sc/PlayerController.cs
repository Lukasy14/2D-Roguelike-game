using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    private Vector2 movement;
    public float speed;


    public Transform player;
    public Transform dao;
    public bool isPlayer;
    public Boolean PPP;





    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }



    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        SwitchAnim();
        FollowMouseRotate();


    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);

    }

    void SwitchAnim()
    {
        anim.SetFloat("running", movement.magnitude);
    }

    private void FollowMouseRotate()
    {
        //获取鼠标的坐标，鼠标是屏幕坐标，Z轴为0，这里不做转换  
        Vector3 mouse = Input.mousePosition;
        //获取物体坐标，物体坐标是世界坐标，将其转换成屏幕坐标，和鼠标一直  
        Vector3 obj = Camera.main.WorldToScreenPoint(dao.position);
        //屏幕坐标向量相减，得到指向鼠标点的目标向量，即黄色线段  
        Vector3 direction = mouse - obj;
        //将Z轴置0,保持在2D平面内  
        direction.z = 0f;
        //将目标向量长度变成1，即单位向量，这里的目的是只使用向量的方向，不需要长度，所以变成1  
        direction = direction.normalized;
        //物体自身的Y轴和目标向量保持一直，这个过程XY轴都会变化数值  
        dao.up = direction;

        if (dao.eulerAngles.z < 360 && dao.eulerAngles.z >180) //|| dao.rotation.w < 0 && dao.rotation.z > 0)
        {
            player.localScale = new Vector3(1, 1, 1);

        }
        else if (dao.eulerAngles.z> 0 && dao.eulerAngles.z < 180)
        {
            player.localScale = new Vector3(-1, 1, 1);
        }

    }




}
