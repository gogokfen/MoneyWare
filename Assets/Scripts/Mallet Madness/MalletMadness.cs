using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System.Collections;
using UnityEngine.EventSystems;
public class MalletMadness : MonoBehaviour
{
    [Header("UI Elements")]
    public Button malletButton;
    public Button whistleButton;
    public Image guard;
    public Sprite[] guardStand;
    public Image exclamation;
    public TextMeshProUGUI helpText;
    [Header("Game Settings")]
    public int smashesNeeded;
    public float guardCheckIntervalMin;
    public float guardCheckIntervalMax;
    public float guardWarningDuration; //Reaction window
    public float guardLookDuration;  //DANGER ZONE

    private int currentSmashes;
    private bool guardLooking = false;
    private bool isGameActive = false;
    private bool weSmashingNow;
    private Coroutine guardRoutine;
    void Start()
    {
        malletButton.onClick.AddListener(MalletButton);
        currentSmashes = 0;
        isGameActive = true;
        guardRoutine = StartCoroutine(GuardWatchRoutine());
    }
    private void MalletButton()
    {
        currentSmashes++;
        weSmashingNow = true;
        if (currentSmashes >= smashesNeeded)
        {
            GameOver();
            GameManager.instance.WinMG();
            //}
        }
    }
    public void Whistling(bool state)
    {
        weSmashingNow = !state;
    }

    void Update()
    {
        if (weSmashingNow && guardLooking)
        {
            GameOver();
            guard.sprite = guardStand[2];
            GameManager.instance.LoseMG();
        }
    }

    private IEnumerator GuardWatchRoutine()
    {
        while (isGameActive)
        {
            guard.sprite = guardStand[0];
            helpText.text = "Guard is not looking";
            yield return new WaitForSeconds(Random.Range(guardCheckIntervalMin, guardCheckIntervalMax)); //between a random range, the guard will look at player
            helpText.text = "Guard is about to look";
            exclamation.gameObject.SetActive(true);
            yield return new WaitForSeconds(guardWarningDuration); //quick warning before the guard actually looks, so it wont be instantaneous
            exclamation.gameObject.SetActive(false);
            guardLooking = true;
            guard.sprite = guardStand[1];
            helpText.text = "Guard is looking!";
            yield return new WaitForSeconds(guardLookDuration); //duration that the guard is actually looking
            guardLooking = false;
        }
    }

    private void GameOver()
    {
        malletButton.interactable = false;
        whistleButton.interactable = false;
        if (guardRoutine != null) StopCoroutine(guardRoutine);
    }
}

