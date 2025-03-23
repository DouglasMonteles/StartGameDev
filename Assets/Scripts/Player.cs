using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

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
    }

    private void Update()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

}
