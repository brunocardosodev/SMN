using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
