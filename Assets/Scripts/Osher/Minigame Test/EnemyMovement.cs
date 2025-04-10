using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float diffModifier = 1; // needs to be a global modifier
    private float moveSpeed;
    private RectTransform recTransform;
    void Start()
    {
        moveSpeed = Random.Range(200, 400);
        if (Random.Range(0, 2) == 1)
            moveSpeed *= -1;

        moveSpeed *= diffModifier;

        recTransform = GetComponent<RectTransform>();

        recTransform.anchoredPosition  = new Vector3(0+Random.Range(-Screen.width/2 + recTransform.rect.width/2, Screen.width/2 - recTransform.rect.width/2 ),Random.Range(750,850), 0);
    }

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed *Time.deltaTime);
        if (transform.position.x - recTransform.rect.width / 2 < 0 || transform.position.x + recTransform.rect.width / 2 > Screen.width)
            moveSpeed *= -1;

        transform.Translate(Vector2.up * moveSpeed/4 * Mathf.Sin(Time.time*6) * Time.deltaTime);
    }

}
