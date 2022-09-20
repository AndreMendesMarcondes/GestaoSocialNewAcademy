using GSNA.Domain.DTO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GSNA.Domain.Domain
{
    [BsonIgnoreExtraElements]
    public class InstagramDetails
    {
        public InstagramDetails(InstagramDetailsDTO dto)
        {
            Data = new();
            Data.DataCriacao = dto.DataCriacao;
            Data.DataInicio = dto.DataInicio;
            Data.DataFim = dto.DataFim;

            Contas = new();
            Contas.ContasAlcancadas.Seguidores = dto.Seguidores;
            Contas.ContasAlcancadas.NaoSeguidores = dto.NaoSeguidores;
            Contas.Impressoes = dto.Impressoes;
            Contas.VisitasNoPerfil = dto.VisitasNoPerfil;
            Contas.ToquesNoSite = dto.ToquesNoSite;

            Engajamento = new();
            Engajamento.ContasComEngajamento = dto.ContasComEngajamento;
            Engajamento.InteracoesComConteudo = dto.InteracoesComConteudo;

            SeuPublico = new();
            SeuPublico.TotalSeguidores.Follows = dto.Follows;
            SeuPublico.TotalSeguidores.Unfollows = dto.Unfollows;

            ConteudoCompartilhado = new();
            ConteudoCompartilhado.QuantidadeDePosts = dto.QuantidadeDePosts;
            ConteudoCompartilhado.QuantidadeDeStories = dto.QuantidadeDeStories;
        }


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public IDData Data { get; set; }
        public IDContas Contas { get; set; }
        public IDEngajamento Engajamento { get; set; }
        public IDSeuPublico SeuPublico { get; set; }
        public IDConteudoCompartilhado ConteudoCompartilhado { get; set; }

    }

    [BsonIgnoreExtraElements]
    public class IDData
    {
        public DateTime DataCriacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class IDContasAlcancadas
    {
        public int Seguidores { get; set; }
        public int NaoSeguidores { get; set; }
    }

    [BsonIgnoreExtraElements]
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

    [BsonIgnoreExtraElements]
    public class IDEngajamento
    {
        public int ContasComEngajamento { get; set; }
        public int InteracoesComConteudo { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class IDTotalSeguidores
    {
        public int Follows { get; set; }
        public int Unfollows { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class IDSeuPublico
    {
        public IDSeuPublico()
        {
            TotalSeguidores = new();
        }
        public IDTotalSeguidores TotalSeguidores { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class IDConteudoCompartilhado
    {
        public int QuantidadeDePosts { get; set; }
        public int QuantidadeDeStories { get; set; }
    }
}
