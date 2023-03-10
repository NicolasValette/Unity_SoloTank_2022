using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public enum Events
    {
        OnLoose,
        OnQuit,
        OnWin,
        OnAmmoModification,
        OnLooseLife,
        OnTurretDeath,
        OnFire
    }
    private Dictionary<Events, Action<Dictionary<string, object>>> eventDictionnary;

    private static EventManager _instance;

    public static EventManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EventManager();
                _instance.Init();
            }
            return _instance;
        }
    }
    public void Init()
    {
        eventDictionnary = new Dictionary<Events, Action<Dictionary<string, object>>>();
    }
    public static void StartListening(Events eventName, Action<Dictionary<string, object>> action)
    {
        Action<Dictionary<string, object>> eventToListen;
        Debug.Log("Start Listening event : " + eventName + ". Action : " + action.ToString());
        if (Instance.eventDictionnary.TryGetValue(eventName, out eventToListen))
        {
            eventToListen += action;
            Instance.eventDictionnary[eventName] = eventToListen;
        }
        else
        {
            eventToListen += action;
            Instance.eventDictionnary.Add(eventName, action);
        }
    }
    public static void StopListening(Events eventName, Action<Dictionary<string, object>> action)
    {
        Action<Dictionary<string, object>> eventToStopListen;
        Debug.Log("Stop Listening event : " + eventName + ". Action : " + action.ToString());
        if (Instance.eventDictionnary.TryGetValue(eventName, out eventToStopListen))
        {
            eventToStopListen -= action;
            Instance.eventDictionnary[eventName] = eventToStopListen;
        }
    }

    public static void TriggerEvent(Events eventName, Dictionary<string, object> parameters)
    {
        Action<Dictionary<string, object>> eventToTrigger;
        Debug.Log("Try to Invoke : " + eventName);
        if (Instance.eventDictionnary.TryGetValue(eventName, out eventToTrigger))
        {
            eventToTrigger.Invoke(parameters);
        }
    }



}
