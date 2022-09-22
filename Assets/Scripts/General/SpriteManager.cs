using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpriteManager : MonoBehaviour
{
    public static SpriteManager SM;

    public List<GameObject> pointList = new List<GameObject>();
    public List<GameObject> colorList = new List<GameObject>();
    public List<GameObject> spriteList = new List<GameObject>();
    

    [SerializeField] private Sprite[] blue;
    [SerializeField] private Sprite[] green;
    [SerializeField] private Sprite[] pink;
    [SerializeField] private Sprite[] red;
    
    [SerializeField] private Sprite[] newSprite;

    //Observer
    public static event Action<int> UpdateMove;
    public int moveCount;

    public bool isCountinue;

    public int controlNumber = 0;

    public bool clearAll;

    private void Awake()
    {
        SM = this;
    }

    private void Start()
    {
        //pointList[0].GetComponent<PointsScript>().isColorChange = true;
        isCountinue = true;
    }

    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Colors"))
                {
                    SpriteManager.SM.moveCount--;
                    hit.collider.GetComponent<ColorScript>().isRemove = true;
                    //hit.collider.gameObject.SetActive(false);
                    ColorStateManager.CSM.switchIdle = true;
                }
            }
        }*/



        UpdateMove?.Invoke(moveCount);

        for (int i = 0; i < ObjectPool.OP.pool.Count; i++)
        {
            if (ObjectPool.OP.pool[i].activeInHierarchy == false)
            {
                Vector2 holdPos = new Vector2(ObjectPool.OP.pool[i].transform.position.x, ObjectPool.OP.pool[i].transform.position.y + 5.4f);

                ObjectPool.OP.pool[i].transform.position = holdPos;

                ObjectPool.OP.pool[i].SetActive(true);
                ObjectPool.OP.pool[i].GetComponent<ColorScript>().isRemove = false;

                colorList.Remove(ObjectPool.OP.pool[i]);

                int x = UnityEngine.Random.Range(0, 4);
                ObjectPool.OP.pool[i].GetComponent<SpriteRenderer>().sprite = newSprite[x];
                ObjectPool.OP.pool[i].name = newSprite[x].name;

            }
        }

   



        if (isCountinue == true && controlNumber < 49 && colorList.Count > 0)
        {
            //spriteList.Clear();
            
            isCountinue = false;
            
            colorList[controlNumber].GetComponent<ColorScript>().isCheckSameColor = true;
           
            StartCoroutine(SetSpriteTimer());


            /*if (colorList[controlNumber].GetComponent<ColorScript>().isCheckSameColor == false)
            {
                
                
            }
            else
            {
                controlNumber++;
            }*/

        }
        /*if (spriteList.Count > 1)
        {
            StartCoroutine(SetSpriteTimer());
        }*/



        if (Input.GetKeyDown(KeyCode.A))
        {

            /*for (int i = 0; i < colorList.Count; i++)
            {
                if(colorList[i].GetComponent<ColorScript>().isCheckSameColor == false)
                {
                    colorList[i].GetComponent<ColorScript>().isCheckSameColor = true;
                    Thread.Sleep(1000);
                }

                for (int j = 0; j < colorList.Count; j++)
                {
                    if(colorList[j].GetComponent<ColorScript>().isCheckSameColor == true)
                    {
                        spriteList.Add(colorList[j].gameObject);
                    }
                }
                SetSprite();
                ColorScript.CS.isCheckSameColor = false;
            }*/
            //colorList[0].GetComponent<ColorScript>().isCheckSameColor = true;
            /*for (int i = 0; i < 1; i++)
            {
                if (colorList[i].GetComponent<ColorScript>().isCheckSameColor == false)
                {
                    colorList[i].GetComponent<ColorScript>().isCheckSameColor = true;
                }
                else
                {
                    continue;
                }

                for (int j = 0; j < colorList.Count; j++)
                {
                    if (colorList[j].GetComponent<ColorScript>().isCheckSameColor == true)
                    {
                        spriteList.Add(colorList[j].gameObject);
                    }
                }
            }*/


        

           
            //SetSprite();
            //ColorScript.CS.isCheckSameColor = false;











            /*for (int i = 0; i < pointList.Count; i++)
            {
                Debug.Log("2");
                pointList[i].GetComponent<PointsScript>().isColorChange = true;

                for (int j = 0; j < pointList.Count; j++)
                {
                    if (pointList[j].GetComponent<PointsScript>().isColorChange == true)
                    {
                        if (spriteList.IndexOf(pointList[j].gameObject) < 0)
                        {
                            spriteList.Add(pointList[j].gameObject);
                            Debug.Log("1");
                        }
                    }
                }
                SetSprite();
                //spriteList.Clear();
                clearAll = true;
            }*/
        }
        
    }

    private void SetSprite()
    {
        if(spriteList.Count != 0)
        {
            if (spriteList.Count < 5)
            {
                if (spriteList[0].name == "Blue")
                {
                    for (int i = 0; i < spriteList.Count; i++)
                    {
                        spriteList[i].GetComponent<SpriteRenderer>().sprite = blue[0];                   
                    }
                }
                if (spriteList[0].name == "Green")
                {
                    for (int i = 0; i < spriteList.Count; i++)
                    {
                        spriteList[i].GetComponent<SpriteRenderer>().sprite = green[0];
                    }
                }
                if (spriteList[0].name == "Pink")
                {
                    for (int i = 0; i < spriteList.Count; i++)
                    {
                        spriteList[i].GetComponent<SpriteRenderer>().sprite = pink[0];
                    }
                }
                if (spriteList[0].name == "Red")
                {
                    for (int i = 0; i < spriteList.Count; i++)
                    {
                        spriteList[i].GetComponent<SpriteRenderer>().sprite = red[0];
                    }
                }
            }

            if (spriteList.Count > 4 && spriteList.Count < 8)
            {
                if (spriteList[0].name == "Blue")
                {
                    for (int i = 0; i < spriteList.Count; i++)
                    {
                        spriteList[i].GetComponent<SpriteRenderer>().sprite = blue[1];
                    }
                }
                if (spriteList[0].name == "Green")
                {
                    for (int i = 0; i < spriteList.Count; i++)
                    {
                        spriteList[i].GetComponent<SpriteRenderer>().sprite = green[1];
                 
                    }
                }
                if (spriteList[0].name == "Pink")
                {
                    for (int i = 0; i < spriteList.Count; i++)
                    {
                        spriteList[i].GetComponent<SpriteRenderer>().sprite = pink[1];
                    }
                }
                if (spriteList[0].name == "Red")
                {
                    for (int i = 0; i < spriteList.Count; i++)
                    {
                        spriteList[i].GetComponent<SpriteRenderer>().sprite = red[1];
                    }
                }
            }

            if (spriteList.Count > 7 && spriteList.Count < 10)
            {
                if (spriteList[0].name == "Blue")
                {
                    for (int i = 0; i < spriteList.Count; i++)
                    {
                        spriteList[i].GetComponent<SpriteRenderer>().sprite = blue[2];
                    }
                }
                if (spriteList[0].name == "Green")
                {
                    for (int i = 0; i < spriteList.Count; i++)
                    {
                        spriteList[i].GetComponent<SpriteRenderer>().sprite = green[2];
                    }
                }
                if (spriteList[0].name == "Pink")
                {
                    for (int i = 0; i < spriteList.Count; i++)
                    {
                        spriteList[i].GetComponent<SpriteRenderer>().sprite = pink[2];
                    }
                }
                if (spriteList[0].name == "Red")
                {
                    for (int i = 0; i < spriteList.Count; i++)
                    {
                        spriteList[i].GetComponent<SpriteRenderer>().sprite = red[2];
                    }
                }
            }

            if (spriteList.Count > 9)
            {
                if (spriteList[0].name == "Blue")
                {
                    for (int i = 0; i < spriteList.Count; i++)
                    {
                        spriteList[i].GetComponent<SpriteRenderer>().sprite = blue[3];
                        
                    }
                    
                }
                if (spriteList[0].name == "Green")
                {
                    for (int i = 0; i < spriteList.Count; i++)
                    {
                        spriteList[i].GetComponent<SpriteRenderer>().sprite = green[3];
                    }
                }
                if (spriteList[0].name == "Pink")
                {
                    for (int i = 0; i < spriteList.Count; i++)
                    {
                        spriteList[i].GetComponent<SpriteRenderer>().sprite = pink[3];
                    }
                }
                if (spriteList[0].name == "Red")
                {
                    for (int i = 0; i < spriteList.Count; i++)
                    {
                        spriteList[i].GetComponent<SpriteRenderer>().sprite = red[3];
                    }
                }
            }
        }
        
    }

    private IEnumerator SetSpriteTimer()
    {
        yield return new WaitForSeconds(0.05f);
        for (int i = 0; i < colorList.Count; i++)
        {
            if(colorList[i].GetComponent<ColorScript>().isCheckSameColor == true)
            {
                spriteList.Add(colorList[i]);
            }
        }
        if(controlNumber < colorList.Count)
        {
            colorList[controlNumber].GetComponent<ColorScript>().isCheckSameColor = false;
            SetSprite();

            spriteList.Clear();
            controlNumber++;

            isCountinue = true;
        }
        
        
        
    }
}
