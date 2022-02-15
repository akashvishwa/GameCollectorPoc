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
        public virtual Games Games { get; set;}

        public virtual GamerProfile GamerProfile { get; set; }






    }
}
