using UnityEngine;
using System;
public class ShakeMinigame : MonoBehaviour
{
    [Header("Shake Settings")]
    public float shakeStrengthThreshold = 2.0f;
    public int shakesNeeded;
    public float shakeTimeout = 1.0f;
    private int currentShakeCount = 0;
    private float timeSinceLastShake = 0f;
    bool isShakeDetected = false;
    bool minigameEnded;
    [SerializeField] GameObject coinPile;
    [SerializeField] AudioSource AS;
    [SerializeField] AudioClip shakedownClip;
    [SerializeField] AudioClip alrightClip;
    [SerializeField] Animator animator;

    void Start()
    {
        AS.PlayOneShot(shakedownClip);
    }

    void Update()
    {
        {
            Vector3 acceleration = Input.acceleration;
            float accelerationMagnitude = acceleration.magnitude;
            if ((accelerationMagnitude >= shakeStrengthThreshold || Input.GetKey(KeyCode.Space)) && !minigameEnded)
            {
                isShakeDetected = true;
                animator.Play("RichGuyShake");
            }
            else isShakeDetected = false;
        }
        if (isShakeDetected)
        {
            currentShakeCount++;
            timeSinceLastShake = 0f;
            animator.speed = 1;
            //Debug.Log($"Shake detected! Count: {currentShakeCount}");
            if (currentShakeCount >= shakesNeeded && !minigameEnded)
            {
                //Debug.Log("Shake threshold reached!");
                currentShakeCount = 0;
                coinPile.SetActive(true);
                AS.PlayOneShot(alrightClip);
                minigameEnded = true;
                GameManager.instance.WinMG();
            }
        }
        else
        {
            timeSinceLastShake += Time.deltaTime;
            animator.speed = 0;
            if (timeSinceLastShake >= shakeTimeout)
            {
                if (currentShakeCount > 0)
                    //Debug.Log("Shake timeout, resetting counter.");
                currentShakeCount = 0;
                timeSinceLastShake = 0f;
            }
        }
    }
}
