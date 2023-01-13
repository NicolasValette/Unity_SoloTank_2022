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
    [SerializeField]
    private float _detectionRange = 10f;
    [SerializeField]
    private GameObject _goTurretHead;
    [SerializeField]
    private GameObject _goRaySpawnPosition;

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
                if (Physics.Raycast(_goRaySpawnPosition.transform.position, _goRaySpawnPosition.transform.forward, out hit, _detectionRange))
                {
                    Debug.DrawRay(_goRaySpawnPosition.transform.position, _goRaySpawnPosition.transform.forward * 20f);
                    Debug.DrawLine(_goRaySpawnPosition.transform.position, _goRaySpawnPosition.transform.forward * 20f);
                   // Debug.Log("Touché : " + hit.collider.gameObject.name);
                    if (hit.collider.gameObject.GetComponent<TankController>() != null)
                    {
                        
                        _goTurretHead.transform.LookAt(hit.transform.position);
                        Fire();
                    }
                }
            }
        }
    }
    protected void Rotate(Vector3 euler)
    {
        _goTurretHead.transform.parent.eulerAngles += euler;
    }

    protected override void TakeDamage(int ammount)
    {
        LifePoint -= ammount;
        if (LifePoint <= 0)
        {
            TurretManager.NbAliveTurret--;
            EventManager.TriggerEvent(EventManager.Events.OnTurretDeath, new Dictionary<string, object> { { "Turret", TurretManager.NbAliveTurret } });
            Destroy(gameObject);
        }
    }
}
