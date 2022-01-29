using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrControlPaneles : MonoBehaviour
{
    private GameObject pnlInicial;
    private GameObject pnlMenu;
    private GameObject pnlCalendario;
    private GameObject pnlPerfil;
    private GameObject pnlNotas;

    //private Button btnEntrar;

    
    void Awake()
    {
        inicializarVariables();
    }

    private void Start()
    {
        pnlCalendario.SetActive(false);
        pnlPerfil.SetActive(false);
    }

    public void AbrirCalendario()
    {
        pnlCalendario.SetActive(true);
    }

    public void abrirPerfil()
    {
        pnlPerfil.SetActive(true);
    }

    public void AbrirNotas() 
    {
        pnlNotas.SetActive(true);
    }

    public void inicializarVariables()
    {
        pnlInicial = GameObject.Find("PnlInicial");
        pnlMenu = GameObject.Find("pnlMenu");
        pnlCalendario = GameObject.Find("pnlCalendario");
        pnlPerfil = GameObject.Find("pnlPerfil");
        pnlNotas = GameObject.Find("PnlNotas");
    }

    public void irMenu()
    {
        pnlInicial.SetActive(true);
    }

}
