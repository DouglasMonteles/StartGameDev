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

    private int handleObj;

    private bool _isDigging;

    public bool IsDigging { get => _isDigging; set => _isDigging = value; }

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();  
        initialSpeed = speed; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            handleObj = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            handleObj = 2;
        }

        OnInput();
        OnRun();
        OnRolling();
        OnCutting();
        OnDig();
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
        if (handleObj == 1)
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
        if (handleObj == 2)
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

    #endregion

}
