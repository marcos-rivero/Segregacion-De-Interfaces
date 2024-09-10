namespace Liskov
{
    public interface IAlmacenamiento
    {
        void Guardar(string titulo, string contenido);
        string Leer(string titulo);
        FileInfo InformacionArchivo(string titulo);


    }
    public class Almacenamiento : IAlmacenamiento
    {
        string path = "C:/temp";
        public void Guardar(string titulo, string contenido)
        {
            File.WriteAllText($"{path}/{titulo}.txt", contenido);
        }

        public string Leer(string titulo)
        {
            if (!InformacionArchivo(titulo).Exists)
            {
                return null;
            }
            return File.ReadAllText($"{path}/{titulo}.txt");
        }

        public FileInfo InformacionArchivo(string titulo){
            return new FileInfo($"{path}/{titulo}.txt");
        }
    }
}
