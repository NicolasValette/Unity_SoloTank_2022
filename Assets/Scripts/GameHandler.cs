using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameHandler : MonoBehaviour
{
    public static bool IsGameOver { get; set; } = false;
    public static bool IsGameOn { get; set; } = false;

    public static GameHandler _instance;
    public static GameHandler Instance
    {
        get
        {
            if (Instance == null)
            {
                Debug.Log("erreur");
            }
            return _instance;
        }
    }



    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
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
        if (IsWin())
        {

        }
    }

    public bool IsWin ()
    {
        return TurretManager.NbAliveTurret <= 0;
    }
}
