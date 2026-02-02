using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    [SerializeField] private Transform heroTransform;

    private Vector3 offset;
    private Vector3 newCameraPosition;
    [SerializeField] private float followSpeed;


    void Start()
    {
        offset = transform.position - heroTransform.position;
    }

    void LateUpdate()
    {
       SetCameraSmoothFollow();
        // newCameraPosition = heroTransform.position + offset;
        // transform.position = Vector3.Lerp(transform.position, newCameraPosition, followSpeed * Time.deltaTime);
    }
    private void SetCameraSmoothFollow()

    {
    Vector3 targetPosition = heroTransform.position + offset;
    transform.position = Vector3.Lerp(
        transform.position,
        targetPosition,
        followSpeed * Time.deltaTime
    );
    
}

}