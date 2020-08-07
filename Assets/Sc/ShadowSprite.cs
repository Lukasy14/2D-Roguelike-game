using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour
{

    private Transform player;
    
    private SpriteRenderer thisSprite;
    private SpriteRenderer playerSprite;

    private Color color;

    [Header("时间控制参数")]
    public float activeTime;//影子显示时间
    public float activeStart;//开始显示的时间


    [Header("不透明度控制")]
    private float alpha;
    public float alphaSet;//初始值
    public float alphaMultiplier;
    private void OnEnable() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;

        thisSprite.sprite = playerSprite.sprite;

        transform.position = new Vector3(player.position.x - 0.5f, player.position.y, player.position.z);
        transform.localScale = player.localScale;
        transform.rotation = player.rotation;
       
        activeStart = Time.time;//当前时间

    }
    


    void Update()
    {
        alpha *= alphaMultiplier;
        
        color = new Color(0.5f, 0.5f, 1, alpha);

        thisSprite.color = color;

        if(Time.time >= activeStart + activeTime)
        {
            Pool.instance.InPool(this.gameObject);
        }
    }
}
