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

    void Awake()
    {
        animator = GetComponent<Animator>();
        playerAnimation = FindFirstObjectByType<PlayerAnimation>();
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
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);

        if (hit != null)
        {
            playerAnimation.OnHurt();
        }
        else
        {

        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);   
    }

}
