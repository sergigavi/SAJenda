using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Fecha de creacion: 4 de Noviembre de 2021.
 * Author: Alex Fernandez Haro.
 * Descripcion: Script para el manejo del registro de los usuarios en la base de datos
 * Villablanca.
 */

public class ScrRegistro : MonoBehaviour
{
    //Base de datos
	private DataService ds = new DataService("BBDD_Usuarios.db");
    
    //Booleano para confirmar el registro
    private bool salir;
    //Panel principal
    private GameObject pnlRegistro;

    //Panel alerta
    private GameObject pnlRegistroAlerta;

    //InputFields
    private InputField ifNombreUsuario;
    private InputField ifNombre;
    private InputField ifApellido1;
    private InputField ifApellido2;
    private InputField ifPassword1;
    private InputField ifPassword2;
    //Texto alerta
    private GameObject txtMsgRegistro;
    private Text txtAlerta;

    //Inicializacion de parametos
    private void Awake() 
    {
        //Panel principa registro
        pnlRegistro = GameObject.Find("PnlRegistro");
        //Panel alerta 
        pnlRegistroAlerta = GameObject.Find("PnlRegistroAlerta");
        //InputFields
        ifNombreUsuario = GameObject.Find("IfRegistroNombreUsuario").GetComponent<InputField>();
        ifNombre = GameObject.Find("IfRegistroNombre").GetComponent<InputField>();
        ifApellido1 = GameObject.Find("IfRegistroAp1").GetComponent<InputField>();
        ifApellido2 = GameObject.Find("IfRegistroAp2").GetComponent<InputField>();
        ifPassword1 = GameObject.Find("IfRegistroPassword1").GetComponent<InputField>();
        ifPassword2 = GameObject.Find("IfRegistroPassword2").GetComponent<InputField>();
        //Texto alerta
        txtAlerta = GameObject.Find("TxtRegistroAlerta").GetComponent<Text>();
        txtMsgRegistro = GameObject.Find("TxtMsgRegistro");
        pnlRegistroAlerta.SetActive(false);
    }
    
    
    /**
     * Funcion que se asigna en el OnClick del boton confirmar del pnl registro.
     * 
     * Esta funcion se encarga de ver si los datos introducidos son correctos.
     */
    public void CheckData() 
    {
        salir = false;
        string mensaje = "";
        if (
            ifNombreUsuario.text == "" ||
            ifNombre.text == "" ||
            ifApellido1.text == "" ||
            ifApellido2.text == "" ||
            ifPassword1.text == "" ||
            ifPassword2.text == ""
        )
        {
            mensaje = "Hay campos vacios, rellenalos antes de continuar";
            ifPassword1.text = "";
            ifPassword2.text = "";
            txtAlerta.color = Color.red;
        }
        else
        {
            if (ifPassword1.text == ifPassword2.text)
            {
                mensaje = ComprobarBBDD();
            }
            else
            {
                mensaje = "Las contrasenas no coinciden";
                ifPassword1.text = "";
                ifPassword2.text = "";
                txtAlerta.color = Color.red;
            }
        }
        txtMsgRegistro.GetComponent<Text>().text = mensaje;
        pnlRegistroAlerta.SetActive(true);
    }

    /**
     * Funcion para el boton asignado al OnClick logo. 
     * 
     * Esta funcion cierra el panel del registro.
     */
    public void BotonLogo() 
    {
        pnlRegistro.SetActive(false);
        Reiniciar();
    }

    /**
     * Funcion para el OnClick del boton de aceptar del panel de alerta del panel de registro.
     * En caso de que que los datos sean correctos, el usuario se guarda en la base de datos, en
     * caso contrario, simplemente cerrara el panel de alerta
     */
    public void BotonAceptarAlerta()
    {
        if(salir)
        {
            pnlRegistroAlerta.SetActive(false);
            pnlRegistro.SetActive(false);
            salir = false;
            RegistrarEnBBDD();
            Reiniciar();
        }
        else
        {
            pnlRegistroAlerta.SetActive(false);
        }
    }
    private void Reiniciar()
    {
        ifNombreUsuario.text = "";
        ifNombre.text = "";
        ifApellido1.text = "";
        ifApellido2.text = "";
        ifPassword1.text = "";
        ifPassword2.text = "";
    }

    public void RegistrarEnBBDD()
    {
        Usuario user = new Usuario(ifNombreUsuario.text, ifNombre.text, ifApellido1.text, ifApellido2.text, ifPassword2.text, "", "");
        ds.CrearUsuario(user);
    }

    
    

    //////////////////////////////////////////////////
    /////////// Manejo de la base de datos ///////////
    //////////////////////////////////////////////////   

    public string ComprobarBBDD()
    {
		string mensaje;
		var usuarios = ds.BuscarCoincidencia(ifNombreUsuario.text , ifPassword2.text);

		if (ds.Existe(ifNombreUsuario.text) == 0)
        {
			salir = true;
            mensaje = "Registro completado correctamente";
            txtAlerta.color = Color.green;
        }
        else
        {
			mensaje = "Ya hay un usuario con este nombre de usuario.";
            ifNombreUsuario.text = "";
            txtAlerta.color = Color.red;
        }
         
        return mensaje;
	} 
}
