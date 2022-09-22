using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFinishState : ColorBaseState
{
    public override void EnterState(ColorStateManager color)
    {
        UIManager.UI.GameOverPanel.SetActive(true);
    }


    public override void UpdateState(ColorStateManager color)
    {

    }

    public override void OnTriggerEnter2D(ColorStateManager color, Collider2D collision)
    {
        
    }
}
