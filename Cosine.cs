/*
 * Created by SharpDevelop.
 * User: JT
 * Date: 20.2.2010
 * Time: 16:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using SimMetricsUtilities;
using SimMetricsMetricUtilities;

namespace PDFv2
{
	/// <summary>
	/// Description of Cosine.
	/// </summary>
	public class Cosine
	{

/*		private static readonly Levenstein _Levenstein;
        private static readonly NeedlemanWunch _NeedlemanWunch;
        private static readonly SmithWaterman _SmithWaterman;
        private static readonly SmithWatermanGotoh _SmithWatermanGotoh;
        private static readonly SmithWatermanGotohWindowedAffine _SmithWatermanGotohWindowedAffine;
        private static readonly Jaro _Jaro;
        private static readonly JaroWinkler _JaroWinkler;
        private static readonly ChapmanLengthDeviation _ChapmanLengthDeviation;
        private static readonly ChapmanMeanLength _ChapmanMeanLength;
        private static readonly QGramsDistance _QGramsDistance;
        private static readonly BlockDistance _BlockDistance;
*/        private static readonly CosineSimilarity _CosineSimilarity;
/*        private static readonly DiceSimilarity _DiceSimilarity;
        private static readonly EuclideanDistance _EuclideanDistance;
        private static readonly JaccardSimilarity _JaccardSimilarity;
        private static readonly MatchingCoefficient _MatchingCoefficient;
        private static readonly MongeElkan _MongeElkan;
        private static readonly OverlapCoefficient _OverlapCoefficient;
*/		
		static Cosine()
		{
			_CosineSimilarity = new CosineSimilarity();
		}
		public static double compare(string A, string B)
		{
			return _CosineSimilarity.GetSimilarity(A, B);
		}
		
	}
}
