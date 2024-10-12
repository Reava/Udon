using UnityEngine;
using UdonSharp;
using VRC.SDKBase;
using VRC.SDK3.Persistence;

namespace UwUtils
{
    [AddComponentMenu("UwUtils/Objects Toggle")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class ObjectsToggle : UdonSharpBehaviour
    {
        [Header("List of objects to toggle")]
        [SerializeField] private GameObject[] toggleObjects;
        [Header("Define a unique string for persistence, leave empty to not save.")]
        [SerializeField] private string persistenceString;
        private bool isToggled = false;

        private bool shouldPersist = false;

        void Start()
        {
            if (toggleObjects.Length == 0)
            {
                Debug.LogError("[UwUtils/iState.cs] No objects defined to toggle on '" + gameObject.name + "', did you mean this?");
            }
            else
            {
                return;
            }
        }

        public override void OnPlayerRestored(VRCPlayerApi player)
        {
            if (string.IsNullOrWhiteSpace(persistenceString)) return;
            if (!player.isLocal) return;
            shouldPersist = true; // This is only true if persistence is available & used, wont be needed in the future.
            if (PlayerData.TryGetBool(player, persistenceString, out bool objectState))
            {
                if (isToggled != objectState)
                {
                    isToggled = objectState;
                    _InvertState(); // We only call this when the state was inverted before instead of loading the actual state of objects to make it simpler
                }
            }
        }

        public override void Interact() => _InvertState();

        public void _SaveState() => PlayerData.SetBool(persistenceString, isToggled); // Save new state

        public void _InvertState()
        {
            foreach (GameObject toggleObject in toggleObjects)
            {
                toggleObject.SetActive(!toggleObject.activeSelf);
            }
            isToggled = !isToggled;
            if (shouldPersist) _SaveState();
        }

        /* Warning: This will cause persistence saving to be out of sync and is only meant as a code template!
        public void _EnableAll()
        {
            foreach (GameObject toggleObject in toggleObjects)
            {
                toggleObject.SetActive(true);
            }
        } 
        */ // Uncomment if you want to use it

        /* Warning: This will cause persistence saving to be out of sync and is only meant as a code template!
        public void _DisableAll()
        {
            foreach (GameObject toggleObject in toggleObjects)
            {
                toggleObject.SetActive(false);
            }
        }
        */ // Uncomment if you want to use it
    }
}