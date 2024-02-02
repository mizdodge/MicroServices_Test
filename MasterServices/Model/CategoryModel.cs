using System.ComponentModel.DataAnnotations;

namespace MyProjectBE.Model
{
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
