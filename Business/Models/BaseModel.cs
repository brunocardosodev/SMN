using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class BaseModel
    {
        public string deErro { get; set; }
        public bool icSucesso
        {
            get
            {
                return string.IsNullOrEmpty(deErro) ? true : false;
            }
            set { }
        }
    }
}
