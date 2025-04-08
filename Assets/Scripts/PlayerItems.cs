using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [Header("Limit")]
    public const float WATER_LIMIT = 50;
    public const float CARROTS_LIMIT = 50;
    public const float WOOD_LIMIT = 5;

    [Header("Amount")]

    [SerializeField]
    private int totalWood;

    [SerializeField]
    private float currentWater;

    [SerializeField]
    private int carrots;

    public int TotalWood { get => totalWood; set => totalWood = value; }
    
    public float CurrentWater { get => currentWater; set => currentWater = value; }
    
    public int Carrots { get => carrots; set => carrots = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WaterLimit(float water)
    {
        if (currentWater < WATER_LIMIT)
        {
            currentWater += water;
        }
    }

}
