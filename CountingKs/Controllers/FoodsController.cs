using CountingKs.Data;
using CountingKs.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CountingKs.Controllers
{
    public class FoodsController : BaseApiController
    {
  
        public FoodsController(ICountingKsRepository repo) : base(repo)
        {
        }
        public IEnumerable<FoodModel> Get()
        {
            //var repo = new CountingKsRepository(new CountingKsContext());

            var results = TheRepository.GetAllFoodsWithMeasures()
                              .OrderBy(f => f.Description)
                              .Take(5)
                              .ToList()
                              .Select(f => TheModelFactory.Create(f));
            return results;
        }

        public FoodModel Get(int foodid)
        {
            return TheModelFactory.Create(TheRepository.GetFood(foodid));
        }

    }
}
