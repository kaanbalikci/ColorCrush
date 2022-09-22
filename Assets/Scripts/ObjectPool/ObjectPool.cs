using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool OP;

    public List<GameObject> pool = new List<GameObject>();
   // private int poolSize = 60;
    [SerializeField] private GameObject colorPrefab;


    private void Awake()
    {
        OP = this;
    }

    void Start()
    {
        /*for (int i = 0; i < poolSize; i++)
        {
            GameObject colorObj = Instantiate(colorPrefab);
            colorObj.SetActive(false);
            pool.Add(colorObj);
        }*/
    }


    public GameObject GetObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        return null;
    }
}
