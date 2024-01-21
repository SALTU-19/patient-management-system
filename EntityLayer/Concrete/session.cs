using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UId { get; set; }
        public string IPAddress { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public bool Status { get; set; }
        public string UserId { get; set; }
    }
}
