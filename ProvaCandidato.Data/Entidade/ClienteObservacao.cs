using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaCandidato.Data.Entidade
{
    [Table("ClienteObservacao")]
    public class ClienteObservacao
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }

        public Cliente ClienteId { get; set; }

        [StringLength(100)]
        [Column("observacao")]
        public string Observacao { get; set; }
    }
}