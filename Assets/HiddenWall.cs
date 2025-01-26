using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddenWall : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private TilemapRenderer tilemapRenderer;
    [SerializeField] private bool activate = true;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        tilemapRenderer = GetComponent<TilemapRenderer>();
        if (activate)
            activateObject();
        else
            desactivateObject();
    }

    private void Update()
    {
    }

    public void UpdateActivationObject(){
        activate = !activate;
        if (activate == true)
            activateObject();
        else
            desactivateObject();
    }

    public void activateObject()
    {
        boxCollider.enabled = true;
        tilemapRenderer.sortingOrder = 1;
    }

    public void desactivateObject()
    {
        boxCollider.enabled = false;
        tilemapRenderer.sortingOrder = -1;
    }
}