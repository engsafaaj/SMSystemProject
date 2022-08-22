using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMSystem.Core;
using SMSystem.Data;

namespace SMSystem.Web.Pages.Store
{
    public class ListModel : PageModel
    {
        private readonly IDataHelper<Stores> dataHelper;
        public string Title;
        public List<Stores> ListStores;
        public ListModel(IDataHelper<Stores> dataHelper)
        {
            this.dataHelper = dataHelper;
        }
        public void OnGet()
        {
            ListStores = new List<Stores>();
            ListStores = dataHelper.GetData();
        }

    }
}
