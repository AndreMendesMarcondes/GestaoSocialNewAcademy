using GSNA.Domain.Domain;
using System.ComponentModel.DataAnnotations;

namespace GSNA.Domain.DTO
{
    public class InstagramDetailsDTO
    {
        public InstagramDetailsDTO()
        {
            DataCriacao = DateTime.Now;
        }

        public InstagramDetailsDTO(InstagramDetails instagramDetails)
        {
            ID = instagramDetails.Id;

            DataCriacao = instagramDetails.Data.DataCriacao;
            DataInicio = instagramDetails.Data.DataInicio;
            DataFim = instagramDetails.Data.DataFim;

            Seguidores = instagramDetails.Contas.ContasAlcancadas.Seguidores;
            NaoSeguidores = instagramDetails.Contas.ContasAlcancadas.NaoSeguidores;
            Impressoes = instagramDetails.Contas.Impressoes;
            VisitasNoPerfil = instagramDetails.Contas.VisitasNoPerfil;
            ToquesNoSite = instagramDetails.Contas.ToquesNoSite;

            ContasComEngajamento = instagramDetails.Engajamento.ContasComEngajamento;
            InteracoesComConteudo = instagramDetails.Engajamento.InteracoesComConteudo;

            Follows = instagramDetails.SeuPublico.TotalSeguidores.Follows;
            Unfollows = instagramDetails.SeuPublico.TotalSeguidores.Unfollows;

            QuantidadeDePosts = instagramDetails.ConteudoCompartilhado.QuantidadeDePosts;
            QuantidadeDeStories = instagramDetails.ConteudoCompartilhado.QuantidadeDeStories;
        }
        public string ID { get; set; }
        public DateTime DataCriacao { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }
        public int Seguidores { get; set; }
        public int NaoSeguidores { get; set; }
        public int Impressoes { get; set; }
        public int VisitasNoPerfil { get; set; }
        public int ToquesNoSite { get; set; }
        public int ContasComEngajamento { get; set; }
        public int InteracoesComConteudo { get; set; }
        public int Follows { get; set; }
        public int Unfollows { get; set; }
        public int QuantidadeDePosts { get; set; }
        public int QuantidadeDeStories { get; set; }
    }
}
