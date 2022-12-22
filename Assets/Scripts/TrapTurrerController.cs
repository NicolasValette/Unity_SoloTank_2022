using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTurrerController : BaseController
{

    [SerializeField]
    private GameObject _goHeadCanon;
    [SerializeField]
    private Color _cColorOff;
    [SerializeField]
    private Color _cColorOn;
    private bool _bIsLocked = false;

    private Material _mHead;

    private GameObject _goTargetAcquired;
    // Start is called before the first frame update
    void Start()
    {
        _mHead = gameObject.GetComponent<MeshRenderer>().material;
        _mHead.color = _cColorOff;
    }

    // Update is called once per frame
    void Update()
    {
        if (_bIsLocked)
        {
            _goHeadCanon.transform.LookAt(_goTargetAcquired.transform);
            Fire();
        }
    }

    protected override void TakeDamage(int amount)
    {
        //DoNothing ... todo
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("Tank"))
    //    {
    //        _bIsLocked = true;
    //        _goTargetAcquired = collision.gameObject;
    //        _mHead.color = _cColorOn;
    //    }
    //}
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tank"))
        {
            _bIsLocked = false;
        }
    }


}
