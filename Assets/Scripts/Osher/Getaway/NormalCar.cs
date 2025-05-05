using UnityEngine;

public class NormalCar : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1500;
    void Start()
    {
        Destroy(gameObject, 3.25f - (moveSpeed/1000));
    }

    void Update()
    {
        transform.Translate(-Vector2.up * moveSpeed * Time.deltaTime);

        if (Physics2D.OverlapBox(transform.position,new Vector2(256,512),0))
        {
            GameManager.instance.LoseMG();
        }
    }
}
