using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour
{

    public Transform Bullet;
    Vector3 playerPosition;
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Ship");
    }


    public void shotThatBullet()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        Instantiate(Bullet, playerPosition, Quaternion.identity);

    }
}
