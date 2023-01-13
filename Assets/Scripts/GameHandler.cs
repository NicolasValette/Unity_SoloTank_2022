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
    private void OnEnable()
    {
        EventManager.StartListening(EventManager.Events.OnQuit, GameQuit);
        EventManager.StartListening(EventManager.Events.OnWin, GameWin);
        EventManager.StartListening(EventManager.Events.OnLoose, GameOver);
    }
    private void OnDisable()
    {
        EventManager.StopListening(EventManager.Events.OnQuit, GameQuit);
        EventManager.StopListening(EventManager.Events.OnWin, GameWin);
        EventManager.StopListening(EventManager.Events.OnLoose, GameOver);
    }

    // Update is called once per frame
    void Update()
    {
    
        if (!IsGameOn)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                IsGameOn= true;
            }
        }
       
    }

    public static void GameOver(Dictionary<string, object> obj)
    {
        IsGameOver = true;
    }
    public void GameQuit(Dictionary<string, object> obj)
    {
        Application.Quit(); 
    }
    public void GameWin(Dictionary<string, object> obj)
    {
        Debug.Log("Win, not implemented");
    }
 
}
