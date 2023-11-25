﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WashingCarDB.DAL.Entities
{
    public class Service : Entity   
    {

        #region Properties
        [Display(Name = "Servicio.")]
        [MaxLength(50)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Price { get; set; }

        [Display(Name = "Vehiculos")]
        public Guid VehicleId { get; set; }

        public List<Vehicle> Vehicles { get; set; }
        public DateTime CreatedDate { get; internal set; }
        // public ICollection<Vehicle> Vehicles { get; set; }

        #endregion
    }
}
