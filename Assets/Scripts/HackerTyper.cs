using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class HackerTyper : MonoBehaviour
{
    //why bother
    public MacroGameManager macroParent;
    public GameObject Paneloide;
    public TextMeshProUGUI PastaText;
    public string[] chosenPasta;
    public KeyCode[] listaInput;
    //List <KeyCode> requestedInput = new List<KeyCode>();
    public float textCD; // cooldown before inputting more text
    private int magicNum;
    public int pastaCount;
    public int keyStrokeCount;

    // Start is called before the first frame update

    //Versión no rancia
    string textoParaAgregar = "";
    Coroutine textAdderCR;

    private void CoolTextStarter()
    { //Llamá a este script cuando empieces tu hackertyper
        textAdderCR = StartCoroutine(CoolTextAdderInternal());
    }

    private void CoolTextAdder(string agregar)
    { //Llamá esto para agregar texto
        textoParaAgregar = textoParaAgregar + agregar;
    }

    private void CerrandoHackertexto()
    { // llamá esto cuando esté siendo cerrada la ventana hacker para que en la versión final no haya un memory leak leve
        if (textAdderCR != null)
        StopCoroutine(textAdderCR);
    }

    private IEnumerator CoolTextAdderInternal()
    {
        while (true)
        {
            if (textoParaAgregar.Length > 0)
            {
                if (textoParaAgregar.Length > 20)
                { //Si hay mas de estos caracteres empieza a agregar más de uno por frame
                    int lengthToAdd = (textoParaAgregar.Length / 2);
                    PastaText.text = PastaText.text + textoParaAgregar.Substring(0, lengthToAdd);
                    textoParaAgregar = textoParaAgregar.Substring(lengthToAdd);
                }
                else
                {
                    PastaText.text = PastaText.text + textoParaAgregar[0];
                    textoParaAgregar = textoParaAgregar.Substring(1);
                }
            }
            yield return null;
        }
    }

    public void BeginHack()
    {
        Paneloide.SetActive(true);
        PastaText.gameObject.SetActive(true);
        CoolTextStarter();
        PastaText.text = ("");
        pastaCount = 0;
        string text = Resources.Load<TextAsset>("Text/pastaLista").text;
        char[] separators = { '|' };
        string[] strValues = text.Split(separators);
        magicNum = Random.Range(0, strValues.Length);
        char separationator = ('+');
        chosenPasta = strValues[magicNum].Split(separationator);

        Debug.Log("Limite Tecleo: " + (chosenPasta.Length - chosenPasta.Length / 10));
    }

    private void Start()
    {
    }

    //private void OnGUI(){
    //    Event pija = Event.current;
    //    if (Event.current.isKey)
    //    {
    //        Debug.Log("tocaste " + pija.keyCode);
    //        foreach (KeyCode tecla in listaInput)
    //        {
    //            if (pija.keyCode == tecla) {
    //                inputado = true;
    //            }
    //        }
    //    }
    //}


    //private void CoolTextAdder(string agregar)
    //{
    //    StartCoroutine(CoolTextAdderInternal(agregar));
    //}

    //private IEnumerator CoolTextAdderInternal(string agregar)
    //{
    //    for (int i = 0; i < agregar.Length; i++)
    //    {
    //        //yield return new WaitForSeconds(0.000000001f); Usa esta línea si querés que espere un tiempo de pausa
    //        yield return null;
    //        PastaText.text = PastaText.text + agregar[i];
    //    }
    //}



    private void Update()
    {
        foreach (KeyCode tecla in listaInput)
        {
            if (Input.GetKeyDown(tecla) )
            {
                keyStrokeCount++;
                tecleo();
            }
        }
        textCD = textCD - 1 * Time.deltaTime;


    }

    public void EndHack()
    {
        CerrandoHackertexto();
        PastaText.gameObject.SetActive(false);
        Paneloide.SetActive(false);
        gameObject.SetActive(false);
    }

    private void tecleo()
    {

        if (textCD <= 0 && pastaCount < chosenPasta.Length)
        {
            CoolTextAdder(chosenPasta[pastaCount]);
            pastaCount++;
            textCD = 0.05f;
            //Debug.Log("Pasta Count = " + pastaCount + ", Longitud de la Pasta = " + chosenPasta.Length);
        }
        //else
        //    Debug.Log("No arrancó. Pasta Count = "+ + pastaCount + ", Longitud de la Pasta = " + chosenPasta.Length);
    }
    // Update is called once per frame

}
