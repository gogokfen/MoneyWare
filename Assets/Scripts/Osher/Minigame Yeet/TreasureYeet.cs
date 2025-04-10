using UnityEngine;

public class TreasureYeet : MonoBehaviour
{
    [SerializeField] GameObject treasurePrefab;
    [SerializeField] Transform yeetTransform;
    [SerializeField] Transform canvas;

    Vector3 touchStartPos;
    Vector3 touchEndPos;
    bool touching = false;

    Touch touch;

    private int treasureCount;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && (touch.position.x>=500 && touch.position.x <=1000 && touch.position.y>=400 && touch.position.y<=800))
            {
                touchStartPos = touch.position;
                touching = true;
            }
            else if (touch.phase == TouchPhase.Ended && touching)
            {
                touchEndPos = touch.position;
                touching = false;
                if ((touchEndPos.y > touchStartPos.y) && (touchEndPos.y - touchStartPos.y) > 800)
                {
                    Instantiate(treasurePrefab, yeetTransform.position, yeetTransform.rotation,canvas);
                    treasureCount++;
                    if (treasureCount>=4)
                    {
                        GameManager gameManager = FindAnyObjectByType<GameManager>(); //change later
                        gameManager.WinMG();
                    }
                }
            }
        }
    }
}
