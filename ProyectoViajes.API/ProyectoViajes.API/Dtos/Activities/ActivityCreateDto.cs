﻿using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Dtos.Activities
{
    public class ActivityCreateDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(100, ErrorMessage = "El {0} debe tener menos de {1} caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(500, ErrorMessage = "La {0} debe tener menos de {1} caracteres.")]
        public string Description { get; set; }

        [Display(Name = "Paquete de Viaje")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public Guid TravelPackageId { get; set; }
    }
}
