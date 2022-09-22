using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorStateManager : MonoBehaviour
{
    public static ColorStateManager CSM;

    public bool switchIdle;
    public ColorBaseState currentState;
    public ColorIdleState idleState = new ColorIdleState();
    public ColorCrushState crushState = new ColorCrushState();
    public ColorFinishState finishState = new ColorFinishState();

    private void Awake()
    {
        CSM = this;
    }

    private void Start()
    {
        currentState = idleState;

        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.OnTriggerEnter2D(this, collision);
    }

    public void SwitchState(ColorBaseState state)
    {
        currentState = state;
        state.EnterState(this);
        StartCoroutine(currentState.StartState(this));
    }
}
