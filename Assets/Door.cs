using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform prev_room;
    [SerializeField] private Transform next_room;
    [SerializeField] private CameraController camera;
    [SerializeField] private bool activate = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && activate)
        {
            if (collision.transform.position.x < transform.position.x)
                camera.MoveToNewRoom(next_room);
            else 
            {
                camera.MoveToNewRoom(prev_room);   
            }
        }
    }

    public void UpdateActivationDoor(){
        activate = !activate;
    }
}
