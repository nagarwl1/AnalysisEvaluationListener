using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AnalysisEvaluationListener
{
    public class LogMessageController : ApiController
    {
        private static readonly JsonSerializerSettings DefaultSerializerSettings = new JsonSerializerSettings()
        {
            Converters =
            {
                new AFTimeConverter(),
            }
        };

        public class LogMessage
        {
            public string Level { get; set; }
            public string Message { get; set; }
        }

        public void Post([FromBody] LogMessage message)
        {
            if (TryParseData(message, out AnalysisEvaluationData analysisData))
            {
                var summary = analysisData.EvaluationData;
                Console.WriteLine($"Analysis:{analysisData.AnalysisName} | TriggerTime:{summary.ExeTime} | Elapsed:{summary.ElapsedMilliSeconds}ms | Lag:{summary.LagMilliSeconds}");
            }
        }

        private bool TryParseData(LogMessage message, out AnalysisEvaluationData evaluationData)
        {
            evaluationData = null;
            if (message.Level == "Trace" && message.Message.Contains("Type: AnalysisEvaluated"))
            {
                // The traced messaged is not well formed JSON, so required some handling
                var data = message.Message.Replace("Type: AnalysisEvaluated, Data: ", "").Trim();
                evaluationData = JsonConvert.DeserializeObject<AnalysisEvaluationData>(data, DefaultSerializerSettings);
            }

            return evaluationData != null;
        }
    }

}
