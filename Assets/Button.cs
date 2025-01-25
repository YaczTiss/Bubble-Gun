using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Door ActivateDoor;
    [SerializeField] private HiddenWall ActivateObject;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" )
        {
            ActivateDoor.activateDoor();
            ActivateObject.desactivateObject();
        }

    }
}
