using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    private const float WATER_LIMIT = 50;

    [SerializeField]
    private int totalWood;

    [SerializeField]
    private float currentWater;

    public int TotalWood { get => totalWood; set => totalWood = value; }
    
    public float CurrentWater { get => currentWater; set => currentWater = value; }

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
