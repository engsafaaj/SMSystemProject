using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.StoresGui;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMSystem.Code
{
    public class DependencyInjection
    {

        // Construcotores
        public DependencyInjection()
        {
            // Inject the objets
            ContainerConfig.Register("Store", new StoreEntity());
        }
    }
}
