using UdonSharp;
using UnityEngine;

namespace UwUtils
{
    [AddComponentMenu("UwUtils/Reflection Probe Controller")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class ReflectionProbeController : UdonSharpBehaviour
    {
        #region References

        [Header("References")]

        #endregion
        [Range(0, 30)]
        public float updateInterval = 1.5f;
        [HideInInspector] public bool updateLoop = true;
        [SerializeField] private ReflectionProbe reflectionProbeSource;

        public void Start()
        {
            if (reflectionProbeSource == null) // Attempt to fetch Reflection Probe on self if ref is empty
            {
                if (gameObject.GetComponent<ReflectionProbe>() == null) { _sendDebug("No reflection probe reference found"); return; }
                reflectionProbeSource = gameObject.GetComponent<ReflectionProbe>();
            }
            reflectionProbeSource.mode = UnityEngine.Rendering.ReflectionProbeMode.Realtime;
            reflectionProbeSource.refreshMode = UnityEngine.Rendering.ReflectionProbeRefreshMode.ViaScripting;
            UpdateReflections();
        }

        public void UpdateReflections()
        {
            reflectionProbeSource.RenderProbe();
            if (updateLoop) SendCustomEventDelayedSeconds(nameof(UpdateReflections), updateInterval);
        }

        public void ToggleLoop()
        {
            updateLoop = !updateLoop;
            if (updateLoop) UpdateReflections();
        }

        public void _sendDebug(string text)
        {
            Debug.LogWarning("[UwUtils/InstanceCreatorRelay.cs] " + text + " on '" + gameObject.name + "', did you mean this?", gameObject);
        }
    }
}