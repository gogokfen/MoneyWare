using UnityEngine;


public class TargetAim : MonoBehaviour
{
    [SerializeField] Transform enemiesContainer;
    [SerializeField] int ammo;
    bool won = false;

    private Collider2D[] hits;
    private LayerMask LM = 64; //interactable layer

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo>0 && !won)
        {
            transform.position = Input.mousePosition;
            ammo--;

            hits = Physics2D.OverlapBoxAll(transform.position, new Vector2(128, 128), 0, LM);
            
            if (hits.Length>0)
                for (int i = 0; i < hits.Length; i++)
                {
                    hits[i].transform.SetParent(null);
                    Destroy(hits[i].gameObject);
                }

            if (enemiesContainer.childCount == 0)
            {
                won = true;
                GameManager gameManager = FindAnyObjectByType<GameManager>(); //change later
                gameManager.WinMG();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(256, 256, 0));
    }

}
