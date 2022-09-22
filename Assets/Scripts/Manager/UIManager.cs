using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager UI;

    public Text moveText;
    public GameObject GameOverPanel;
    public GameObject goodJobUI;
    public GameObject goodJobTextUI;
    public GameObject startScreen;

    private void Awake()
    {
        UI = this;
    }
    private void OnEnable()
    {
        SpriteManager.UpdateMove += MoveManager;
      
    }
    private void OnDisable()
    {
        SpriteManager.UpdateMove -= MoveManager;
      
    }

    public void MoveManager(int Score)
    {
        moveText.text = "MOVE : " + Score.ToString();
    }

}
