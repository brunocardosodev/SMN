using System.Collections.Generic;

namespace Business.Models
{
    public class RankingViewModel : BaseModel
    {
        public RankingViewModel()
        {
            this.Ranking = new List<RankingModel>();
        }
        public RankingViewModel(string excessao)
        {
            this.deErro = excessao;
        }

        public List<RankingModel> Ranking { get; set; }
    }
}
