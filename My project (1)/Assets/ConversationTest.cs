using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class ConversationTest : MonoBehaviour
{[SerializeField] private NPCConversation myConversation;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ConversationManager.Instance.StartConversation(myConversation);
            }
        }
    }
}
