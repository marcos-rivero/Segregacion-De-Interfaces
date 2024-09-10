using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov
{
    public class Articulo
    {
        private readonly ILogging _logging;
        private readonly Cache _cache;
        private readonly IAlmacenamiento _almacenamiento;
        private readonly IArchivo _archivo;
        const string path = "c:/temp";
        public Articulo(IArchivo archivo)
        {
            _logging = new DatabaseLog();
            _cache = new Cache();
            _almacenamiento = new AlmacenamientoSQL();
            _archivo = archivo;
        }
        public void GuardarArticulo(string contenido, string titulo)
        {
            _logging.Info($"vamos a insertar el articulo {titulo}");
            _almacenamiento.Guardar($"{path}/{titulo}.txt", contenido);
            _logging.Info($"articulo {titulo} insertado");
            _cache.Add(titulo, contenido);
        }

        public string ConsultarArticulo(string titulo)
        {
            _logging.Info($"Consultar artículo {titulo}");

            try
            {
                string contenido = _cache.Get(titulo);
                if (!string.IsNullOrWhiteSpace(contenido))
                {
                    _logging.Info($"Artículo encontrado en la cache {titulo}");
                    return contenido;
                }

            }
            catch(Exception e)
            {
                _logging.Fatal($"buscar articulo en el sistema de archivos {titulo}", e);
            }
            if (!InformacionArchivo(titulo).Exists)
            {
                return null;
            }
            return _almacenamiento.Leer($"{path}/{titulo}.txt");
        }
        private FileInfo InformacionArchivo(string titulo)
        {
            return _archivo.GetInformacion(titulo);
        }
    }
}
