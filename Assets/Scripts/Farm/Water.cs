using UnityEngine;

public class Water : MonoBehaviour
{

    [SerializeField]
    private bool detectingPlayer;

    [SerializeField]
    private int waterValue;

    private PlayerItems playerItems;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerItems = FindFirstObjectByType<PlayerItems>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            playerItems.WaterLimit(waterValue);
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
