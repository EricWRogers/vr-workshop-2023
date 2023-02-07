using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class AnimateStrikethrough : MonoBehaviour
{
    public Image line;
    public TextMeshProUGUI descriptionBox;
    public float animationTime = .5f;
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponentInParent<TextMeshProUGUI>();
    }

    public void DoStrikeThrough()
    {
        line.rectTransform.LeanScaleX(text.GetRenderedValues().x + 20f, animationTime).setEaseOutQuart().setOnComplete(FadeOut);
    }

    public void FadeOut()
    {
        text.CrossFadeAlpha(0, 1f, false);
        descriptionBox.CrossFadeAlpha(0f, 1f, false);
        line.rectTransform.LeanAlpha(0f, 1f).setOnComplete(RemoveText);
    }

    public void RemoveText()
    {
        Destroy(text.gameObject);
        Destroy(descriptionBox.gameObject);
    }
}
