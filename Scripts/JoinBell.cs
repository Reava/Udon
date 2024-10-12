using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

namespace UwUtils
{
    [AddComponentMenu("UwUtils/JoinBell")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class JoinBell : UdonSharpBehaviour
    {
        [Header("References")]
        [SerializeField] private AudioSource AudioSource;
        [SerializeField] private AudioClip JoinSound;
        [SerializeField] private AudioClip LeaveSound;
        [Header("Defaults")]
        [SerializeField] private bool JoinEnable = true;
        private bool abort = false;

        private void Start()
        {
            if (!Utilities.IsValid(AudioSource))
            {
                _sendDebugError("No audio source found, disabling script");
                abort = true;
                return;
            }
        }
        public override void OnPlayerJoined(VRCPlayerApi player)
        {
            if (abort) return;
            if (Utilities.IsValid(JoinSound) && JoinEnable)
            {
                AudioSource.clip = JoinSound;
                AudioSource.Play();
            }
        }
        public override void OnPlayerLeft(VRCPlayerApi player)
        {
            if (abort) return;
            if (Utilities.IsValid(LeaveSound) && JoinEnable)
            {
                AudioSource.clip = LeaveSound;
                AudioSource.Play();
            }
        }

        public void _JoinToggle()
        {
            JoinEnable = !JoinEnable;
        }

        public void _sendDebugError(string text)
        {
            Debug.LogError("[UwUtils/JoinBell.cs] " + text + " on '" + gameObject.name + "', did you mean this?", gameObject);
        }
    }
}