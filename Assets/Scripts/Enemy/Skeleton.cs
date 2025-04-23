using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{

    [Header("Stats")]
    public float currentHealth;

    public Image healthBar;

    public float totalHealth;

    public bool isDead;

    public float radius;

    public LayerMask playerLayer;
    
    [Header("Components")]
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private AnimationControl animationControl;

    private Player player;
    private bool detectingPlayer;


    void Awake()
    {
        player = FindFirstObjectByType<Player>();
        currentHealth = totalHealth;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead || !detectingPlayer)
        {
            return;
        }
        
        agent.isStopped = false;
        agent.SetDestination(player.transform.position);

        if (Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
        {
            animationControl.PlayAnimation(2); // attack player
        }
        else
        {
            animationControl.PlayAnimation(1); // walking
        }

        float posX = player.transform.position.x - transform.position.x;

        if (posX > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void FixedUpdate()
    {
        DetectPlayer();
    }

    public void DetectPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);

        if (hit != null)
        {
            detectingPlayer = true;
        }
        else
        {
            detectingPlayer = false;
            animationControl.PlayAnimation(0);
            agent.isStopped = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
