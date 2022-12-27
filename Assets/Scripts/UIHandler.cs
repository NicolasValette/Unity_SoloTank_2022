using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _tLifeText;
    [SerializeField]
    private TMP_Text _tAmmoText;
    [SerializeField]
    private GameObject _goPlayer;
    [SerializeField]
    private TMP_Text _tTurretAliveText;
    [SerializeField]
    private Image _fadeScreen;
    [SerializeField]
    private GameObject StartScreen;
    private TankController _tank;



    // Start is called before the first frame update
    void Start()
    {
        _tank = _goPlayer.GetComponent<TankController>();
        _tLifeText.color = Color.black;
        _tAmmoText.color = Color.black;
        _tTurretAliveText.color = Color.black;
        _tLifeText.text = " PV : " + _tank.LifePoint.ToString();
        _tAmmoText.text = " Ammo : " + _tank.CurrentAmmo.ToString();
        _tTurretAliveText.text = $"Turret Alive {TurretManager.NbAliveTurret} / {TurretManager.NbMaxTurret}";
    }

    // Update is called once per frame
    void Update()
    {


        if (GameHandler.IsGameOn)
        {
            StartScreen.SetActive(false);
        }
        if (GameHandler.IsGameOver)
        {
            _tLifeText.text = " PV : 0";
            Debug.Log("WIN");
            UnityEngine.Color color = _fadeScreen.color;

            color.a = Mathf.Lerp(_fadeScreen.color.a, 1f, Time.deltaTime);

            _fadeScreen.color = color;
        }
        else
        {
            _tLifeText.text = " PV : " + _tank.LifePoint.ToString();
            _tTurretAliveText.text = _tTurretAliveText.text = $"Turret Alive {TurretManager.NbAliveTurret} / {TurretManager.NbMaxTurret}";
            if (_tank.IsReloading)
            {
                _tAmmoText.text = "Ammo : RELOADING !!";
            }
            else if (_tank.CurrentAmmo <= 0)
            {
                _tAmmoText.text = "Push 'R' to Reload !";
            }
            else
            {
                _tAmmoText.text = "Ammo : " + _tank.CurrentAmmo.ToString();
            }
        }
    }
}
