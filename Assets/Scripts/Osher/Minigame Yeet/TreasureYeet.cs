using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class TreasureYeet : MonoBehaviour
{
    [SerializeField] GameObject treasurePrefab;
    [SerializeField] Transform yeetTransform;
    [SerializeField] Transform canvas;
    [SerializeField] GraphicRaycaster GR;
    [SerializeField] EventSystem ES;

    private PointerEventData raycastData;


    Vector3 touchStartPos;
    Vector3 touchEndPos;
    bool touching = false;

    Touch touch;

    private int treasureCount;
    void Start()
    {
        raycastData = new PointerEventData(ES);
    }

    void Update()
    {
        if (Input.touchCount>0)
        {
            touch = Input.GetTouch(0); //what if there is more than one touch? maybe it's not the first that should count

            List<RaycastResult> raycastResults = new List<RaycastResult>(); //only works with lists?

            raycastData.position = touch.position;

            GR.Raycast(raycastData, raycastResults);

            if (touch.phase == TouchPhase.Began && raycastResults.Count>0) //the only raycast target is the treasure chest
            {
                touchStartPos = touch.position;
                touching = true;
            }
            else if (touch.phase == TouchPhase.Ended && touching)
            {
                touchEndPos = touch.position;
                touching = false;
                if ((touchEndPos.y > touchStartPos.y) && (touchEndPos.y - touchStartPos.y) > 550)
                {
                    GameObject tempTreasure = Instantiate(treasurePrefab, yeetTransform.position, yeetTransform.rotation, canvas);
                    Destroy(tempTreasure, 2);
                    treasureCount++;
                    if (treasureCount >= 4)
                    {
                        GameManager gameManager = FindAnyObjectByType<GameManager>(); //change later
                        gameManager.WinMG();
                    }
                }
            }
        }
    }
}
