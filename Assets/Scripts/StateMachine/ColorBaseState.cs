using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColorBaseState
{
    public abstract void EnterState(ColorStateManager color);

    public abstract void UpdateState(ColorStateManager color);

    public abstract void OnTriggerEnter2D(ColorStateManager color, Collider2D collision);

    public virtual IEnumerator StartState(ColorStateManager color)
    {
        yield return null;
    }

}
