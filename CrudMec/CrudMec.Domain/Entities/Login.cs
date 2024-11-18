using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMec.Domain.Entities
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; } = null;
        public string Password { get; set; } = null;
    }
}
