using OSIsoft.AF.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisEvaluationListener
{
    public class AnalysisEvaluationData
    {
        /// <summary>
        /// AF Analysis path.
        /// </summary>
        public string AnalysisName { get; set; }

        /// <summary>
        /// AFAnalysis Id.
        /// </summary>
        public Guid AnalysisId { get; set; }

        /// <summary>
        /// Typically AFAnalysisTemplate.Id (unless analysis does not derive from a template)
        /// </summary>
        public Guid GroupId { get; set; }

        /// <summary>
        /// Can be safely ignored.
        /// </summary>
        public Guid TimeclassId { get; set; }

        /// <summary>
        /// Evaluation summary.
        /// </summary>
        public Summary EvaluationData { get; set; }
    }

    public class Summary
    {
        public AFTime ExeTime { get; set; }

        public double ElapsedMilliSeconds { get; set; }

        public double LagMilliSeconds { get; set; }
    }
}
