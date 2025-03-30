using UnityEngine;

public class Tree : MonoBehaviour
{

    [SerializeField]
    private float treeHealth;

    [SerializeField]
    private Animator animator;

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

        Debug.Log("on hit");

        if (treeHealth <= 0)
        {
            animator.SetTrigger("cut");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe"))
        {
            OnHit();
        }
    }

}
