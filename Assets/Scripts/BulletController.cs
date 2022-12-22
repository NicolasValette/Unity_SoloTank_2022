using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float _fBulletSpeed;
    [SerializeField]
    private float _fLifeSpan;

    [SerializeField]
    private int _iDamage;
    public int Damage
    {
        get { return _iDamage; }
    }

    private float _fDateOfDeath;

    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody= GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.up * _fBulletSpeed);
        _fDateOfDeath = Time.time + _fLifeSpan;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _fDateOfDeath)
        {
            Destroy(transform.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(transform.gameObject);
    }
}
