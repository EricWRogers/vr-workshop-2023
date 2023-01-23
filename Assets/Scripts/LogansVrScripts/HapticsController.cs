using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticsController : MonoBehaviour
{
    public XRBaseController leftController, rightController;
    [Tooltip("How hard we vibrate.")]
    public float defaultAmplitude = 0.2f;
    [Tooltip("How long we vibrate.")]
    public float defaultDuration = 0.5f;
   
    [ContextMenu("Send Haptics")] //For testing purposes.
    public void SendDualHaptics()
    {
        leftController.SendHapticImpulse(defaultAmplitude,defaultDuration);
        rightController.SendHapticImpulse(defaultAmplitude, defaultDuration);
    }
    public void SendLeftHaptics(float amplitude, float duration)
    {
        leftController.SendHapticImpulse(amplitude, duration);
    }

    public void SendRightHaptics(float amplitude, float duration)
    {
        rightController.SendHapticImpulse(amplitude, duration);
    }

   

}
