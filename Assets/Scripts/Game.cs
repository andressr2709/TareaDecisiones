using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;



public class Game : MonoBehaviour
{


    public TextMeshProUGUI enunciado;
    public TextMeshProUGUI[] opciones;
    public Opcion opcionInicio;
    public Opcion opcionActual;
    public GameObject[] botonOpciones;
    public GameObject btnCreditos;

    // Start is called before the first frame update
    void Start()
    {
        cargarBancoPreguntas();
        opcionActual = opcionInicio;
        setPregunta();
    }

    public void setPregunta()
    {
        enunciado.text = opcionActual.enunciado;
        for (int i = 0; i < opciones.Length; i++)
        {
            opciones[i].text = opcionActual.opciones[i].opcionSeleccionada;
        }

    }


    public void cargarBancoPreguntas()
    {
        try
        {
            opcionInicio =
            JsonConvert.DeserializeObject<Opcion>(File
            .ReadAllText(Application.streamingAssetsPath +
            "/QuestionBank.json"));
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);

            enunciado.text = ex.Message;
        }
    }

    public void evaluarPregunta(int respuestaJugador)
    {
        opcionActual = opcionActual.opciones[respuestaJugador];
        if (opcionActual.esFinal)
        {
            enunciado.text = opcionActual.enunciado;
            for (int i = 0; i < botonOpciones.Length; i++)
            {
                botonOpciones[i].SetActive(false);
            }
        btnCreditos.SetActive(true);
        }
        else
        {
            setPregunta();
        }

    }




}