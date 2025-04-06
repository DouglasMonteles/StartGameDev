using UnityEngine;

public class SlotFarm : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer spriteRender;

    [SerializeField]
    private Sprite hole;

    [SerializeField]
    private Sprite carrot;

    [SerializeField]
    private int digAmount;

    private int initialDigAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialDigAmount = digAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit()
    {
        digAmount--;

        if (digAmount <= initialDigAmount / 2)
        {
            spriteRender.sprite = hole;
        }

        if (digAmount <= 0)
        {
            spriteRender.sprite = carrot;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dig"))
        {
            OnHit();
        }   
    }

}
