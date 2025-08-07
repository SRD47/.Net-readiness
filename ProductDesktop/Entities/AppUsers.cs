using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProductDesktop.Entities
{
    public enum Roles
    {
        Admin = 1,
        InventoryManager,
        OrderProcessor,
        Customer
    }
    public class AppUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        [Required]
        public string Name { get; set; }
       
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        public Roles Roles { get; set; }
    }
}
