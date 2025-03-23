using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rig;

    private Vector2 direction;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime);
    }

}
