using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TurretController : BaseController
{
    [SerializeField]
    private float _fMinRotatespeed;
    [SerializeField]
    private float _fMaxRotateSpeed;
    [SerializeField]
    private bool _bIsActive = true;

    private float _fSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        _fSpeed = Random.Range(_fMinRotatespeed, _fMaxRotateSpeed);
        if (_bIsActive)
        {
            TurretManager.NbAliveTurret++;
            TurretManager.NbMaxTurret++;
        }
      //  Debug.Log("Speed : " + _fSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameHandler.IsGameOn)
        {


            if (_bIsActive)
            {


                Rotate(new Vector3(0f, _fSpeed, 0f));

                RaycastHit hit;
                if (Physics.Raycast(BulletSpawnPosition[0].transform.position, BulletSpawnPosition[0].transform.up, out hit))
                {
                    Debug.DrawRay(BulletSpawnPosition[0].transform.position, BulletSpawnPosition[0].transform.up * 20f);
                    // Debug.Log("Touché : " + hit.collider.gameObject.name);
                    Fire();
                }
            }
        }
    }
    protected void Rotate(Vector3 euler)
    {
        transform.eulerAngles += euler;
    }

    protected override void TakeDamage(int ammount)
    {
        LifePoint -= ammount;
        if (LifePoint <= 0)
        {
            TurretManager.NbAliveTurret--;
            Destroy(gameObject);
        }
    }
}
