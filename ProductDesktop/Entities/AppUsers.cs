using CommunityToolkit.Mvvm.ComponentModel;
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
    public partial class AppUsers : ObservableObject
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

        private Roles newRole;
        [NotMapped]
        public Roles NewRole
        {
            get => newRole;
            set => SetProperty(ref newRole, value);
        }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

