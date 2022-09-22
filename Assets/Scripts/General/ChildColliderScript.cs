using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildColliderScript : MonoBehaviour
{
    public static ChildColliderScript CCS;

    public string thisColor2;
    public bool isCheckColor;

    private void Awake()
    {
        CCS = this;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            //thisColor2 = ;
            //Debug.Log(" 1 " + collision.GetComponent<PointsScript>().thisColor);
        }

        if (collision.gameObject.CompareTag("Child") && isCheckColor == false)
        {
            if(collision.GetComponent<ChildColliderScript>().thisColor2 == thisColor2 && collision.GetComponent<ChildColliderScript>().isCheckColor == true)
            {
                isCheckColor = true;
            }
        }
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            thisColor2 = collision.GetComponent<PointsScript>().thisColor;

            if (isCheckColor == true && collision.GetComponent<PointsScript>().isColorChange == false && SpriteManager.SM.clearAll == false)
            {
                collision.GetComponent<PointsScript>().isColorChange = true;
            }
        }


        /*if (collision.gameObject.CompareTag("Child") && isCheckColor == false)
        {
            if (collision.GetComponent<ChildColliderScript>().thisColor2 == thisColor2 && collision.GetComponent<ChildColliderScript>().isCheckColor == true)
            {

                isCheckColor = true;
               //Debug.Log(collision.GetComponent<ChildColliderScript>().thisColor2 + collision.GetComponent<ChildColliderScript>().isCheckColor);
            }
        }*/

        if(collision.gameObject.CompareTag("Child") && collision.GetComponent<ChildColliderScript>().isCheckColor == true && SpriteManager.SM.clearAll == false)
        {
            if(collision.GetComponent<ChildColliderScript>().thisColor2 == thisColor2)
            {
                isCheckColor = true;
                Debug.Log("GIRDI");
            }
        }
    }
}
