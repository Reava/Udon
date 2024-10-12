using UdonSharp;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using VRC.SDKBase;

namespace UwUtils
{
    [AddComponentMenu("UwUtils/PostProcessingController")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class PostProcessingController : UdonSharpBehaviour
    {
        [Header("Main Slider, optional if using the SliderHub")]
        [SerializeField] private Slider slider;
        [Space]
        [SerializeField] private PostProcessVolume[] ControlledVolumes;
        [Space]
        [SerializeField] private bool useSliderHub = true;
        [SerializeField] private MultiUISliderManager SliderHubRef;
        private float targetFloat;
        [Space]
        [SerializeField] private bool enableLogging = true;

        public override void Interact() => _updateVolume();
        void Start() => _updateVolume();

        public void _updateVolume()
        {
            if(!Utilities.IsValid(ControlledVolumes) || ControlledVolumes.Length == 0)
            {
                _sendDebug("No post processing volume found");
            }
            if (!useSliderHub && slider)
            {
                targetFloat = slider.value;
            }
            else
            {
                _checkHubValue();
            }
            if (!Utilities.IsValid(ControlledVolumes)) return;
            foreach(PostProcessVolume pp in ControlledVolumes)
            {
                pp.weight = targetFloat;
            }
        }

        public void _checkHubValue()
        {
            targetFloat = SliderHubRef.DefaultSliderValue;
        }

        public void _sendDebug(string text)
        {
            Debug.LogWarning("[UwUtils/InstanceCreatorRelay.cs] " + text + " on '" + gameObject.name + "', did you mean this?", gameObject);
        }
    }
}