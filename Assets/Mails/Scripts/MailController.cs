using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailController : MonoBehaviour
{
    [SerializeField]
    string[] from;

    [Space]

    [SerializeField]
    string[] subjects;

    private void Start() {
        vpi();
    }

    public void vpi() {
        int rFrom = Random.Range(0, from.Length - 1);
        int rSub = Random.Range(0, subjects.Length - 1);
        MailsManager.SetMailMetadata(from[rFrom], subjects[rSub]);
    }

    public void MailWin() {
        MailsManager.MailWin();
    }

    public void MailLose() {
        MailsManager.MailLose();
    }
}
