using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField]
    private Image waterBarUI;

    [SerializeField]
    private Image carrotBarUI;

    [SerializeField]
    private Image woodBarUI;

    private PlayerItems playerItems;

    void Awake()
    {
        playerItems = FindFirstObjectByType<PlayerItems>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waterBarUI.fillAmount = 0f;
        carrotBarUI.fillAmount = 0f;
        woodBarUI.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        waterBarUI.fillAmount = playerItems.CurrentWater / PlayerItems.WATER_LIMIT;
        carrotBarUI.fillAmount = playerItems.Carrots / PlayerItems.CARROTS_LIMIT;
        woodBarUI.fillAmount = playerItems.TotalWood / PlayerItems.WOOD_LIMIT;
    }
}
