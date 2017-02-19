using CountingKs.Data;
using CountingKs.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CountingKs.Controllers
{
    public class FoodsController : ApiController
    {
        ModelFactory _ModelFactory;
        ICountingKsRepository _repo;

        public FoodsController(ICountingKsRepository repo)
        {
            _repo = repo;
            _ModelFactory = new ModelFactory();
        }
        public IEnumerable<FoodModel> Get()
        {
            //var repo = new CountingKsRepository(new CountingKsContext());

            var results = _repo.GetAllFoodsWithMeasures()
                              .OrderBy(f => f.Description)
                              .Take(5)
                              .ToList()
                              .Select(f => _ModelFactory.Create(f));
            return results;
        }

        public FoodModel Get(int foodid)
        {
            return _ModelFactory.Create(_repo.GetFood(foodid));
        }

    }
}
