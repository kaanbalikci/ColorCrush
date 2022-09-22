using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsScript : MonoBehaviour
{
    public static PointsScript PS;

    public string thisColor;

    public bool isColorChange;

    public Sprite trueSprite = null;
    private Rigidbody2D rb;
    [SerializeField] private Sprite defColor;
    [SerializeField] private OrderScript Order;

    private void Awake()
    {
        PS = this;
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        
    }


    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag("Colors"))
        {
            thisColor = collision.GetComponent<ColorScript>().SR.sprite.name;
            //Debug.Log(this.name + thisColor);

        }

        /*if(isColorChange == true)
        {
            if (collision.gameObject.CompareTag("Child"))
            {
                collision.GetComponent<ChildColliderScript>().isCheckColor = true;
                Debug.Log("hello");
            }
        }
           
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Colors"))
        {
            if (SpriteManager.SM.colorList.IndexOf(collision.gameObject) < 0)
            {
                SpriteManager.SM.colorList.Add(collision.gameObject);           
            }
           
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Colors"))
        {

            //thisColor = collision.GetComponent<ColorScript>().SR.sprite.name;
            //Debug.Log(this.name + thisColor);

            string holdName = collision.GetComponent<ColorScript>().SR.sprite.name;
            if (holdName == "Blue" || holdName == "Blue_A" || holdName == "Blue_B" || holdName == "Blue_C")
            {
                thisColor = "Blue";
            }
            else if(holdName == "Green" || holdName == "Green_A" || holdName == "Green_B" || holdName == "Green_C")
            {
                thisColor = "Green";
            }
            else if (holdName == "Red" || holdName == "Red_A" || holdName == "Red_B" || holdName == "Red_C")
            {
                thisColor = "Red";
            }
            else if (holdName == "Pink" || holdName == "Pink_A" || holdName == "Pink_B" || holdName == "Pink_C")
            {
                thisColor = "Pink";
            }



            collision.GetComponent<SpriteRenderer>().sortingOrder = Order.sortingOrder;

            /*if (trueSprite != null)
            {
                collision.GetComponent<SpriteRenderer>().sprite = trueSprite;
                //trueSprite = null;
            }

            if (trueSprite != null)
            {
                collision.GetComponent<SpriteRenderer>().sprite = trueSprite;
                //SpriteManager.SM.spriteList.Clear();
                if (SpriteManager.SM.controlNumber > 81)
                {
                    SpriteManager.SM.controlNumber++;
                }
                
                trueSprite = null;
                isColorChange = false;
                
                Debug.Log("WOW");
                SpriteManager.SM.isCountinue = false;
            }*/
        }

        /*if (collision.CompareTag("Child"))
        {
            
            if(SpriteManager.SM.clearAll == false)
            {
                if (isColorChange == true)
                {
                    collision.GetComponent<ChildColliderScript>().isCheckColor = true;
                }
            }
            else if (SpriteManager.SM.clearAll == true)
            {
                collision.GetComponent<ChildColliderScript>().isCheckColor = false;
                isColorChange = false;
                SpriteManager.SM.clearAll = true;
            }
            

            //collision.GetComponent<ChildColliderScript>().thisColor2 = thisColor;



            /*if(collision.GetComponent<ChildColliderScript>().isCheckColor == true)
            {
                if (SpriteManager.SM.spriteList.IndexOf(this.gameObject) < 0)
                {
                    SpriteManager.SM.spriteList.Add(this.gameObject);
                }
                
            }
        }*/

       
    }

}
