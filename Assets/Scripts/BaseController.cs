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
    protected float Cooldown;
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
                EventManager.TriggerEvent(EventManager.Events.OnAmmoModification, new Dictionary<string, object> { { "Ammo", CurrentAmmo } });
                EventManager.TriggerEvent(EventManager.Events.OnFire, null);
            }
        }
    }

    protected abstract void TakeDamage(int amount);



    private void OnCollisionEnter(Collision collision)
    {
        /* Preferer la vérification de Componant plutot que la vérification de tag si c'est sur un GO contenant un objet C#
         * gameObject.GetComponent<TankController>() != null
         * (GetComponentInParent) Test le component, puis tout les parents, plus chere en ressource, nécéssaire si on tape la tete de tourelle par ex
         * Un test sur une string peut amener un certain nombre d'erreur */
        if (collision.gameObject.CompareTag("Bullet")) 
        {
            TakeDamage(collision.gameObject.GetComponent<BulletController>().Damage);
        }
        if (collision.gameObject.CompareTag("BotTank"))
        {
            TakeDamage(collision.gameObject.GetComponent<IATankController>().Damage);
        }
    }
}
