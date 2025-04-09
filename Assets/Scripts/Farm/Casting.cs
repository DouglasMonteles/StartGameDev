using UnityEngine;

public class Casting : MonoBehaviour
{

    [SerializeField]
    private int percentage;

    private bool detectingPlayer;

    private PlayerItems playerItems;

    void Awake()
    {
        playerItems = FindFirstObjectByType<PlayerItems>();
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
            OnCasting();
        }
    }

    void OnCasting()
    {
        int randomValue = Random.Range(1, 100);

        if (randomValue < percentage)
        {
            Debug.Log("Pescou!");
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
