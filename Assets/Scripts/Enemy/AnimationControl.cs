using Unity.VisualScripting;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{

    [SerializeField]
    private Transform attackPoint;

    [SerializeField]
    private float radius;

    [SerializeField]
    private LayerMask playerLayer;

    private Animator animator;

    private PlayerAnimation playerAnimation;

    private Skeleton skeleton;

    void Awake()
    {
        animator = GetComponent<Animator>();
        playerAnimation = FindFirstObjectByType<PlayerAnimation>();
        skeleton = GetComponentInParent<Skeleton>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnimation(int value)
    {
        animator.SetInteger("transition", value);
    }

    public void Attack()
    {
        if (skeleton.isDead) return;

        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);

        if (hit != null)
        {
            playerAnimation.OnHurt();
        }
    }

    public void OnHit()
    {
        if (skeleton.currentHealth <= 0)
        {
            skeleton.isDead = true;
            animator.SetTrigger("dead");

            Destroy(skeleton.gameObject, 1f);
        }
        else
        {
            animator.SetTrigger("hit");
            skeleton.currentHealth--;

            skeleton.healthBar.fillAmount = skeleton.currentHealth / skeleton.totalHealth;
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);   
    }

}
