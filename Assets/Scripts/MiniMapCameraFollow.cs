using UnityEngine;

public class MiniMapCameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject _goTargetToFollow;
    [SerializeField]
    private Vector3 _fYOffset;


    // Update is called once per frame
    void Update()
    {
        transform.position = _goTargetToFollow.transform.position + _fYOffset;        
    }
}
