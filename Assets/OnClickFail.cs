using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickFail : MonoBehaviour
{
    private void OnMouseDown() {
        MailsManager.MailLose();
    }
}
