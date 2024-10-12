using UnityEngine;
using UdonSharp;
using VRC.SDKBase;

namespace UwUtils
{
    [AddComponentMenu("UwUtils/Object State Setter")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class ObjectStateSetter : UdonSharpBehaviour
    {
        [Header("List of objects to toggle ON")]
        [SerializeField] private GameObject[] toggleObjectsON;
        [Header("List of objects to toggle OFF")]
        [SerializeField] private GameObject[] toggleObjectsOFF;
        private bool valid = true;
        void Start()
        {
            if ((!Utilities.IsValid(toggleObjectsOFF) && !Utilities.IsValid(toggleObjectsON)) || (toggleObjectsOFF.Length == 0 && toggleObjectsON.Length == 0))
            {
                valid = false;
                Debug.LogError("[UwUtils/iStateSet.cs] No objects found to toggle '" + gameObject.name + "'");
            }
            else
            {
                return;
            }
        }

        public override void Interact()
        {
            foreach (GameObject toggleObject in toggleObjectsON)
            {
                toggleObject.SetActive(true);
            }
            foreach (GameObject toggleObject in toggleObjectsOFF)
            {
                toggleObject.SetActive(false);
            }
        }

        public void _Invert()
        {
            foreach (GameObject toggleObject in toggleObjectsON)
            {
                toggleObject.SetActive(false);
            }
            foreach (GameObject toggleObject in toggleObjectsOFF)
            {
                toggleObject.SetActive(true);
            }
        }
        public void _Flip()
        {
            foreach (GameObject toggleObject in toggleObjectsON)
            {
                toggleObject.SetActive(!toggleObject.activeSelf);
            }
            foreach (GameObject toggleObject in toggleObjectsOFF)
            {
                toggleObject.SetActive(!toggleObject.activeSelf);
            }
        }
    }
}