using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapZoneController : BaseController
{

    [SerializeField]
    private List<GameObject> _lCanons;
    [SerializeField]
    private Color _cColorOff;
    [SerializeField]
    private Color _cColorOn;
    private bool _bIsLocked = false;

    private List<Material> _mHeads = new List<Material>();

    private GameObject _goTargetAcquired;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _lCanons.Count; i++)
        {
            _mHeads[i] = _lCanons[i].GetComponent<MeshRenderer>().material;
            _mHeads[i].color = _cColorOff;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_bIsLocked)
        {
            for (int i = 0; i < _lCanons.Count; i++)
            {
                _lCanons[i].transform.LookAt(_goTargetAcquired.transform);
                Fire();
            }
        }
    }
    protected override void TakeDamage(int amount)
    {
        //DoNothing ... todo
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnCollisionEnter");
        if (other.gameObject.CompareTag("Tank"))
        {
            Debug.Log("TANK");
            _bIsLocked = true;
            _goTargetAcquired = other.gameObject;
            for (int i = 0; i < _mHeads.Count; i++)
            {
                _mHeads[i].color = _cColorOn;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnCollisionEnter");
        if (other.gameObject.CompareTag("Tank"))
        {
            _bIsLocked = false;
            _goTargetAcquired = null;
            for (int i = 0; i < _mHeads.Count; i++)
            {
                _mHeads[i].color = _cColorOff;
            }
        }
    }




}
