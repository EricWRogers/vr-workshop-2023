using UnityEngine;

public class VirtualMaximizeButton : VirtualButton
{
    private RectTransform window;
    public BoxCollider2D grabBar;
    private bool isMax = false;
    private Vector2 originalSizeDelta;

    private void Start()
    {
        window = transform.parent.GetComponent<RectTransform>();
        originalSizeDelta = window.sizeDelta;
    }

    public override void ClickBehavior()
    {
        base.ClickBehavior();

        if (!isMax)
        {
            isMax = true;
            window.sizeDelta = Vector2.zero;
            RectTransformExtensions.SetAnchor(window, AnchorPresets.StretchAll);
            grabBar.enabled = false;
            return;
        }

        window.sizeDelta = originalSizeDelta;
        RectTransformExtensions.SetAnchor(window, AnchorPresets.MiddleCenter);
        grabBar.enabled = true;
        isMax = false;
    }
}
