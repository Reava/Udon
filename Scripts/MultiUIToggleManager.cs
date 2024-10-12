using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

namespace UwUtils
{
    namespace UwUtils
    {
        [AddComponentMenu("UwUtils/Multi UI Toggle Manager")]
        [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
        public class MultiUIToggleManager : UdonSharpBehaviour
        {
            [Space]
            public bool DefaultToggleValue = true;
            [Space]
            [SerializeField] private Toggle[] TargetToggles = new Toggle[0];
            [Header("Target behaviors to send an event on value change to")]
            [Space]
            [SerializeField] private UdonBehaviour[] TargetBehaviorUpdate;
            [SerializeField] private string eventName = "_interact";
            [Space]
            [SerializeField] private bool enableLogging = true;

            void Start()
            {
                if (!Utilities.IsValid(TargetToggles) || TargetToggles.Length == 0)
                {
                    Debug.Log("[UwUtils/ToggleHub.cs]: Empty or invalid array detected on: " + gameObject.name + ". Did you mean this?", gameObject);
                    return;
                }
                foreach (Toggle s in TargetToggles)
                {
                    if (!s) continue;
                    s.SetIsOnWithoutNotify(DefaultToggleValue);
                }
            }

            public override void Interact() => _ToggleChange();

            private void _ToggleChange()
            {
                if (enableLogging) Debug.Log("[UwUtils/ToggleHub.cs]: Change detected, updating values from: " + gameObject.name + "", gameObject);
                if (!Utilities.IsValid(TargetToggles)) return;
                bool found = false;
                Toggle tempToggle = null;
                foreach (Toggle s in TargetToggles)
                {
                    if (!s) continue;
                    if (found) s.SetIsOnWithoutNotify(DefaultToggleValue);
                    if (s.isOn != DefaultToggleValue)
                    {
                        DefaultToggleValue = s.isOn;
                        tempToggle = s;
                        found = true;
                    }
                }
                foreach (Toggle s in TargetToggles)
                {
                    if (!s) continue;
                    s.SetIsOnWithoutNotify(DefaultToggleValue);
                    if (s == tempToggle) break;
                }
                foreach (UdonBehaviour target in TargetBehaviorUpdate)
                {
                    if (!target) continue;
                    target.SendCustomEvent(eventName);
                }
            }
        }
    }
}