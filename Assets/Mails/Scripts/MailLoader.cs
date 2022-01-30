using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailLoader 
{
    //Poner los nombres de los prefabs en la lista correspondiente, y los archivos en las subcarpetas

    const string BASE_PATH = "Prefabs/Mails";
    const string NORMAL_MAIL_PATH = "Normal";
    const string SPAM_MAIL_PATH = "Spam";
    const string ANSWER_MAIL_PATH = "Answer";
    const string CATEGORY_MAIL_PATH = "Cat";

    public static string GetRandomEmailPath() {
        int rand = Random.Range(0,5); //0, 3, 4 tiran mails normales, que son la mayor�a
        //int rand = 0;
        switch (rand) {
            case 0:
                return GetNormalEmailPath();
            case 1:
                return GetSpamEmailPath();
            case 2:
                return GetAnswerEmailPath();
            default:
                return GetNormalEmailPath();
        }
    }


    public static string GetNormalEmailPath() {
        string result = string.Format("{0}/{1}/{2}", BASE_PATH, NORMAL_MAIL_PATH, normalMails[Random.Range(0,normalMails.Length)]);
        return result;
    }

    public static string GetSpamEmailPath() {
        string result = string.Format("{0}/{1}/{2}", BASE_PATH, SPAM_MAIL_PATH, spamMails[Random.Range(0,spamMails.Length - 1)]);
        return result;
    }

    public static string GetAnswerEmailPath() {
        string result = string.Format("{0}/{1}/{2}", BASE_PATH, ANSWER_MAIL_PATH, answerMails[Random.Range(0,answerMails.Length - 1)]);
        return result;
    }


    static string[] normalMails = {
        "normal1",
        "normal2",
        "normal3",
        "normal4",
        "normal5",
        "normal6",
        "normal7",
        "normal8",
    };

    static string[] spamMails = {
        "spam1",
        "spam2",
        "spam3",
        "spam4",
        "spam5",
        "spam6",
        "spam7",
        "spam8",
        "spam9",
        "spam10",
        "spam11",
        "spam12",
        "spam13",
        "spam14",
        "spam15",
        "spam16",
        "spam17",
        "spam18",
        "spam19",
        "spam20",
    };

    static string[] answerMails = {
        "answer1",
        "answer2",
        "answer3",
        "answer4",
    };

    static string[] catMails = {
        "misc`1",
    };


}
