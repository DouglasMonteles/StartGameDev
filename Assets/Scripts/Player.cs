using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    [SerializeField]
    private float runSpeed;

    private float initialSpeed;

    private bool _isRunning;

    public bool isRunning {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    private Rigidbody2D rig;

    private Vector2 _direction;

    public Vector2 direction
    {
        get { return _direction; }
        set { direction = value; }
    }

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();  
        initialSpeed = speed; 
    }

    private void Update()
    {
        OnInput();
        OnRun();
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

    #endregion

}
