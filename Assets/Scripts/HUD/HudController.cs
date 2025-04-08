using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{

    [Header("Items")]

    [SerializeField]
    private Image waterBarUI;

    [SerializeField]
    private Image carrotBarUI;

    [SerializeField]
    private Image woodBarUI;

    [Header("Tools")]

    // [SerializeField]
    // private Image axeUI;

    // [SerializeField]
    // private Image shovelUI;

    // [SerializeField]
    // private Image bucketUI;

    public List<Image> toolsUI = new List<Image>();

    [SerializeField]
    private Color selectColor;

    [SerializeField]
    private Color alphaColor;

    private Player player;

    private PlayerItems playerItems;

    void Awake()
    {
        playerItems = FindFirstObjectByType<PlayerItems>();
        player = playerItems.GetComponent<Player>();
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

        // toolsUI[player.HandleObj - 1].color = selectColor;

        for (int i = 0; i < toolsUI.Count; i++) 
        {
            if (i == (player.HandleObj - 1)) 
            {
                toolsUI[i].color = selectColor;
            } 
            else
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
