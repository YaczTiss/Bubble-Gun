using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Door ActivateDoor;
    [SerializeField] private HiddenWall ActivateObject;

    [SerializeField] private bool trigeredWhenBubble = false;

    [SerializeField] private bool canBeDesactivated = false;

    private void Awake()
    {
    }

    private void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ActivateDoor.UpdateActivationDoor();
            ActivateObject.UpdateActivationObject();
        }
        if (collision.tag == "bubbled" && trigeredWhenBubble)
        {
            ActivateDoor.UpdateActivationDoor();
            ActivateObject.UpdateActivationObject();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("hello");
        if (collision.tag == "Player" && canBeDesactivated)
        {
            desactivateButtonEffect();
        }
        if (collision.tag == "bubbled" && trigeredWhenBubble && canBeDesactivated)
        {
            desactivateButtonEffect();
        }
    }

    private void desactivateButtonEffect(){
        ActivateDoor.UpdateActivationDoor();
        ActivateObject.UpdateActivationObject();
    }
}
