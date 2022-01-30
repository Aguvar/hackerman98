using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailLoader 
{
    //Poner los nombres de los prefabs en la lista correspondiente, y los archivos en las subcarpetas

    const string BASE_PATH = "Prefabs/Mails";
    const string NORMAL_MAIL_PATH = "Normal";
    const string SPAM_MAIL_PATH = "Spam";
    const string MISC_MAIL_PATH = "Misc";

    public static string GetRandomEmailPath() {
        int rand = Random.Range(0,3);
        switch (rand) {
            case 0:
                return GetNormalEmailPath();
            case 1:
                return GetSpamEmailPath();
            case 2:
                return GetMiscEmailPath();
            default:
                return GetNormalEmailPath();
        }
    }


    public static string GetNormalEmailPath() {
        string result = string.Format("{0}/{1}/{2}", BASE_PATH, NORMAL_MAIL_PATH, normalMails[Random.Range(0,normalMails.Length)]);
        return result;
    }

    public static string GetSpamEmailPath() {
        string result = string.Format("{0}/{1}/{2}", BASE_PATH, SPAM_MAIL_PATH, spamMails[Random.Range(0,spamMails.Length)]);
        return result;
    }

    public static string GetMiscEmailPath() {
        string result = string.Format("{0}/{1}/{2}", BASE_PATH, MISC_MAIL_PATH, miscMails[Random.Range(0,miscMails.Length)]);
        return result;
    }


    static string[] normalMails = {
        "normal1",
        "normal2",
    };

    static string[] spamMails = {
        "spam1",
        "spam2",
    };

    static string[] miscMails = {
        "misc`1",
    };


}
