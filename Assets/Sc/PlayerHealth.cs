using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public float playerMaxHP = 6f;
    public float playerHP;

    public GameObject right;
    public GameObject mid;
    public GameObject left;
    public Sprite Full;
    public Sprite half;
    public Sprite empty;
    private Animator anim;
    
    public bool behit;



    private void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
        playerHP = playerMaxHP;
    }







    private void Update()
    {

        //FullHp.GetComponent<Image>().sprite = HalfHp;
        if (playerHP >= playerMaxHP)
        {
            left.GetComponent<Image>().sprite = Full;
            mid.GetComponent<Image>().sprite = Full;
            right.GetComponent<Image>().sprite = Full;
            playerHP = playerMaxHP;
            behit = false;
        }
        else if(playerHP != playerMaxHP)
        {
            behit = true;
        }

        if(playerHP == 0)
        {
            left.GetComponent<Image>().sprite = empty;
            Application.Quit();
        }


        if(playerHP == 5)
        {
            left.GetComponent<Image>().sprite = Full;
            mid.GetComponent<Image>().sprite = Full;
            right.GetComponent<Image>().sprite = half;

        }
        else if(playerHP == 4)
        {
            left.GetComponent<Image>().sprite = Full;
            mid.GetComponent<Image>().sprite = Full;
            right.GetComponent<Image>().sprite = empty;

        }
        else if(playerHP == 3)
        {
            left.GetComponent<Image>().sprite = Full;
            mid.GetComponent<Image>().sprite = half;

        }
        else if(playerHP == 2)
        {
            left.GetComponent<Image>().sprite = Full;
            mid.GetComponent<Image>().sprite = empty;

        }
        else if(playerHP == 1)
        {
            left.GetComponent<Image>().sprite = half;
        }

    }


    public void ChangeHp(float num)
    {
        playerHP -= num;
    }






}
