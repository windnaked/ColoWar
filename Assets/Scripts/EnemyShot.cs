using UnityEngine;
using System.Collections;

public class EnemyShot : MonoBehaviour
{

    public Transform Bullet;
    Vector3 enemyPosition;
    public GameObject enemy;
    private float lastShotTime = float.MinValue;
    private float fireRate = 1;
    private float damage = 1;
    public enum Fase { Fase1, Fase2 };
    public Fase CurrentFase;

    // Use this for initialization
    void Start()
    {
        enemy = GameObject.Find("Monster3");
        CurrentFase = Fase.Fase1;

    }

    // Update is called once per frame
    void Update()
    {

        switch (CurrentFase)
        {
            case Fase.Fase1:
                fireRate = 20;
                damage = 50;
                if (Time.time > lastShotTime + (3.0f / fireRate))
                {
                    lastShotTime = Time.time;
                    shootBullet();
                }
                break;
        }
    }

    public void shootBullet()
    {
        enemyPosition = enemy.transform.position;
        Instantiate(Bullet, enemyPosition, Quaternion.Euler(0, 0, 180));
       // Instantiate(Bullet, enemyPosition, Quaternion.Euler(new Vector3(0, 0, Random.Range(90, 270))));
    }
}
