/////////////////////////////////////////////////////////////////
///Ciclo: Desarrollo de Aplicaciones Multiplataforma.
///Módulo: Desarrollo de Interfaces.
///Profesores: Raquel Rojo y Mario Santos.
///En este script se declara el nombre de la carpeta en la que tenemos
///las bbdd, en la variable dbPath. Se realizan consultas, se generan BBDD,
///se insertan registros, etc.
////////////////////////////////////////////////////////////////

using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService  {

	private SQLiteConnection _connection;

	public DataService(string DatabaseName){

		//Importante la varialbe dbPath. Fijaros que le damos la ruta a la carpeta en la que
		//guardamos la bbdd, en este caso 'StreamingAssets'. Si se cambia este nombre, recordar cambiar el nombre
		//en el proyecto.

		#if UNITY_EDITOR
				var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
				
		#else
				// check if file exists in Application.persistentDataPath
				var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

				if (!File.Exists(filepath))
				{
					Debug.Log("Database not in Persistent path");
					// if it doesn't ->
					// open StreamingAssets directory and load the db ->

		#if UNITY_ANDROID 
					var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
					while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
					// then save to Application.persistentDataPath
					File.WriteAllBytes(filepath, loadDb.bytes);
		#elif UNITY_IOS
						var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
						// then save to Application.persistentDataPath
						File.Copy(loadDb, filepath);
		#elif UNITY_WP8
						var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
						// then save to Application.persistentDataPath
						File.Copy(loadDb, filepath);

		#elif UNITY_WINRT
				var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
				// then save to Application.persistentDataPath
				File.Copy(loadDb, filepath);
				
		#elif UNITY_STANDALONE_OSX
				var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
				// then save to Application.persistentDataPath
				File.Copy(loadDb, filepath);
		#else
			var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
			// then save to Application.persistentDataPath
			File.Copy(loadDb, filepath);

		#endif

					Debug.Log("Database written");
				}

				var dbPath = filepath;
		#endif
				//En esta línea, hacemos la conexión con la bbdd que hemos cargado en nuestro proyecto.
				//La abrimos en modo ReadWrite.

				_connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
				

	}

	//Este método nos devuelve todos los registros de nuestra bbdd. Fijaros que nos
	//devuelve un campo IEnumerable de tipo Autenticación. Debemos crear una clase, con set y get
	//para poder guardar todos los datos de los campos. En este ejemplo, tenemos creada la clase autenticación.cs
	public IEnumerable<Usuario> GetPersons()
    {
		return _connection.Table<Usuario>();
	}

	//En este método, hacemos una consulta con Where, hacemos una busqueda sobre un campo. En este ejemplo buscamos
	//el registro con un nombre y un password que le pasamos como parámetro de entrada.
	//Esto cambiará, según el proyecto.

	public IEnumerable<Usuario> BuscarCoincidencia(string name, string pass){
		return _connection.Table<Usuario>().Where(x => x.NombreUsuario == name && x.Password == pass);
	}

	//En este método, buscamos el número de coincidencias de una consulta. En este proyecto, lo hemos utilizado para
	//para comprobar que un usuario existe o no.
	public int NumeroCoincidencias(string name, string pass)
	{
		return _connection.Table<Usuario>().Count(x => x.NombreUsuario == name && x.Password == pass);
	}

	public int Existe(string name)
	{
		return _connection.Table<Usuario>().Count(x => x.NombreUsuario == name);
	}

	//En este método, creamos un registro nuevo en nuestra BBDD. Como veréis les pasamos como parámetros de entrada
	//los campos de la tabla, en este caso el nombre y el password. Por último se aplica la orden insert.
	public Usuario CrearUsuario(Usuario u){
		_connection.Insert (u);
		return u;
	}

	public IEnumerable<Usuario> BuscarUsuario(string name){
		return _connection.Table<Usuario>().Where(x => x.NombreUsuario == name);
	}

	public void EditarNota(string NombreUsuario, string NombreNota, string Contenido) {
		var reg = _connection.Table<Usuario>().Where(x => x.NombreUsuario == NombreUsuario);
		foreach (var r in reg)
		{
			r.NombreNota = NombreNota;
			r.Contenido = Contenido;
			_connection.Update(r);
		}
	}

	public string ObtenerNombreNota(string NombreUsuario) {
		var reg = _connection.Table<Usuario>().Where(x => x.NombreUsuario == NombreUsuario);
		foreach (var r in reg)
		{
			return r.NombreNota;
		}
		return "";
	}

	public string ObtenerContenido(string NombreUsuario) {
		var reg = _connection.Table<Usuario>().Where(x => x.NombreUsuario == NombreUsuario);
		foreach (var r in reg)
		{
			return r.Contenido;
		}
		return "";
	}

}
