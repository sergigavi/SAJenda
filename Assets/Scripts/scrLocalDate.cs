using System.Collections;
using System.Collections.Generic;
using System;
//using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class scrLocalDate : MonoBehaviour
{

  public DateTime localDateNow;
  public GameObject hora;
  public GameObject fecha;

    void Start()
    {
        localDateNow = DateTime.Now;  //.UtcNow;
        hora = GameObject.Find("widgetFechayHora");
        fecha = GameObject.Find("widgetFechayHora2");
    }

    void Update()
    {
      localDateNow = DateTime.Now;
      //Console.WriteLine(localDateNow.ToString());
      //Debug.Log(localDateNow.ToString("F"));//Con esto me muestra todo, dia de la semana numero mes y hora
      //Debug.Log(localDateNow.ToString());

      hora.GetComponent<Text>().text = localDateNow.ToString().Substring(11);
      //Debug.Log(localDateNow.ToString().Substring(11));

      fecha.GetComponent<Text>().text = localDateNow.ToString().Substring(0, 10);
      //Debug.Log(localDateNow.ToString().Substring(0, 10));

    }
}
