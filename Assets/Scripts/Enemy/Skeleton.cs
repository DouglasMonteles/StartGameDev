using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private AnimationControl animationControl;

    private Player player;

    void Awake()
    {
        player = FindFirstObjectByType<Player>();
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
}
