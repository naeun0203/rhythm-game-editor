using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTrigger : MonoBehaviour
{
    public bool noteTrigger;
    public GameObject TriggerObject;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(noteTrigger);
        Debug.Log(TriggerObject);
        if (coll.gameObject.CompareTag("note"))
        {
            noteTrigger = true;
            TriggerObject = coll.gameObject;
        }
        else
        {
            noteTrigger = false;
            TriggerObject = null;
        }
    }
}
