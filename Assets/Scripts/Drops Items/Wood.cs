using UnityEngine;

public class Wood : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private float timeMove;

    private float timeCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;

        if (timeCount < timeMove)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerItems>().TotalWood++;
            Destroy(gameObject);
        }
    }

}
