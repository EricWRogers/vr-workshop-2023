using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class VirtualTextInput : MonoBehaviour
{
    public int requiredTextAmount = 50;

    private List<PhysicsButton> keys;
    private TextMeshProUGUI text;
    [HideInInspector]
    public UnityEvent onFinish = new UnityEvent();
    [HideInInspector]
    public bool isActive = false;

    protected virtual void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        keys = new List<PhysicsButton>(FindObjectsOfType<PhysicsButton>());
        keys.ForEach(key => key.onPressed.AddListener(AppendText));
        onFinish.AddListener(Finish);
    }

    private void AppendText(string _text)
    {
        if (isActive)
        {
            if (text.text.Length >= requiredTextAmount)
            {
                onFinish.Invoke();
                isActive = false;
                return;
            }

            if (_text.Contains("CODE::"))
            {
                return;
            }

            text.SetText(text.text + _text);
        }
    }

    protected virtual void Finish()
    {

    }
}
