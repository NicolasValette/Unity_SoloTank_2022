using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    private List<TurretController> TurretList= new List<TurretController>();
    public static int NbAliveTurret { get; set; } = 0;
    public static int NbMaxTurret { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
