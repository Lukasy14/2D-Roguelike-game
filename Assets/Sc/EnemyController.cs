using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;



    private void Update()
    {
        ChangeFace();
    }
    void ChangeFace()
    {
        if(Player.transform.position.x - transform.position.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(Player.transform.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }


}
