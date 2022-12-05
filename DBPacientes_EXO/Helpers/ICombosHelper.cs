
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DBPacientes_EXO.Helpers
{
    //creacion de comobox
    public interface ICombosHelper
    {
        public IEnumerable<SelectListItem> GetComboGenders();
    }
}
