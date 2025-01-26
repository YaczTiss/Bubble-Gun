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
            ButtonEffect();
        }
        if (collision.tag == "bubbled" && trigeredWhenBubble)
        {
            ButtonEffect();
        }
        if (collision.tag == "bubble" && trigeredWhenBubble)
        {
            ButtonEffect();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("hello");
        if (collision.tag == "Player" && canBeDesactivated)
        {
            ButtonEffect();
        }
        if (collision.tag == "bubbled" && trigeredWhenBubble && canBeDesactivated)
        {
            ButtonEffect();
        }
        if (collision.tag == "bubble" && trigeredWhenBubble && canBeDesactivated)
        {
            ButtonEffect();
        }
    }

    private void ButtonEffect(){
        ActivateDoor.UpdateActivationDoor();
        ActivateObject.UpdateActivationObject();
    }
}
