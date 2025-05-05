using UnityEngine;

public class FloatingWord : MonoBehaviour
{
    [SerializeField] Transform GFX;

    private float jiggleAmount;
    private float jiggleSpeed;
    private bool changeDirection;

    private float floatSpeed = 150;
    private Vector2 moveDirection;

    private LayerMask wallMask;
    private RaycastHit2D wallHit;

    private RectTransform recTransform;

    void Start()
    {
        jiggleAmount = Random.Range(10, 45);
        jiggleSpeed = Random.Range(0.5f, 2f);

        recTransform = GetComponent<RectTransform>();

        wallMask.value = 64; //interactable layer
        moveDirection = new Vector2(Random.Range (-1f,1f), Random.Range(-1f,1f));
        moveDirection.Normalize();
        //moveDirection = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));

    }

    void Update()
    {
        if (changeDirection)
        {
            GFX.Rotate(0, 0, -50 * jiggleSpeed * Time.deltaTime);
        }
        else
        {
            GFX.Rotate(0, 0, 50 * jiggleSpeed * Time.deltaTime);
        }
        if (GFX.eulerAngles.z > jiggleAmount || GFX.eulerAngles.z < -jiggleAmount)
            changeDirection = !changeDirection;



        transform.Translate(moveDirection * floatSpeed * Time.deltaTime);

        if (Physics2D.Raycast(transform.position, transform.up, recTransform.rect.height / 2, wallMask)) //equals true, meaning hit
        {
            wallHit = Physics2D.Raycast(transform.position, transform.up, recTransform.rect.height / 2, wallMask);
        }
        else if (Physics2D.Raycast(transform.position, -transform.up, recTransform.rect.height / 2, wallMask))
        {
            wallHit = Physics2D.Raycast(transform.position, -transform.up, recTransform.rect.height / 2, wallMask);
        }
        else if (Physics2D.Raycast(transform.position, transform.right, recTransform.rect.width / 2, wallMask))
        {
            wallHit = Physics2D.Raycast(transform.position, transform.right, recTransform.rect.width / 2, wallMask);
        }
        else if (Physics2D.Raycast(transform.position, -transform.right, recTransform.rect.width / 2, wallMask))
        {
            wallHit = Physics2D.Raycast(transform.position, -transform.right, recTransform.rect.width / 2, wallMask);
        }
        moveDirection = Vector2.Reflect(moveDirection, wallHit.normal);
        wallHit.normal = Vector2.zero; //making sure not using outdated raycast hit
    }
}
