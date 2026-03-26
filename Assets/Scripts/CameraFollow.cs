using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 distanceOffset;
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        float newX = distanceOffset.x;
        float newY = target.position.y + distanceOffset.y; 
        float newZ = target.position.z + distanceOffset.z; 
        Vector3 desiredPosition = new Vector3(newX,newY,newZ);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
