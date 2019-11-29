namespace LojaVirtual.Catalogo.Dtos
{
    public class CriarProdutoDto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
        public bool Ativo { get; set; }
    }
}
