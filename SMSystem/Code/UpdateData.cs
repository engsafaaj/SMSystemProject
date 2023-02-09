using SMSystem.Core;
using SMSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.Code
{
    public  class UpdateData
    {
        private IDataHelper<OutCome> _dataHelper;
        private IDataHelper<Income> _dataHelperForIncCome;
        private IDataHelper<Materails> _dataHelperforMaterail;
        private IDataHelper<Customers> _dataHelperforCustomer;
        private IDataHelper<OutComeMaterail> _dataHelperforOutComeMaterials;
        private IDataHelper<Damage> _dataHelperforDamage;
        private IDataHelper<ConscienceCard> _dataHelperforConscincesSelf;
        private IDataHelper<OutOfConscinesMaterials> _dataHelperforOutComConscince;
        private readonly IDataHelper<ConscienceCard> _dataHelperforConscinecCard;
        private List<int> MaterialId;
        private Income income;
        private Materails materails;

        public UpdateData()
        {
            _dataHelper = (IDataHelper<OutCome>)ContainerConfig.ObjectType("OutCome");
            _dataHelperForIncCome = (IDataHelper<Income>)ContainerConfig.ObjectType("Income");
            _dataHelperforMaterail = (IDataHelper<Materails>)ContainerConfig.ObjectType("Materails");
            _dataHelperforCustomer = (IDataHelper<Customers>)ContainerConfig.ObjectType("Customer");
            _dataHelperforOutComeMaterials = (IDataHelper<OutComeMaterail>)ContainerConfig.ObjectType("OutComeMaterail");
            _dataHelperforDamage = (IDataHelper<Damage>)ContainerConfig.ObjectType("Damage");
            _dataHelperforConscincesSelf = (IDataHelper<ConscienceCard>)ContainerConfig.ObjectType("ConscienceCard");
            _dataHelperforOutComConscince = (IDataHelper<OutOfConscinesMaterials>)ContainerConfig.ObjectType("OutOfConscinesMaterials");
            _dataHelperforConscinecCard = (IDataHelper<ConscienceCard>)ContainerConfig.ObjectType("ConscienceCard");
        }

        public void UpdateIncome()
        {
            MaterialId = _dataHelperforMaterail.GetData().Select(x => x.Id).ToList();
            for (int i = 0; i < MaterialId.Count; i++)
            {
                var id = MaterialId[i];
                materails = _dataHelperforMaterail.Find(id);
                
                // Get Data
                materails.InCome = _dataHelperForIncCome.GetData().Where(x=>x.MaterailId==id).Select(x => x.Quantity).ToArray().Sum();
                materails.OutCome = _dataHelperforOutComeMaterials.GetData().Where(x=>x.MaterialName==materails.Name).Select(x => x.Quantity).ToArray().Sum();
                materails.Damge=_dataHelperforDamage.GetData().Where(x => x.Name == materails.Name).Select(x => x.Quantity).ToArray().Sum();
                materails.OutConscience = _dataHelperforOutComConscince.GetData().Where(x => x.Name == materails.Name).Select(x => x.Quantity).ToArray().Sum();
                materails.ConscinceCard = _dataHelperforConscinecCard.GetData().Where(x => x.MaterialName == materails.Name).Select(x => x.Quantity).ToArray().Sum();
                // Edit
                _dataHelperforMaterail.Edit(materails);
            }
        }
    }
}
