using CountingKs.Data.Entities;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Routing;

namespace CountingKs.Models
{
    public class ModelFactory
    {
        private UrlHelper _urlHelper;

        public ModelFactory(HttpRequestMessage request)
        {
            _urlHelper = new UrlHelper(request);
        }
        public FoodModel Create(Food food)
        {
            return new FoodModel()
            {
                url = _urlHelper.Link("Food", new { foodid = food.Id }),
                Description = food.Description,
                Measures = food.Measures.Select(f => Create(f))
            };
        }

        public MeasureModel Create(Measure measure)
        {
            return new MeasureModel()
            {
                url = _urlHelper.Link("Measures", new { foodid = measure.Food.Id, id = measure.Id}),
                Description = measure.Description,
                Calories = measure.Calories
            };
        }

        public DiaryModel Create(Diary m)
        {
            return new DiaryModel()
            {
                Url = _urlHelper.Link("Dairies", new { dairyid = m.CurrentDate.ToString("yyyy/mm/dd ")}),
                CurrentDate = m.CurrentDate 
            };
        }
    }
}