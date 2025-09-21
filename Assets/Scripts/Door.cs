using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform rightRoom;
    public Transform leftRoom;
    public CameraController cam;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // From left of collider to right
            if (collision.transform.position.x > transform.position.x)
            {
                cam.MoveToNewRoom(rightRoom);
            }
            else
            {
                cam.MoveToNewRoom(leftRoom);
            }
        }
        
    }
}
