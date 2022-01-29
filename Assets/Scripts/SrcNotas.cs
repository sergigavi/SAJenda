using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SrcNotas : MonoBehaviour
{
	private DataService ds = new DataService("BBDD_Usuarios.db");
    private GameObject pnlNotas;
    private InputField ifNombreNota;
    private InputField ifContenido;

    private string nombreUsuario;

    private Text listado;
    void Awake()
    {
        pnlNotas = GameObject.Find("PnlNotas");
        ifNombreNota = GameObject.Find("IfNombreNota").GetComponent<InputField>();
        ifContenido = GameObject.Find("IfContenidoNota").GetComponent<InputField>();
    }

    private void Start()
    {
        pnlNotas.SetActive(false);
    }

    public void CerrarPanel(){
        pnlNotas.SetActive(false);
        EscribirDatos();
    }
    public void EscribirDatos() {
        ds.EditarNota(nombreUsuario, ifNombreNota.text, ifContenido.text);
    }

    public void CargarDatos(){

        nombreUsuario = GameObject.Find("CtrlEntrada").GetComponent<ScrEntrada>().usuario;
        ifNombreNota.text = ds.ObtenerNombreNota(nombreUsuario);
        ifContenido.text = ds.ObtenerContenido(nombreUsuario);
    }

}
