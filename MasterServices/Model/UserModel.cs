using System.ComponentModel.DataAnnotations;

namespace MyProjectBE.Model
{
    public class UserModel
    {
        [Key]
        public long UserID{get;set;}
        public string Username {get;set;}
        public string Password {get;set;}
    }
}
