using UnityEngine;
using System.Collections;

public class BulletMov : MonoBehaviour
{

    private float maxSpeed = 5f;
    private float width;
    private float height;
    private Camera cam;
    public GameObject bullet;
    private Vector2 camSize;
    private const float BULLET_SIZE = 0.2f;

    void Start()
    {
        cam = Camera.main;
        bullet.GetComponent<GameObject>();
        camSize = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight));

    }
    // Update is called once per frame
    void Update()
    {


        Vector3 pos = transform.position;

        //Para a velocidade damos um vector3 onde o único valor que se altera é o y, e o Y é dado pelo maxSpeed * o destaTime,
        //o Time.deltaTime é usado quando se quer fazer algo andar como se fizesse 10metros por segundo em vez de por frame
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

        //aqui multiplica-se pela rotação para que caso a nave rodar a bala fique também nessa direção, 
        //neste caso não é necessário mas pode vir a ser quando se fizer as balas de lado e assim

        pos += transform.rotation * velocity;
        //bias value -0.2 to make sure the bullet exits the screen
        if (pos.x <= -BULLET_SIZE || pos.y <= -BULLET_SIZE || pos.x >= camSize.x + BULLET_SIZE || pos.y >= camSize.y + BULLET_SIZE)
        {
            Destroy(bullet);
        }

        transform.position = pos;


    }
}
