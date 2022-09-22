using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorIdleState : ColorBaseState
{
   

    public override void EnterState(ColorStateManager color)
    {
        Debug.Log("Idle");
    }

    public override void UpdateState(ColorStateManager color)
    {
        /*if(color.switchIdle == true)
        {
            color.SwitchState(color.crushState);
        }*/

        if(SpriteManager.SM.moveCount == 11)
        {
            color.SwitchState(color.crushState);
        }

        if (Input.GetMouseButtonDown(0))
        {
            
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Colors")/* && hit.collider.GetComponent<ColorScript>().canCrush == true*/)
                {
                    SpriteManager.SM.moveCount--;
                    hit.collider.GetComponent<ColorScript>().isRemove = true;
                    //hit.collider.gameObject.SetActive(false);
                    
                    color.SwitchState(color.crushState);
                }
            }
            
        }
    }

    public override void OnTriggerEnter2D(ColorStateManager color, Collider2D collision)
    {

    }

}
