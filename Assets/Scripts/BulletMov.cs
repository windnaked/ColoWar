using UnityEngine;
using System.Collections;

public class BulletMov : MonoBehaviour
{

    private float maxSpeed = 5f;
    private float width;
    private float height;
    private Camera cam;
    public GameObject bullet;

    void Start()
    {
        cam = Camera.main;
        bullet.GetComponent<GameObject>();
        /*@param 
         * cam.orthographicSize devolve o tamanho da camara em metade, logo multiplica-se por 2
         * cam.aspect devolve o aspect ratio da camara que se usa para descobrir a width porque a conta fica width = (height_calculada * height_da_cam/width_da cam) 
         * cortam as heigths e fica a width da cam (como uma equacao)
         
        */
        height = (2f * cam.orthographicSize)+ 0.5f; //bias value 0.5 to make sure the bullet exits the screen
        width = (height * cam.aspect)+ 0.5f;

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
        //bias value -0.5 to make sure the bullet exits the screen
        if (pos.x <= -0.5 || pos.y <= -0.5 || pos.x >= width || pos.y >= height) {
            Destroy(bullet);
        }

        transform.position = pos;

        
    }
}
