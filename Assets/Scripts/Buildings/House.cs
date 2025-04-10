using UnityEngine;

public class House : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer houseSprite;

    [SerializeField]
    private Color startColor;

    [SerializeField]
    private Color endColor;

    [SerializeField]
    private float timeAmount;

    [SerializeField]
    private Transform point;

    [SerializeField]
    private GameObject houseCollider;

    private bool detectingPlayer;

    private float timeCount;

    private bool isBeginning;

    private Player player;

    private PlayerAnimation playerAnimation;

    void Awake()
    {
        player = FindFirstObjectByType<Player>();
        playerAnimation = player.GetComponent<PlayerAnimation>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            isBeginning = true;
            playerAnimation.OnHammeringStarted();
            houseSprite.color = startColor;
            player.transform.position = point.position;
            player.isPaused = true;
        }

        if (isBeginning)
        {
            timeCount += Time.deltaTime;

            if (timeCount >= timeAmount)
            {
                playerAnimation.OnHammeringEnded();
                houseSprite.color = endColor;
                player.isPaused = false;
                houseCollider.SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }

}
