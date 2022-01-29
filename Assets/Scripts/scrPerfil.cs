using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class scrPerfil : MonoBehaviour
{
    private DataService ds = new DataService("BBDD_Usuarios.db");
    private InputField inptUsuario;
    private InputField inptPassword;
    private InputField inptNombreApellidos;
    private GameObject pnlPerfil;
    public string nombreUsuario;
    void Awake()
    {
        pnlPerfil = GameObject.Find("pnlPerfil");
        inptUsuario = GameObject.Find("IfUserPerfil").GetComponent<InputField>();
        inptPassword= GameObject.Find("IfPasswordPerfil").GetComponent<InputField>();
        inptNombreApellidos = GameObject.Find("IfNombrePerfil").GetComponent<InputField>();
    }

    void Start()
    {
        pnlPerfil.SetActive(false);
    }
    public void AbrirPanel()
    {
        string NombreyApellidos ="";
        nombreUsuario = GameObject.Find("CtrlEntrada").GetComponent<ScrEntrada>().usuario;
        inptUsuario.text = nombreUsuario;
        foreach(Usuario u in ds.BuscarUsuario(nombreUsuario))
        {
            inptPassword.text = u.Password;
            NombreyApellidos += u.Nombre;
            NombreyApellidos += " " + u.Apellido1;
            NombreyApellidos += " " + u.Apellido2;


        }
        inptNombreApellidos.text = NombreyApellidos;
    }

    public void cerrarPerfil()
    {
        pnlPerfil.SetActive(false);
    }

    public void ManejoToggle()
    {
        if (inptPassword.contentType == InputField.ContentType.Password)
        {
            inptPassword.contentType = InputField.ContentType.Standard;
            pnlPerfil.SetActive(false);
            pnlPerfil.SetActive(true);
            //inptPassword.interactable = (true);
            //inptPassword.Select();
            //EventSystem.current.SetSelectedGameObject(null);
            //inptPassword.interactable = (false);
        }
        else 
        {
            inptPassword.contentType = InputField.ContentType.Password;
            pnlPerfil.SetActive(false);
            pnlPerfil.SetActive(true);
            //inptPassword.interactable = (true);
            //inptPassword.Select();
            //EventSystem.current.SetSelectedGameObject(null);
            //inptPassword.interactable = (false);
        }
    }
}
