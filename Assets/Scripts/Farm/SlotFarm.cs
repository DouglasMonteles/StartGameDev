using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Components")]

    [SerializeField]
    private SpriteRenderer spriteRender;

    [SerializeField]
    private Sprite hole;

    [SerializeField]
    private Sprite carrot;

    [Header("Settings")]

    [SerializeField]
    private int digAmount;

    [SerializeField]
    private bool waterDetecting;

    [SerializeField]
    private float waterAmount;

    private float currentWater;

    private int initialDigAmount;

    private bool dugHole;

    private PlayerItems playerItems;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerItems = FindFirstObjectByType<PlayerItems>();
        initialDigAmount = digAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (dugHole)
        {
            if (waterDetecting)
            {
                currentWater += 0.01f;
            }

            if (currentWater >= waterAmount)
            {
                spriteRender.sprite = carrot;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    spriteRender.sprite = hole;
                    playerItems.Carrots++;
                    currentWater = 0;
                }
            }
        }
    }

    public void OnHit()
    {
        digAmount--;

        if (digAmount <= initialDigAmount / 2)
        {
            spriteRender.sprite = hole;
            dugHole = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dig"))
        {
            OnHit();
        }

        if (collision.CompareTag("Water"))
        {
            waterDetecting = true;
        }   
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            waterDetecting = false;
        }
    }

}
