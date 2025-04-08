using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    [SerializeField]
    private float runSpeed;

    [SerializeField]
    private float rollingSpeed;

    private float initialSpeed;

    private Rigidbody2D rig;

    private bool _isRolling;

    public bool isRolling {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    private Vector2 _direction;

    public Vector2 direction
    {
        get { return _direction; }
        set { direction = value; }
    }

    private bool _isRunning;

    public bool isRunning {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    private bool _isCutting;

    public bool isCutting { get => _isCutting; set => _isCutting = value; }

    [HideInInspector]
    private int handleObj;

    private bool _isDigging;

    public bool IsDigging { get => _isDigging; set => _isDigging = value; }

    private bool _isWatering;

    public bool IsWatering { get => _isWatering; set => _isWatering = value; }
    
    public int HandleObj { get => handleObj; set => handleObj = value; }

    private PlayerItems playerItems;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerItems = GetComponent<PlayerItems>();  
        initialSpeed = speed; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            HandleObj = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HandleObj = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            HandleObj = 3;
        }

        OnInput();
        OnRun();
        OnRolling();
        OnCutting();
        OnDig();
        OnWatering();
    }

    void FixedUpdate()
    {
        OnMove();
    }

    #region Moviment

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRolling()
    {
        const int MOUSE_RIGHT_BUTTON = 1;
        
        if (Input.GetMouseButtonDown(MOUSE_RIGHT_BUTTON))
        {
            speed = rollingSpeed;
            _isRolling = true;
        }

        if (Input.GetMouseButtonUp(MOUSE_RIGHT_BUTTON))
        {
            speed = initialSpeed;
            _isRolling = false;
        }
    }

    void OnCutting()
    {
        if (HandleObj == 1)
        {
            const int MOUSE_LEFT_BUTTON = 0;

            if (Input.GetMouseButtonDown(MOUSE_LEFT_BUTTON))
            {
                _isCutting = true;
                speed = 0;
            }

            if (Input.GetMouseButtonUp(MOUSE_LEFT_BUTTON))
            {
                _isCutting = false;
                speed = initialSpeed;
            }
        }
    }

    void OnDig()
    {
        if (HandleObj == 2)
        {
            const int MOUSE_LEFT_BUTTON = 0;

            if (Input.GetMouseButtonDown(MOUSE_LEFT_BUTTON))
            {
                _isDigging = true;
                speed = 0;
            }

            if (Input.GetMouseButtonUp(MOUSE_LEFT_BUTTON))
            {
                _isDigging = false;
                speed = initialSpeed;
            }
        }
    }

    void OnWatering()
    {
        if (HandleObj == 3)
        {
            const int MOUSE_LEFT_BUTTON = 0;

            if (Input.GetMouseButtonDown(MOUSE_LEFT_BUTTON) && playerItems.CurrentWater > 0)
            {
                _isWatering = true;
                speed = 0;
            }

            if (Input.GetMouseButtonUp(MOUSE_LEFT_BUTTON) || playerItems.CurrentWater < 0)
            {
                _isWatering = false;
                speed = initialSpeed;
            }

            if (IsWatering)
            {
                playerItems.CurrentWater -= 0.01f;
            }
        }
    }

    #endregion

}
