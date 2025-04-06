using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float diffModifier = 1; // needs to be a global modifier
    private float moveSpeed;
    private RectTransform recTransform;
    void Start()
    {
        moveSpeed = Random.Range(100, 200);
        if (Random.Range(0, 2) == 1)
            moveSpeed *= -1;

        moveSpeed *= diffModifier;

        recTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed *Time.deltaTime);
        if (transform.position.x - recTransform.rect.width / 2 < 0 || transform.position.x + recTransform.rect.width / 2 > Screen.width)
            moveSpeed *= -1;
    }
}
