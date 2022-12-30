using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameHandler : MonoBehaviour
{
    public static bool IsGameOver { get; set; } = false;
    public static bool IsGameOn { get; set; } = false;

  

    [SerializeField]
    private GameObject _goUIHandler;

    private static UIHandler _uiHandler;

    public static bool IsWin
    {
        get
        {
            if (TurretManager.NbAliveTurret <= 0)
            {
                if (IsGameOn)
                {
                    IsGameOn = false;
                    _uiHandler.GameWin();
                }


                return true;
            }
            return false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        _uiHandler = _goUIHandler.GetComponent<UIHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Echap");
            Application.Quit();
        }
        if (!IsGameOn)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                IsGameOn= true;
            }
        }
       
    }

    public static void GameOver()
    {
        IsGameOver = true;
    }
 
}
