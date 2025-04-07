using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Player player;

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Moviment

    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling) {
                animator.SetTrigger("isRolling");
            }
            else
            {
                animator.SetInteger("transition", 1);
            }
        }
        else
        {
            animator.SetInteger("transition", 0);
        }

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (player.isCutting)
        {
            animator.SetInteger("transition", 3);
        }

        if (player.IsDigging)
        {
            animator.SetInteger("transition", 4);
        }

        if (player.IsWatering)
        {
            animator.SetInteger("transition", 5);
        }
    }

    void OnRun()
    {
        if (player.isRunning)
        {
            animator.SetInteger("transition", 2);
        }
    }

    #endregion
}
