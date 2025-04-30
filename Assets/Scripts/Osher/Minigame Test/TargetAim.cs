using UnityEngine;


public class TargetAim : MonoBehaviour
{
    [SerializeField] Transform enemiesContainer;
    [SerializeField] int ammo;
    private int ammoIndex;
    private bool won = false;

    private Collider2D[] hits;
    private LayerMask LM = 64; //interactable layer

    [SerializeField] GameObject[] bullets;

    private void Start()
    {
        ammoIndex = ammo;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo>0 && !won)
        {
            transform.position = Input.mousePosition;
            ammo--;
            ammoIndex--;
            bullets[ammoIndex].SetActive(false);

            hits = Physics2D.OverlapBoxAll(transform.position, new Vector2(32, 32), 0, LM);
            
            if (hits.Length>0)
                for (int i = 0; i < hits.Length; i++)
                {
                    for (int j=0;j<hits.Length;j++)
                    {
                        if (hits[j].name == "Blockade")
                        {
                            return;
                        }
                    }

                    hits[i].transform.SetParent(null);
                    Destroy(hits[i].gameObject);
                }

            if (enemiesContainer.childCount == 0)
            {
                won = true;
                GameManager.instance.WinMG();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(256, 256, 0));
    }

}
