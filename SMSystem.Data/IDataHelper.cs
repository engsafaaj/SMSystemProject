using System.Collections.Generic;
namespace SMSystem.Data
{
    public interface IDataHelper<Table>
    {
        List<Table> GetData();
        List<Table> Search(string SearchItem);
        bool IsDbConnect();
        Table Find(int id);
        int Add(Table table);
        int Edit(Table table);
        int Delete(int Id);
    }
}
