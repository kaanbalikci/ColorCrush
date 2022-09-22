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
        //if check same color is true, add this object to spritelist for control how many color in a group
        if (SpriteManager.SM.spriteList.IndexOf(this.gameObject) < 0 && isCheckSameColor == true)
        {
            SpriteManager.SM.spriteList.Add(this.gameObject);
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {     
        if (collision.CompareTag("Colors"))
        {


            
            //add this object colorlist we control this game with colorlist
            if (SpriteManager.SM.spriteList.Contains(this.gameObject))
            {
                if(collision.name == this.name && SpriteManager.SM.spriteList.IndexOf(collision.gameObject) < 0)
                {
                    SpriteManager.SM.spriteList.Add(collision.gameObject);
                }
            }

            //if touch this object start this 
            if(isRemove == true)
            {
                //if this obj touch same color, all same color setactive false
                if (collision.name == this.name)
                {
                    UIManager.UI.goodJobUI.SetActive(true);
                    UIManager.UI.goodJobTextUI.SetActive(true);
                    collision.GetComponent<ColorScript>().isRemove = true;
                    StartCoroutine(CloseThis());
                    

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
