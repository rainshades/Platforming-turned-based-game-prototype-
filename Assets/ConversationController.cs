using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

namespace Albatross {
    public class ConversationController : MonoBehaviour
    {
        [SerializeField]
        private GameObject SayDialogPrefab;
        private GameObject go;


        void Awake()
        {
            go = Instantiate(SayDialogPrefab);
            go.name = "SayDialog";
        }
    }
}
