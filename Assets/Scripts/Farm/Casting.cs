using UnityEngine;

public class Casting : MonoBehaviour
{

    [SerializeField]
    private int percentage;

    [SerializeField]
    private GameObject fishPrefab;

    private bool detectingPlayer;

    private PlayerAnimation playerAnimation;

    private PlayerItems playerItems;

    void Awake()
    {
        playerItems = FindFirstObjectByType<PlayerItems>();
        playerAnimation = playerItems.GetComponent<PlayerAnimation>();
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
            playerAnimation.OnCastingStarted();
        }
    }

    public void OnCasting()
    {
        int randomValue = Random.Range(1, 100);

        if (randomValue < percentage)
        {
            Debug.Log("Pescou!");
            Instantiate(fishPrefab, playerItems.transform.position + new Vector3(Random.Range(-3f, -1f), 0f, 0f), Quaternion.identity);
        }
        else
        {
            Debug.Log("Não pescou");
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
