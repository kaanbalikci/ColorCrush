
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject gridPrefab;

    [SerializeField] private float row;
    [SerializeField] private float coloum;
    void Start()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < coloum; i++)
            {
                GameObject grid = Instantiate(gridPrefab);
                grid.transform.position = new Vector3(i, j, 0f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
