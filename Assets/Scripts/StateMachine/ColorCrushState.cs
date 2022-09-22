using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCrushState : ColorBaseState
{
    public override void EnterState(ColorStateManager color)
    {
        Debug.Log("Crush");

        
    }


    public override void UpdateState(ColorStateManager color)
    {
        
    }

    public override void OnTriggerEnter2D(ColorStateManager color, Collider2D collision)
    {

    }

    public override IEnumerator StartState(ColorStateManager color)
    {
        // if start game wait control number 
        if(SpriteManager.SM.moveCount == 0)
        {
            yield return new WaitForSeconds(1.4f);
            SpriteManager.SM.controlNumber = 0;
            yield return new WaitForSeconds(2.6f);
            color.SwitchState(color.finishState);
        }

        //these are starting control
        if(SpriteManager.SM.moveCount != 0)
        {
            if (SpriteManager.SM.moveCount == 11)
            {
                SpriteManager.SM.moveCount--;
                yield return new WaitForSeconds(2.3f);
                UIManager.UI.startScreen.SetActive(false);
                color.SwitchState(color.idleState);
               
            }
            else if (SpriteManager.SM.moveCount < 11)
            {
                yield return new WaitForSeconds(1.4f);
                SpriteManager.SM.controlNumber = 0;
                
                yield return new WaitForSeconds(2.6f);
                color.SwitchState(color.idleState);
                UIManager.UI.goodJobUI.SetActive(false);
                UIManager.UI.goodJobTextUI.SetActive(false);
            }
        }
        
       
    }
}
