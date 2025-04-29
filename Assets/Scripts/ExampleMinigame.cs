using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleMinigame : MonoBehaviour
{
    [SerializeField] Button winButton;
    [SerializeField] Button loseButton;
    void Start()
    {
        winButton.onClick.AddListener(OnWinButtonClicked);
        loseButton.onClick.AddListener(OnLoseButtonClicked);
    }
    void Update()
    {

    }
    void OnWinButtonClicked()
    {
        GameManager.instance.WinMG();
    }

    void OnLoseButtonClicked()
    {
        GameManager.instance.LoseMG();   
    }
}
