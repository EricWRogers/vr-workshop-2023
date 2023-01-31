using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostVignette : HallucinationEvent
{
    public PostProcessVolume m_Volume;
    Vignette m_Vignette;
    
    public override void PerformHallucinationEvent()
    {
        base.PerformHallucinationEvent();
        m_Vignette.enabled.Override(false);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);
    }
}
