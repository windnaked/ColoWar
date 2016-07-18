using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{

    public Transform Bullet;
    Vector3 playerPosition;
    public GameObject player;
    private bool isShootPressed = false;
    private float lastShotTime = float.MinValue;
    public float fireRate = 1;
    enum Weapons { Normal, Shotgun, Laser };
    Weapons CurrentWeapon;

    void Start()
    {
        player = GameObject.Find("Ship");
        CurrentWeapon = Weapons.Normal;

    }

    void Update()
    {
        switch (CurrentWeapon)
        {
            case Weapons.Normal:
                if (isShootPressed && Time.time > lastShotTime + (3.0f / fireRate))
                {
                    lastShotTime = Time.time;
                    shootBullet();
                }
                break;

            case Weapons.Shotgun:
              break;

            case Weapons.Laser:
              break;
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
