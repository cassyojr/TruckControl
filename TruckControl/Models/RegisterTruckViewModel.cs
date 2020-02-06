using System;
using System.ComponentModel.DataAnnotations;
using TruckControl.Attributes;

namespace TruckControl.Models
{
    public class RegisterTruckViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Informe um nome para o caminhão")]
        [Display(Name = "Nome")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Tamanho deve ser maior que 3 e menor que 200 caracteres")]
        public string TruckName { get; set; }

        [Required(ErrorMessage = "Informe o ano do modelo do caminhão")]
        [Display(Name = "Ano do modelo")]
        [ModelYearRange]
        public int? ModelYear { get; set; }

        [Required(ErrorMessage = "Informe o modelo do caminhão")]
        [Display(Name = "Modelo")]
        public int? TruckModelId { get; set; }
    }
}
