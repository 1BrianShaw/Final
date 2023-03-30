using System.Collections.Generic;
using Testing.Models;

namespace Testing
{
    public interface ITerminologyRepository
    {
        public IEnumerable<Terminology> GetAllTerminologies();
        public Terminology GetTerminology(int ID);
        public void UpdateTerminology(Terminology Terminology);
        public IEnumerable<Terminology> GetAllOfCategory(string category);
        public void InsertTerminology(Terminology terminologyToInsert);
        public IEnumerable<Categories> GetCategories();
        public Terminology AssignCategory();
        public void DeleteTerminology(Terminology terminology);

    }
}
