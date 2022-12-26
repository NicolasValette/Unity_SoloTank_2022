using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
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
    [SerializeField]
    private MeshRenderer _mGroundColor;

    private GameObject _goTargetAcquired;
    // Start is called before the first frame update
    void Start()
    {
        
        _mGroundColor.material.color = _cColorOff;
        //for (int i = 0; i < _lCanons.Count; i++)
        //{
        //    _mHeads.Add(_lCanons[i].GetComponent<MeshRenderer>().material);
        //    _mHeads[i].color = _cColorOff;
        //}
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
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.CompareTag("Tank") || other.gameObject.CompareTag("BotTank"))
        {
            Debug.Log("TANK");
            _bIsLocked = true;
            _goTargetAcquired = other.gameObject;
            _mGroundColor.material.color = _cColorOn;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        if (other.gameObject.CompareTag("Tank") || other.gameObject.CompareTag("BotTank"))
        {
            _bIsLocked = false;
            _goTargetAcquired = null;
            _mGroundColor.material.color = _cColorOff;
        }
    }




}
