﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WashingCarDB.Models
{
    public class AddVehicleViewModel
    {


        [Display(Name = "Servicio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public IEnumerable<SelectListItem> Services { get; set; }
        [Display(Name = "Numero de placa")]
        public string NumberPlate { get; set; }



        /*
         [Display(Name = "Servicio")]
         [Required(ErrorMessage = "El campo {0} es obligatorio.")]
         public Guid ServiceID { get; set; }

         public IEnumerable<SelectListItem> Services { get; set; }

         [Display(Name = "Propietario")]
         public User User { get; set; }

         [Display(Name = "Numero de placa")]
         public string NumberPlate { get; set; }
        */
    }
}
