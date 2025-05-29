using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;      
    public Vector3 offset;   
    public float smoothSpeed = 0.125f;

    public float minX, maxX;


    private void FixedUpdate()
    {
        Vector3 newPosition = player.position + new Vector3(0, 0, -30);
        newPosition.y = -0.65f;
        transform.position = newPosition;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
    }

    /*void LateUpdate()
    {
        if (player == null)
            return;

        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }*/
}
