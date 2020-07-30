using Albatross;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albatross
{
    public class Door : MonoBehaviour, IInteractables
    {
        public GameObject Destination;

        public void Interact()
        {
            Debug.Log("Door Interaction");
            PlayerController player = FindObjectOfType<PlayerController>();
            Camera camera = FindObjectOfType<Camera>();

            player.transform.position = new Vector3(Destination.transform.position.x, Destination.transform.position.y, player.transform.position.z);
            camera.transform.position = new Vector3(Destination.transform.position.x, Destination.transform.position.y, camera.transform.position.z);
        }
    }
}