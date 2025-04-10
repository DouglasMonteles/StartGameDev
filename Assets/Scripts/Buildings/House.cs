using UnityEngine;

public class House : MonoBehaviour
{

    [Header("Amounts")]

    [SerializeField]
    private int woodAmount;

    [SerializeField]
    private Color startColor;

    [SerializeField]
    private Color endColor;

    [SerializeField]
    private float timeAmount;

    [Header("Components")]

    [SerializeField]
    private SpriteRenderer houseSprite;

    [SerializeField]
    private Transform point;

    [SerializeField]
    private GameObject houseCollider;

    private bool detectingPlayer;

    private float timeCount;

    private bool isBeginning;

    private Player player;

    private PlayerAnimation playerAnimation;

    private PlayerItems playerItems;

    void Awake()
    {
        player = FindFirstObjectByType<Player>();
        playerAnimation = player.GetComponent<PlayerAnimation>();
        playerItems = player.GetComponent<PlayerItems>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E) && playerItems.TotalWood >= woodAmount)
        {
            isBeginning = true;
            playerAnimation.OnHammeringStarted();
            houseSprite.color = startColor;
            player.transform.position = point.position;
            player.isPaused = true;

            playerItems.TotalWood -= woodAmount;
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
