using Dapper;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Data;
using Testing.Models;

namespace Testing
{
    public class TerminologyRepository : ITerminologyRepository
    {
        private readonly IDbConnection _conn;

        public TerminologyRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Terminology> GetAllTerminologies()
        {
            return _conn.Query<Terminology>("SELECT * FROM Terminology;");
        }
        public Terminology GetTerminology (int id)
        {
            return _conn.QuerySingle<Terminology>("SELECT * FROM Terminology WHERE ID = @id",
                new { id = id });
        }
        public IEnumerable<Terminology> GetAllOfCategory(string category)
        {
            return _conn.Query<Terminology>("SELECT * FROM Terminology WHERE Category = @category",
                new { category = category });
        }

        public void UpdateTerminology(Terminology Terminology)
        {
            _conn.Execute("UPDATE terminology SET Term = @term, Definition = @definition, Category = @category WHERE ID = @id",
                new { term = Terminology.Term, definition = Terminology.Definition, category = Terminology.Category, id = Terminology.ID });
        }

        public void InsertTerminology(Terminology termToInsert)
        {
            _conn.Execute("INSERT INTO terminology (term, definition, category, categoryID) VALUES (@terminology, @definition, @category, @categoryID);",
                new { terminology = termToInsert.Term, definition = termToInsert.Definition, category = termToInsert.Category, categoryID = termToInsert.CategoryID });
        }

        public IEnumerable<Categories> GetCategories()
        {
            return _conn.Query<Categories>("SELECT * FROM categories;");
        }

        public Terminology AssignCategory()
        {
            var categoryList = GetCategories();
            var terminology = new Terminology();
            terminology.Categories = categoryList;
            return terminology;
        }

        public void DeleteTerminology(Terminology terminology)
        {
            _conn.Execute("DELETE FROM Terminology WHERE ID = @id;", new { id = terminology.ID });
        }

    }
}
