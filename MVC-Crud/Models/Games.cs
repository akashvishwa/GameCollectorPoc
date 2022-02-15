using System.ComponentModel.DataAnnotations;

namespace MVC_Crud.Models
{
    public class Games
    {
        [Key]
        [Display(Name ="Game id")]
        public int Id { get; set; } 


        [Required(ErrorMessage ="Enter the Name of the Games"),]
        [RegularExpression(@"^[a-zA-Z0-9_]*$",ErrorMessage ="Please Eneter a Valid Name")]
        public string NameOfGame { get; set; }

        [Required(ErrorMessage ="Enter the Number of Levels")]
        public int NoOfLevel { get; set; }

        [Required(ErrorMessage="Enter The Publisher Name"),MaxLength(50)]
        public string Publisher { get; set; }     

        [Range(1,10,ErrorMessage ="values must be between 1 to 10")]
        public int Popularity { get; set; }


        



    }
}
