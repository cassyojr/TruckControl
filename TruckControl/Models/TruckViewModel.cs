using System;
using System.ComponentModel.DataAnnotations;

namespace TruckControl.Models
{
    public class TruckViewModel
    {
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string TruckName { get; set; }
        [Display(Name = "Modelo")]
        public string TruckModelName { get; set; }
        [Display(Name = "Ano de produção")]
        public int ProductionYear { get; set; }
        [Display(Name = "Ano do modelo")]
        public int ModelYear { get; set; }
        [Display(Name = "Data de criação")]
        public DateTime CreationDate { get; set; }
    }
}
