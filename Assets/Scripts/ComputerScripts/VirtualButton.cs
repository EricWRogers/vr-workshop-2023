using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class VirtualButton : MonoBehaviour
{
    public Image highlight;

    //This stays public for the scenario that you might want to add outside listeners as well
    public UnityEvent onClick = new UnityEvent();

    protected void Awake()
    {
        onClick.AddListener(ClickBehavior);
    }

    public virtual void ClickBehavior()
    {

    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ClickPoint"))
            highlight.enabled = true;
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ClickPoint"))
            highlight.enabled = false;
    }
}
