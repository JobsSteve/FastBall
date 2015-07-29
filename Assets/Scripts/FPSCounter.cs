using System;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public float updateInterval = 0.5F;

    private int m_FpsAccumulator = 0;
    private float m_FpsNextPeriod = 0;
    private int m_CurrentFps;
    private Text m_fpsText;

    private void Start()
    {
        m_FpsNextPeriod = Time.realtimeSinceStartup + updateInterval;
        m_fpsText = GameObject.Find("/Canvas/FPS").GetComponent<Text>();
    }

    private void Update()
    {
        // measure average frames per second
        m_FpsAccumulator++;

        //m_fpsText.text = String.Format("{0:0.00}\n{1:0.00}\n{2:0.00}", Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);
            
        if (Time.realtimeSinceStartup > m_FpsNextPeriod)
        { 
            m_CurrentFps = (int)(m_FpsAccumulator / updateInterval);
            m_FpsAccumulator = 0;
            m_FpsNextPeriod += updateInterval;

            if (m_CurrentFps < 30)
                m_fpsText.text = "<color=red>" + m_CurrentFps + " FPS</color>";
            else if (m_CurrentFps < 55)
                m_fpsText.text = "<color=yellow>" + m_CurrentFps + " FPS</color>";
            else
                m_fpsText.text = "<color=green>" + m_CurrentFps + " FPS</color>";
        }
    }
}
