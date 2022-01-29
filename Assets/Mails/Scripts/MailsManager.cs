using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailsManager : MonoBehaviour {

    public Transform mailParent;

    public int mailMax = 10;
    public int mailStart = 5;
    public int mailPenalty = 2;

    [Space]
    public int pocosEmails = 3;
    public int muchosEmails = 7;

    public float mailRandomMin = 1f;

    public float mailRandomMax = 5f;

    private bool failGrace = false;

    private static MailsManager _instance;
    public static MailsManager Instance {
        get {
            return _instance;
        }
    }


    private GameObject currentMail = null;


    private int mailCount = 0;

    public int EmailCount {
        get {
            return mailCount;
        }
    }

    public void Start() {
        SetupStart();
        StartCoroutine(EmailAdder());
        StartCoroutine(MailChecker());
    }

    /// <summary>
    /// Agrega la cantidad de mails especificada al contador de mails entrantes, si safe = true entonces si los emails causarían la derrota del player, se agrega uno menos, sin efecto si falta un solo email para perder
    /// </summary>
    public void AddEmails(int amount, bool safe = false) {
        int mailSum = mailCount + amount;
        if (safe) {
            if (mailCount != mailMax && mailSum > mailMax) {
                mailCount = mailMax;
            } else {
                mailCount = mailSum;
            }

        } else {
            mailCount = mailSum;
        }
        CheckNextEmail();
    }

    private IEnumerator EmailAdder() {
        while (true) {
            float timer = Random.Range(mailRandomMin, mailRandomMax);
            if (mailCount < pocosEmails) { //Si hay menos de 3 emails el timer se vuelve la mitad
                timer = timer * 0.5f;
            }
            yield return new WaitForSeconds(timer);
            if (mailCount > muchosEmails) { //Si hay más de 7 emails se agrega un poco random de tiempo a la espera
                yield return new WaitForSeconds(Random.Range(0.5f,2f));
                if (mailCount == mailMax) { //Si está en el máximo de emails (1 más y pierde) le damos un segundo extra de tiempo
                    yield return new WaitForSeconds(1f);
                }
            }
            if (failGrace) { //Si acaba de fallar, se espera medio segundo extra para evitar que se pisen los sonidos y que no confunda de donde vinieron tantos emails
                yield return new WaitForSeconds(0.5f);
            }
            int rand = -1;
            if (mailCount < pocosEmails) {
                rand = Random.Range(0, 3); //tira un numero del 0 al 2, solo se usa cuando hay pocos emails
            } else {
                rand = Random.Range(0, 10); //tira un número del 0 al 9
            }
            switch (rand) {
                case 0: //Si sale 0, agrega dos emails en vez de uno
                    AddEmails(2, true);
                    break;
                default:
                    AddEmails(1);
                    break;
            }
        }
    }

    private IEnumerator MailChecker() {
        while (true) {
            yield return new WaitForSeconds(0.5f);
            CheckNextEmail();
            CheckTooManyMails();
        }
    }


    public void SetupStart() {
        mailCount = mailStart;
        NextMail();
    }


    public void LoadRandomEmail() {
        string path = MailLoader.GetRandomEmailPath();
        GameObject toInstantiate = Resources.Load<GameObject>(path);
        LoadMailPrefab(toInstantiate);
    }

    public void LoadMailPrefab(GameObject prefab) {
        CloseEmail();
        currentMail = Instantiate<GameObject>(prefab, mailParent);
    }


    public void CloseEmail() {
        if (currentMail == null) {
            return;
        }
        GameObject mailRef = currentMail;
        Destroy(mailRef);
        currentMail = null;
    }

    public void CheckNextEmail() {
        if (currentMail == null) {
            NextMail();
        }
    }

    

    public void NextMail() {
        mailCount = mailCount - 1;
        LoadRandomEmail();
    }

    public void CheckTooManyMails() {
        if (mailCount > mailMax) {
            TriggerDefeat();
        }
    }

    public void TriggerDefeat() {
        //Triggerear el estado de perder el juego acá
    }


    public static void MailWin() {
        Instance.MailWinInternal();
    }

    public static void MailLose() {
        Instance.MailLoseInternal();
    }


    private void MailWinInternal() {
        LoadRandomEmail();
    }

    private void MailLoseInternal() {
        AddEmails(mailPenalty);
        StartCoroutine(EmailGracePeriod());
    }

    private IEnumerator EmailGracePeriod() {
        failGrace = true;
        yield return new WaitForSeconds(1f);
        failGrace = false;
    }

}
