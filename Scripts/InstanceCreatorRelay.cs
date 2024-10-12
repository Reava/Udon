using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UwUtils
{
    [AddComponentMenu("UwUtils/InstanceCreatorRelay")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class InstanceCreatorRelay : UdonSharpBehaviour
    {
        [Header("Name of the event")]
        [SerializeField] private string eventName = "_interact";
        [Header("Programs to send a custom event to")]
        [SerializeField] private UdonBehaviour[] programsList;

        void Start()
        {
            if (!Utilities.IsValid(programsList) || programsList.Length == 0) { _sendDebug("Programs list is empty or invalid"); return; } // Skip if Empty
            VRCPlayerApi localPlayer = Networking.LocalPlayer;
            if (Networking.LocalPlayer.isMaster)
            {
                foreach (UdonBehaviour b in programsList)
                {
                    b.SendCustomEvent(eventName);
                }
            }
        }

        public void _sendDebug(string text)
        {
            Debug.LogWarning("[UwUtils/InstanceCreatorRelay.cs] " + text + " on '" + gameObject.name + "', did you mean this?", gameObject);
        }
    }
}