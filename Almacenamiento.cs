namespace Liskov
{
    public interface IArchivo
    {
        FileInfo GetInformacion(string nombre);
    }
    public interface IAlmacenamiento
    {
        void Guardar(string titulo, string contenido);
        string Leer(string titulo);

    }

    public class Archivo : IArchivo
    {
        public FileInfo GetInformacion(string nombre)
        {
            return new FileInfo(nombre);
        }
    }
    public class Almacenamiento : IAlmacenamiento
    {
        string path = "C:/temp";
        private readonly IArchivo _archivo;
        public Almacenamiento(IArchivo archivo)
        {
            _archivo = archivo;
        }
    
        public void Guardar(string titulo, string contenido)
        {
            File.WriteAllText($"{path}/{titulo}.txt", contenido);
        }

        public string Leer(string titulo)
        {
            if (!_archivo.GetInformacion(titulo).Exists)
            {
                return null;
            }
            return File.ReadAllText($"{path}/{titulo}.txt");

        }

    }
}
