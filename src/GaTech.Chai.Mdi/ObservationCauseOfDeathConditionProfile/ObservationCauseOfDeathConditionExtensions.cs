using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.ObservationCauseOfDeathConditionProfile
{
    /// <summary>
    /// Class with Observation extensions for ObservationCauseOfDeathConditionProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-cause-of-death-condition
    /// </summary>
    public static class ObservationCauseOfDeathConditionExtensions
    {
        public static ObservationCauseOfDeathCondition ObservationCauseOfDeathCondition(this Observation observation)
        {
            return new ObservationCauseOfDeathCondition(observation);
        }
    }
}
