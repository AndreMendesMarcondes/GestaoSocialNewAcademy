using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GSNA.Domain.Domain
{
    public class InstagramDetails
    {
        [Key]
        public string Id { get; set; }
        public IDData Data { get; set; }
        public IDContas Contas { get; set; }
        public IDEngajamento Engajamento { get; set; }
        public IDSeuPublico SeuPublico { get; set; }
        public IDConteudoCompartilhado ConteudoCompartilhado { get; set; }

    }

    public class IDData
    {
        public DateTime DataCriacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }

    public class IDContasAlcancadas
    {
        public int Seguidores { get; set; }
        public int NaoSeguidores { get; set; }
    }

    public class IDContas
    {
        public IDContas()
        {
            ContasAlcancadas = new();
        }

        public IDContasAlcancadas ContasAlcancadas { get; set; }
        public int Impressoes { get; set; }
        public int VisitasNoPerfil { get; set; }
        public int ToquesNoSite { get; set; }
    }

    public class IDEngajamento
    {
        public int ContasComEngajamento { get; set; }
        public int InteracoesComConteudo { get; set; }
    }

    public class IDTotalSeguidores
    {
        public int Follows { get; set; }
        public int Unfollows { get; set; }
    }

    public class IDSeuPublico
    {
        public IDSeuPublico()
        {
            TotalSeguidores = new();
        }
        public IDTotalSeguidores TotalSeguidores { get; set; }
    }

    public class IDConteudoCompartilhado
    {
        public int QuantidadeDePosts { get; set; }
        public int QuantidadeDeStories { get; set; }
    }
}
