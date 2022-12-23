using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TankController : BaseController
{
    [SerializeField]
    private float _fSpeed;
    [SerializeField]
    private float _fTurnSpeed;
    [SerializeField] 
    private GameObject _goCanon;
    [SerializeField]
    private float _fRotateSpeed;
    [SerializeField]
    private float ReloadTime;

    public bool IsReloading { get; private set; }
    

    

    private float yaw = 0f;
    private float pitch = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PV : " + MaxLifePoint);
        LifePoint = MaxLifePoint;
        
        CurrentAmmo = MaxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameHandler.IsGameOn)
        {
            Move();
            Turn();
            Rotate();
            Shoot();
            Reload();
            Debug.DrawLine(transform.position, BulletSpawnPosition[0].transform.forward);
        }
    }

    private void Move()
    {
      
        if (Input.GetAxis("Vertical") != 0f)
        {
            transform.Translate(0f, 0f, Input.GetAxis("Vertical") * _fSpeed * Time.deltaTime);
        }
    }
    private void Turn()
    {
        if (Input.GetAxis("Horizontal") != 0f)
        {
            transform.Rotate(0f, Input.GetAxis("Horizontal") * _fTurnSpeed * Time.deltaTime, 0f);
        }
    }
    private void Rotate()
    {
        
       // yaw = Input.GetAxis("Mouse X") * _fRotateSpeed;
       // pitch += Input.GetAxis("Mouse X");
       // yaw = Mathf.Clamp(yaw, -45f, 45f);
       // //Debug.Log("Angle : " + yaw);
       //_goCanon.transform.Rotate(0f,yaw , 0f);
       //_goCanon.transform.eulerAngles = new Vector3(yaw * _fRotateSpeed * Time.deltaTime, pitch * _fRotateSpeed * Time.deltaTime, 0f);
    }
    private void Shoot()
    {
        if (Input.GetAxis("Fire1")!=0)
        {
            Debug.Log("FEU");
            Fire();
        }
    }

    protected override void TakeDamage(int ammount)
    {
    
        LifePoint -= ammount;
        if (LifePoint <= 0)
        {
            GameHandler.IsGameOver = true;
            Destroy(gameObject);
        }
    }

    public void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && CurrentAmmo < MaxAmmo)
        {

            IsReloading= true;
            NextShootAvailable = Time.time + ReloadTime;
        }
        else if (IsReloading && NextShootAvailable < Time.time)
        {
            IsReloading= false;
            CurrentAmmo = MaxAmmo;
        }
    }

}
