using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed;
    public float currentPosX;
    public Vector3 velocity = Vector3.zero;

    public Transform player;
    public float aheadDistance;
    public float speed;
    public float lookAhead;

    public void Awake()
    {
        transform.position = new Vector3(2, 3, -10);
    }

    public void Update() {
        if (player.position.x >= 3) { 
            transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
            lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z),
                ref velocity, cameraSpeed);
        }
    }
    public void MoveToNewRoom(Transform room) {
        currentPosX = room.position.x;
    }
}
