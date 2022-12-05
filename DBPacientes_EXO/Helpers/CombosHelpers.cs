using DBPacientes_EXO.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace DBPacientes_EXO.Helpers
{

    public class CombosHelpers : ICombosHelper
    {
        //Propiedad de tipo lectura
        private readonly DataContext dataContext;
        public CombosHelpers(DataContext dataContext)
        {
            //no admite datos nulos, pasamos el dataContext
            this.dataContext = dataContext;

        }
        

        public IEnumerable<SelectListItem> GetComboGenders()
        {
            var list = this.dataContext.Genders.Select(p => new SelectListItem
            {
                //
                Text = p.PatientGender,
                Value = $"{p.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = ("Seleccione género"),
                Value = "0"
            });
            return list;
        }
    }
}
