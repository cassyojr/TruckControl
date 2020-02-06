using System;
using System.ComponentModel.DataAnnotations;

namespace TruckControl.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ModelYearRangeAttribute : RangeAttribute
    {
        public ModelYearRangeAttribute() : base(DateTime.Now.Year, DateTime.Now.Year + 1)
        {
            ErrorMessage = $"Ano do modelo deve ser entre {DateTime.Now.Year} e {DateTime.Now.Year + 1}";
        }
    }
}
