﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class AeronaveTipoViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public bool Estado { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Codigo { get; set; }

    }
}
