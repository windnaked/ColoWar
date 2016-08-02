using UnityEngine;
using System.Collections;

public class EnemyMov : MonoBehaviour
{

    public float MinForce = 20f;
    public float MaxForce = 40f;
    public float DirectionChangeInterval = 1f;
    public Rigidbody2D rb;
    private Camera cam;
    private Vector2 camSize;
    private float minionSize = 0.5f;
    private Vector3 position;
    float x, y, force;
    public float health;


    private float directionChangeInterval;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        camSize = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight));
        directionChangeInterval = DirectionChangeInterval;
        rb = GetComponent<Rigidbody2D>();
        Move();

    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;

        directionChangeInterval -= Time.deltaTime;

        if (directionChangeInterval < 0)
        {
            Move();
            directionChangeInterval = DirectionChangeInterval;
        }

        if (position.x <= -minionSize || position.y <= -minionSize || position.x >= camSize.x + minionSize || position.y >= camSize.y + minionSize)
        {
            rb.AddForce(force * new Vector2(-x, -y));
        }
    }

    void Move()
    {
        float force = Random.Range(MinForce, MaxForce);
        float x = Random.Range(-1, 1.1f);
        float y = Random.Range(-1, 1.1f);
        Debug.Log("x" + x);
        Debug.Log("y" + y);

        rb.AddForce(force * new Vector2(x, y));
    }

    //void ReverseMove()
    //{
    //    float force = Random.Range(MinForce, MaxForce);
    //    float x = Random.Range(-1, 2);
    //    float y = Random.Range(-1, 2);
    //    Debug.Log("x" + x);
    //    Debug.Log("y" + y);

    //    rb.AddForce(force * new Vector2(x, y));
    //}
}
