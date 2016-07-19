﻿using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{

    public Transform Bullet;
    Vector3 playerPosition;
    public GameObject player;
    private bool isShootPressed = false;
    private float lastShotTime = float.MinValue;
    private float fireRate = 1;
    private float damage = 1;
    public int SHOTGUN_NUM_SHOTS = 6;
    public int NORMAL_F2_NUM_SHOTS = 2;

    public enum Weapons { Normal, NormalF2, Shotgun, ShotgunF2, Laser, LaserF2 };
    public Weapons CurrentWeapon;

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
                fireRate = 20;
                damage = 50;
                if (isShootPressed && Time.time > lastShotTime + (3.0f / fireRate))
                {
                    lastShotTime = Time.time;
                    shootBullet();
                }
                break;

            case Weapons.NormalF2:
                fireRate = 20;
                damage = 50;
                if (isShootPressed && Time.time > lastShotTime + (3.0f / fireRate))
                {
                    lastShotTime = Time.time;
                    shootBulletNF2();
                    shootBullet(); //straight bullet
                }
                break;


            case Weapons.Shotgun:
                fireRate = 5;
                if (isShootPressed && Time.time > lastShotTime + (3.0f / fireRate))
                {
                    lastShotTime = Time.time;
                    shootBulletS();
                }

                break;

            case Weapons.ShotgunF2:
                fireRate = 10;
                if (isShootPressed && Time.time > lastShotTime + (3.0f / fireRate))
                {
                    lastShotTime = Time.time;
                    shootBulletS();
                }

                break;

            case Weapons.Laser:
                fireRate = 100;
                damage = 5;
                if (isShootPressed && Time.time > lastShotTime + (3.0f / fireRate))
                {
                    lastShotTime = Time.time;
                    shootBullet();
                }
                break;

            case Weapons.LaserF2:
                fireRate = 100;
                damage = 5;
                if (isShootPressed && Time.time > lastShotTime + (3.0f / fireRate))
                {
                    lastShotTime = Time.time;
                    shootBullet();
                }
                break;
        }
    }


    public void shootBullet()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        Instantiate(Bullet, playerPosition, Quaternion.identity);
    }

    public void shootBulletNF2()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        int rotation = 20;
        for (int i = 0; i < NORMAL_F2_NUM_SHOTS; i++)
        {
            if(i%2 != 0) //change rotation on even iterations
            {
                rotation = -rotation;
            }
            Instantiate(Bullet, playerPosition, Quaternion.Euler(new Vector3(0, 0, rotation)));
        }
    }

    public void shootBulletS()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        int rotation = 45;
        for (int i = 0; i < SHOTGUN_NUM_SHOTS; i++)
        {
            if (i % 2 != 0) //change rotation on even iterations
            {
                rotation = -rotation;
            }
            Instantiate(Bullet, playerPosition, Quaternion.Euler(new Vector3(0, 0, Random.Range(0, rotation))));
        }
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
