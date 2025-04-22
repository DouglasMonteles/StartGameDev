using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip holeSFX;

    [SerializeField]
    private AudioClip carrotSFX;

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

    private bool plantedCarrot;

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

            if (currentWater >= waterAmount && !plantedCarrot)
            {
                audioSource.PlayOneShot(holeSFX);
                spriteRender.sprite = carrot;

                plantedCarrot = true;
            }

            if (Input.GetKeyDown(KeyCode.E) && plantedCarrot)
            {
                audioSource.PlayOneShot(carrotSFX);
                spriteRender.sprite = hole;
                playerItems.Carrots++;
                currentWater = 0;
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
