namespace Deccagram.DTOs
{
    public class UsuarioRespostaDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        //Acrescentado Depois
        public string Avatar { get; set; }
        public int IdUsuario { get; set; }
        //Adicionado Depois (Criação das Quantidades de Usuários Seguindo e Seguidores - Pesquisa por Is Usuário)
        public int QtdSeguindo { get; set; }
        public int QtdSeguidores { get; set; }
        public int QtdPublicacoes { get; set; }
    }
}
