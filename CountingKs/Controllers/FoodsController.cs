using CountingKs.Data;
using CountingKs.Data.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CountingKs.Controllers
{
    public class FoodsController : ApiController
    {
        ICountingKsRepository _repo;

        public FoodsController(ICountingKsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<object> Get()
        {
            //var repo = new CountingKsRepository(new CountingKsContext());

            var results = _repo.GetAllFoodsWithMeasures()
                              .OrderBy(f => f.Description)
                              .Take(5)
                              .ToList()
                              .Select(f => new
                              {
                                  Description = f.Description,
                                  Measures = f.Measures.Select(m =>
                                  new
                                  {
                                      Description = m.Description,
                                      Calories = m.Calories
                                  })
                              });
            return results;
        }

    }
}
