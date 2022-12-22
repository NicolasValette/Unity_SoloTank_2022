using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class BaseController : MonoBehaviour
{
    [SerializeField]
    protected GameObject BulletPrefab;
    [SerializeField]
    protected List<GameObject> BulletSpawnPosition;
    [SerializeField]
    protected LayerMask Mask;
    [SerializeField]
    protected int Cooldown;
    [SerializeField]
    protected int MaxLifePoint;
    [SerializeField]
    protected int MaxAmmo;                  // 0 for infinite

    public int CurrentAmmo { get; set; }

    public int LifePoint { get; set; }

    private bool isCanonReady;
    protected float NextShootAvailable;


    protected void Fire()
    {
       // Debug.Log("Fire");
        if (Time.time > NextShootAvailable)
        {
            // Debug.Log("Instantiate");
            for (int i = 0; i < BulletSpawnPosition.Count; i++)
            {
                Instantiate<GameObject>(BulletPrefab, BulletSpawnPosition[i].transform.position, BulletSpawnPosition[i].transform.rotation);
                NextShootAvailable = Time.time + Cooldown;
                CurrentAmmo--;
            }
        }
    }

    protected abstract void TakeDamage(int amount);



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(collision.gameObject.GetComponent<BulletController>().Damage);
        }
    }
}
