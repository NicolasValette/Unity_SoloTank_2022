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
    private TMP_Text _fadeText;
    [SerializeField]
    private GameObject StartScreen;
    [SerializeField]
    private Color _cWinImageColor;
    [SerializeField]
    private Color _cWinTextColor;
    private TankController _tank;
    private float _fadeProgress = 0f;


    public void GameWin()
    {
        Debug.Log("Win UI");
        _fadeText.text = "You Win ! Congrats !\nEscape to quit.";
        _fadeText.color = _cWinTextColor;
        _fadeScreen.color = _cWinImageColor;
    }

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
        if (GameHandler.IsGameOver || GameHandler.IsWin)
        {
            _fadeProgress += Time.deltaTime;
            _tLifeText.text = " PV : 0";
            UnityEngine.Color color = _fadeScreen.color;
            color.a = Mathf.Lerp(0f, 1f, _fadeProgress);

            _fadeScreen.color = color;
            color.r = _fadeText.color.r;
            color.g = _fadeText.color.g;
            color.b = _fadeText.color.b;
            _fadeText.color = color;
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
