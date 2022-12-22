using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private GameObject _goPlayerCanon;
    [SerializeField]
    private Vector3 _vOffset;
    [SerializeField]
    private float _fRotateSpeed;

    private float yaw = 0f;
    private float pitch = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameHandler.IsGameOn && !GameHandler.IsGameOver)
        {
            PlaceCamera();
            RotateTank();
            RotateCamera();
        }
    }


    private void PlaceCamera()
    {
        transform.position = _goPlayerCanon.transform.position;
    }
    private void RotateTank()
    {
        transform.rotation = _goPlayerCanon.transform.parent.rotation;
    }
    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * _fRotateSpeed * Time.deltaTime;
       
        yaw += mouseX;
        mouseX = Mathf.Clamp(mouseX, -45f, 45f);
        pitch += Input.GetAxis("Mouse Y") * _fRotateSpeed * Time.deltaTime;
        yaw = Mathf.Clamp(yaw, -45f, 45f);
        pitch = Mathf.Clamp(pitch, -10f, 10f);      //Invert Direction

        transform.Rotate(0f, yaw, pitch);
        _goPlayerCanon.transform.rotation = transform.rotation;
        
        
    }
}
