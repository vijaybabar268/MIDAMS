using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIDAMS.Models
{
    [Table("tbl_map_clients_to_partner")]
    public class MapClientsToPartner
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("partner_id")]
        public int PartnerId { get; set; }

        [Column("client_id")]
        public int ClientId { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_on")]
        public DateTime CreatedOn { get; set; }
    }    
}