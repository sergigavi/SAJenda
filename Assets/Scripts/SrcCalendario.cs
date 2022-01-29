using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SrcCalendario : MonoBehaviour
{
    private GameObject pnlCalendario;
    private Image imgCalendario;
    private int mesActual;
    

    // Start is called before the first frame update
    void Awake()
    {
        pnlCalendario = GameObject.Find("pnlCalendario");
        imgCalendario = GameObject.Find("ImgCalendario").GetComponent<Image>();
        InicializarMes();
    }

    public void AvanzarImagen()
    {
        mesActual++;
        if (mesActual > 12)
        {
            mesActual = 1;
        }
        imgCalendario.sprite = Resources.Load<Sprite>("ImagenesCalendario/"+mesActual);
    }

    public void RetrocederImagen() 
    {
        if (mesActual == 1)
        {
            mesActual = 13; 
        }
        mesActual--;
        imgCalendario.sprite = Resources.Load<Sprite>("ImagenesCalendario/"+mesActual); 
    }

    public void CerrarCalendario()
    {
        pnlCalendario.SetActive(false);
        InicializarMes();
    }

    void InicializarMes()
    {
        DateTime dt = DateTime.Now;
        mesActual = (int) dt.Month;
        imgCalendario.sprite = Resources.Load<Sprite>("ImagenesCalendario/"+mesActual);
    }
}
