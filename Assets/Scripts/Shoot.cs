using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{

    public Transform Bullet;
    Vector3 playerPosition;
    public GameObject player;
    private bool isShootPressed = false;
    private float fireRate; //nao sei o que fazer com isto

    void Start()
    {
        player = GameObject.Find("Ship");
    }

    //parte chata disto... Ele em cada frame vai estar a verificar se esta a disparar ou nao
    void Update()
    {
        if (isShootPressed)
        {
            shootBullet();
        }
    }


    public void shootBullet()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        Instantiate(Bullet, playerPosition, Quaternion.identity);
    }

    public void onPointerDownShootButton()
    {
        isShootPressed = true;
    }
    public void onPointerUpShootButton()
    {
        isShootPressed = false;
    }

}
