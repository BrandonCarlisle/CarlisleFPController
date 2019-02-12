using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public bool isFiring;
    public FPSPlayerController GunOwner;
    public BulletController bullet;
    public float bulletSpeed;
    public float shotInterval;
    public float cooldown;
    private float shotCount;
    private float timer;

    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        timer = cooldown;
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        

        if (isFiring) {
          
            if (timer >= cooldown) {
                shotCount = shotInterval;
                bullet.FiredFrom = this;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                newBullet.speed = bulletSpeed;
                timer = 0;
            }

        }
    }
}
