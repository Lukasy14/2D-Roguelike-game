using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool instance;
    public GameObject shadowPrefab;
    public int shadowCount;
    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    void Awake()
    {
        instance = this;
        FillPool();
    }

    public void FillPool()
    {
        for (int i = 0; i < shadowCount; i++)
        {
            var newShadow = Instantiate(shadowPrefab);//复制预制体
            newShadow.transform.SetParent(transform);//放到gameobject下方
            InPool(newShadow);//返回对象池
        }
    }

    public void InPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        availableObjects.Enqueue(gameObject);
    }

    public GameObject GetFormPool() 
   {
        if(availableObjects.Count == 0) 
        {
            FillPool();
        }
        var outShadow = availableObjects.Dequeue();

        outShadow.SetActive(true);

        return outShadow;
    }
}
