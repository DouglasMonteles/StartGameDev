using UnityEngine;

public class Tree : MonoBehaviour
{

    [SerializeField]
    private float treeHealth;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject woodPrefab;

    [SerializeField]
    private int totalWood;

    [SerializeField]
    private ParticleSystem leafs;

    private bool isCut;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnHit()
    {
        treeHealth--;

        animator.SetTrigger("isHit");

        leafs.Play();

        Debug.Log("on hit");

        if (treeHealth <= 0)
        {
            for (int i = 0; i < totalWood; i++)
            {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-1f, 0.5f), Random.Range(-1f, 0.5f), 0f), transform.rotation);
            }
            animator.SetTrigger("cut");

            isCut = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe") && !isCut)
        {
            OnHit();
        }
    }

}
