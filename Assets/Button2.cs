using UnityEngine;

public class Button2 : MonoBehaviour
{
    [SerializeField] private HiddenWall ActivateObject;

    [SerializeField] private bool trigeredWhenBubble = false;

    [SerializeField] private bool trigeredWhenBubbled = false;

    [SerializeField] private bool trigeredWhenCharacter = true;

    [SerializeField] private bool canBeDesactivated = false;
    private bool isTrigerred = false;


    private void Awake()
    {
    }

    private void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTrigerred == false)
        {
            if (collision.tag == "Player" && trigeredWhenCharacter)
            {
                ButtonEffect();
            }
            if (collision.tag == "Box" && trigeredWhenBubbled)
            {
                ButtonEffect();
            }
            if (collision.tag == "bubble" && trigeredWhenBubble)
            {
                ButtonEffect();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isTrigerred == true)
        {
            if (collision.tag == "Player" && trigeredWhenCharacter && canBeDesactivated)
            {
                ButtonEffect();
            }
            if (collision.tag == "Box" && trigeredWhenBubbled && canBeDesactivated)
            {
                ButtonEffect();
            }
            if (collision.tag == "bubble" && trigeredWhenBubble && canBeDesactivated)
            {
                ButtonEffect();
            }
        }
    }

    private void ButtonEffect(){
        ActivateObject.UpdateActivationObject();
        isTrigerred = !isTrigerred;
    }
}
