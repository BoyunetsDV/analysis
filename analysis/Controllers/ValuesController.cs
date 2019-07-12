using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using analysis.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace textAnalysis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        public JObject Post(TextAnalysis text)
        {
            return new JObject { ["message"] = text.Calculate() };
        }
    }
}
