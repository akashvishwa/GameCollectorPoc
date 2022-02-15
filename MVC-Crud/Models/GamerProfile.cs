﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Crud.Models
{
    public class GamerProfile
    {
        [Key]
        public int ProfileId { get; set; }

        
        public string RealName { get; set; }


        [Required]
        public string GamerName { get; set; }


        public string Gender { get; set; }

        [Required]
        public string GamingDevice { get; set; }

        [Required]
        public bool IsEsportPlayer { get; set; } 

        [Required]
        public string Email { get; set; } 


        
        public string GamingPlatformId { get; set; } 




        


    }
}
