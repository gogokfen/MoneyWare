using UnityEngine;

public class Getaway : MonoBehaviour
{
    [SerializeField] Transform canvas;
    [SerializeField] Transform[] carSpawnPositions;
    [SerializeField] GameObject normalCarPrefab;
    [SerializeField] GameObject mafiaCar;
    [SerializeField] GameObject highway;
    [SerializeField] GameObject siren1;
    [SerializeField] GameObject siren2;
    [SerializeField] float carRespawnFrequency;
    private float highwayTimer;
    private float carSpawnTimer;
    private int laneState = 0;

    private Touch touch;
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    private bool touching = false;
    void Start()
    {
        highwayTimer = Time.time + 0.65f;
        carSpawnTimer = Time.time + 1; 
    }

    void Update()
    {
        if (Time.time>highwayTimer)
        {
            highwayTimer = Time.time + 0.65f;
            if (highway.activeSelf)
            {
                highway.SetActive(false);
                siren1.SetActive(false);
                siren2.SetActive(false);
            }
            else
            {
                highway.SetActive(true);
                siren1.SetActive(true);
                siren2.SetActive(true);
            }
        }


        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0); 

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                touching = true;
            }
            else if (touch.phase == TouchPhase.Ended && touching)
            {
                touchEndPos = touch.position;
                touching = false;
                if ( (touchEndPos.x > touchStartPos.x) && (touchEndPos.x - touchStartPos.x) > 300 && laneState!=1)
                {
                    mafiaCar.transform.position = new Vector3(mafiaCar.transform.position.x + Screen.width/3, mafiaCar.transform.position.y, mafiaCar.transform.position.z); //345
                    laneState++;
                }
                if ( (touchStartPos.x > touchEndPos.x) && (touchStartPos.x - touchEndPos.x) > 300 &&laneState !=-1)
                {
                    mafiaCar.transform.position = new Vector3(mafiaCar.transform.position.x - Screen.width/3, mafiaCar.transform.position.y, mafiaCar.transform.position.z); //345
                    laneState--;
                }
            }
        }

        if (Time.time>carSpawnTimer)
        {
            carSpawnTimer = Time.time + carRespawnFrequency;

            Instantiate(normalCarPrefab, carSpawnPositions[Random.Range(0,3)].position, normalCarPrefab.transform.rotation, canvas);
        }

    }
}

