using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IATankController : BaseController
{

    [SerializeField]
    private GameObject _goPlayerDetected;
    [SerializeField]
    private int _iDamage;

    private bool _bIsLocked;
    private NavMeshAgent _Agent;

    public int Damage
    {
        get { return _iDamage; }
    }
    // Start is called before the first frame update
    void Start()
    {
        _bIsLocked = false;
        _Agent = GetComponent<NavMeshAgent>();
        _Agent.destination = _goPlayerDetected.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _Agent.destination = _goPlayerDetected.transform.position;
    }
    private bool DetectPlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(BulletSpawnPosition[0].transform.position, BulletSpawnPosition[0].transform.forward, out hit))
        {
            Debug.DrawRay(BulletSpawnPosition[0].transform.position, BulletSpawnPosition[0].transform.forward * 20f);
            // Debug.Log("Touché : " + hit.collider.gameObject.name);
            
            if (hit.transform.gameObject.CompareTag("tank"))
            {
                _goPlayerDetected = hit.transform.gameObject;
                _bIsLocked= true;
            }
            else
            {
                _bIsLocked= false;
            }
        }
        return _bIsLocked;
    }
    private void Move(Vector3 dir)
    {

    }
    private void Rotate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Salut");
    }

    protected override void TakeDamage(int amount)
    {
        LifePoint -= amount;
        if (LifePoint <= 0)
        {
            Destroy(gameObject);
        }
    }
}
