using SMSystem.Data;

namespace SMSystem.Code
{
    public class DependencyInjection
    {

        // Construcotores
        public DependencyInjection()
        {
            // Inject the objets
            ContainerConfig.Register("Store", new StoreEntity());
            ContainerConfig.Register("Materails", new MaterailsEntity());
            ContainerConfig.Register("Customer", new CustomersEntity());
            ContainerConfig.Register("Supplier", new SuppliersEntity());
            ContainerConfig.Register("Income", new IncomeEntity());
            ContainerConfig.Register("OutCome", new OutComeEntity());
            ContainerConfig.Register("OutComeMaterail", new OutComeMaterailMaterialsEntity());
            ContainerConfig.Register("Damage", new DamageEntity());
            ContainerConfig.Register("User", new UserEntity());
            ContainerConfig.Register("ConscienceCard", new ConscienceCardEntity());
            ContainerConfig.Register("OutOfConscinesMaterials", new OutOfConsinceMaterialEntity());
        }
    }
}
