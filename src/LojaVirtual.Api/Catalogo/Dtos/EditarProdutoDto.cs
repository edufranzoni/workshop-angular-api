namespace LojaVirtual.Catalogo.Dtos
{
    public class EditarProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
        public bool Ativo { get; set; }
    }
}
