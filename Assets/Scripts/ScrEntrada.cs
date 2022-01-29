using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrEntrada : MonoBehaviour
{
    //Base de datos
	private DataService ds = new DataService("BBDD_Usuarios.db");
    
    private GameObject pnlInicial;
    private InputField ifUser;
    private InputField ifPassword;
    private GameObject pnlInicioAlerta;
    private GameObject pnlRegistro;

    //Nombre de usuario del usuario registrado
    public string usuario;

    
    
    void Awake()
    {
        pnlInicial = GameObject.Find("PnlInicial");
        ifUser = GameObject.Find("IfUser").GetComponent<InputField>();
        ifPassword = GameObject.Find("IfPassword").GetComponent<InputField>();
        pnlInicioAlerta = GameObject.Find("PnlInicioAlerta");
        pnlInicioAlerta.SetActive(false);
        pnlRegistro = GameObject.Find("PnlRegistro");
    }

    void Start()
    {
        pnlRegistro.SetActive(false);
    }

    public void Entrar()
    {
        int usu = ds.NumeroCoincidencias(ifUser.text, ifPassword.text);

        if (usu == 1)
        {
            pnlInicial.SetActive(false);
            usuario = ifUser.text;
        }
        else
        {
            pnlInicioAlerta.SetActive(true);
            
        }
        ReiniciarPaneles();
    }

    public void AbrirRegistro()
    {
        pnlRegistro.SetActive(true);
        ReiniciarPaneles();
    }

    public void CerrarAlerta()
    {
        pnlInicioAlerta.SetActive(false);
        ReiniciarPaneles();
    }


    private void ReiniciarPaneles()
    {
        ifUser.text = "";
        ifPassword.text = "";
    } 




}
