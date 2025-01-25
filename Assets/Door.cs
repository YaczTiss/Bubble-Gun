using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform prev_room;
    [SerializeField] private Transform next_room;
    [SerializeField] private CameraController camera;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
                camera.MoveToNewRoom(next_room);
            else 
            {
                camera.MoveToNewRoom(prev_room);   
            }
        }
    }
}
