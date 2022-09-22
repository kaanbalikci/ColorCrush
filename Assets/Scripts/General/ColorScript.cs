using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorScript : MonoBehaviour
{
    public static ColorScript CS;

    [HideInInspector] public SpriteRenderer SR;

    public bool isCount;
    public bool isCheckSameColor;
    public bool isRemove;
    public bool canCrush;

    public GameObject childCollider;
    public string thisColor;

    private void Awake()
    {
        CS = this;
        SR = GetComponent<SpriteRenderer>();
        thisColor = SR.sprite.name;
        this.gameObject.name = thisColor;
    }

    private void Update()
    {     
        if (SpriteManager.SM.spriteList.IndexOf(this.gameObject) < 0 && isCheckSameColor == true)
        {
            SpriteManager.SM.spriteList.Add(this.gameObject);
        }
        /*else if(isCheckSameColor == false)
        {
            SpriteManager.SM.spriteList.Remove(this.gameObject);
        }*/

        /*if (SpriteManager.SM.spriteList.Contains(this.gameObject))
        {
            isCheckSameColor = false;
        }*/

    }

    private void OnTriggerStay2D(Collider2D collision)
    {     
        if (collision.CompareTag("Colors"))
        {


           /* if(collision.name == this.name)
            {
                canCrush = true;
            }*/

            

            if (SpriteManager.SM.spriteList.Contains(this.gameObject))
            {
                if(collision.name == this.name && SpriteManager.SM.spriteList.IndexOf(collision.gameObject) < 0)
                {
                    SpriteManager.SM.spriteList.Add(collision.gameObject);
                }
            }

            if(isRemove == true)
            {
                if (collision.name == this.name)
                {
                    UIManager.UI.goodJobUI.SetActive(true);
                    UIManager.UI.goodJobTextUI.SetActive(true);
                    collision.GetComponent<ColorScript>().isRemove = true;
                    StartCoroutine(CloseThis());
                    //SpriteManager.SM.colorList.Remove(this.gameObject);
                    
                    //GameObject newObj = ObjectPool.OP.GetObject();


                    /*if (newObj != null)
                    {
                        newObj.SetActive(true);
                        newObj.transform.position = new Vector2(holdPos.x, holdPos.y + 5.4f);
                        
                    }*/
                    
                    
                    
                    
                    
                    //this.gameObject.SetActive(false);

                    //this.transform.position = new Vector2(transform.position.x, transform.position.y + 5.4f);
                    //this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    //this.gameObject.SetActive(true);
                    

                }

                     

            }
            
        }
    }

    private IEnumerator CloseThis()
    {
        yield return new WaitForSeconds(0.1f);
        this.gameObject.SetActive(false);
        
        
    }







}
