using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Player player;

    private Animator animator;

    private Casting casting;

    private bool isHurt;

    private float countDown;
    private float recoveryTime = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
        casting = FindFirstObjectByType<Casting>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();

        if (isHurt)
        {
            countDown += Time.deltaTime;

            if (countDown >= recoveryTime)
            {
                isHurt = false;
                countDown = 0;
            }
        }
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

    public void OnCastingStarted()
    {
        animator.SetTrigger("isCasting");
        player.isPaused = true;
    }

    public void OnCastingEnded()
    {
        casting.OnCasting();
        player.isPaused = false;
    }

    public void OnHammeringStarted()
    {
        animator.SetBool("hammering", true);
    }

    public void OnHammeringEnded()
    {
        animator.SetBool("hammering", false);
    }

    public void OnHurt()
    {
        if (!isHurt)
        {
            animator.SetTrigger("hurt");
            isHurt = true;
        }
    }

    #endregion
}
