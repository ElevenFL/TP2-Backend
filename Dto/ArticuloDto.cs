namespace ArticulosAPI.Dto
{
    public class ArticuloDto
    {
        public ArticuloDto(string descripcion, string marca, int cantidad)
        {
            Descripcion = descripcion;
            Marca = marca;
            Cantidad = cantidad;
        }

        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public int Cantidad { get; set; }
    }
}
