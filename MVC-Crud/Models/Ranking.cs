using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Crud.Models
{
    public class Ranking
    {
        

        

        /*just for creating a table */
        [Key]
        public int RankId { get; set; }


        [Required]
        public string Rank { get; set; }

        
        /*creating foreign key*/
        [ForeignKey("Games")]
        public int Id { get; set; }
        public Games Games { get; set;}


        [ForeignKey("GamerProfile")]
        public int ProfileId { get; set; }
        public GamerProfile GamerProfile { get; set; }






    }
}
