using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using static Hl7.Fhir.Model.Composition;
using GaTech.Chai.Mdi.Common;
using System.Collections.Generic;

namespace GaTech.Chai.Mdi.CompositionMditoEdrsProfile
{
    /// <summary>
    /// CompositionMditoEdrsProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-to-edrs
    /// </summary>
    public class CompositionMdiToEdrs
    {
        readonly Composition composition;

        internal CompositionMdiToEdrs(Composition composition)
        {
            this.composition = composition;

            composition.Type = new CodeableConcept("http://loinc.org", "86807-5");
        }

        /// <summary>
        /// Factory for CompositionMditoEdrsProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-to-edrs
        /// </summary>
        public static Composition Create()
        {
            var composition = new Composition();
            composition.CompositionMdiToEdrs().AddProfile();
            return composition;
        }

        /// <summary>
        /// The official URL for the CompositionMditoEdrsProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-to-edrs";

        /// <summary>
        /// Set profile for the CompositionMditoEdrsProfile
        /// </summary>
        public void AddProfile()
        {
            composition.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the CompositionMditoEdrsProfile
        /// </summary>
        public void RemoveProfile()
        {
            composition.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// MDI Case Number
        /// </summary>
        public string MdiCaseNumber
        {
            get
            {
                foreach (Extension ext in this.composition.GetExtensions("http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number"))
                {
                    Coding coding = (ext.Value as Identifier).Type?.Coding?.Find(e => e.System == "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes" && e.Code == "mdi-case-number");
                    if (coding != null)
                    {
                        return ext.Value.ToString();
                    }
                }

                return null;
            }

            set
            {
                Extension ext = new Extension() { Url = "http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number" };
                ext.Value = new Identifier() { Type = MdiCodeSystem.MdiCaseNumber, Value = value };
                this.composition.Extension.AddOrUpdateExtension(ext);
            }
        }

        /// <summary>
        /// MDI Case Number
        /// </summary>
        public string EdrsFileNumber
        {
            get
            {
                foreach (Extension ext in this.composition.GetExtensions("http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number"))
                {
                    Coding coding = (ext.Value as Identifier).Type?.Coding?.Find(e => e.System == "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes" && e.Code == "edrs-file-number");
                    if (coding != null)
                    {
                        return ext.Value.ToString();
                    }
                }

                return null;
            }

            set
            {
                Extension ext = new Extension() { Url = "http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number" };
                ext.Value = new Identifier() { Type = MdiCodeSystem.EdrsFileNumber, Value = value };
                this.composition.Extension.AddOrUpdateExtension(ext);
            }
        }


        /// <summary>
        /// Condition of Interest
        /// </summary>
        public SectionComponent Demographics
        {
            get => GetOrAddSection("demographics", MdiCodeSystem.Demographics.Coding[0].Display);
            set => AddOrUpdateSection("demographics", MdiCodeSystem.Demographics.Coding[0].Display, value);
        }

        /// <summary>
        /// Circumstances
        /// </summary>
        public SectionComponent Circumstances
        {
            get => GetOrAddSection("circumstances", MdiCodeSystem.Circumstances.Coding[0].Display);
            set => AddOrUpdateSection("circumstances", MdiCodeSystem.Circumstances.Coding[0].Display, value);
        }

        /// <summary>
        /// Jurisdiction
        /// </summary>
        public SectionComponent Jurisdiction
        {
            get => GetOrAddSection("jurisdiction", MdiCodeSystem.Jurisdiction.Coding[0].Display);
            set => AddOrUpdateSection("jurisdiction", MdiCodeSystem.Jurisdiction.Coding[0].Display, value);
        }

        /// <summary>
        /// cause-manner
        /// </summary>
        public SectionComponent CauseManner
        {
            get => GetOrAddSection("cause-manner", MdiCodeSystem.CauseManner.Coding[0].Display);
            set => AddOrUpdateSection("cause-manner", MdiCodeSystem.CauseManner.Coding[0].Display, value);
        }

        /// <summary>
        /// Epi Observations
        /// </summary>
        public SectionComponent MedicalHistory
        {
            get => GetOrAddSection("medical-history", MdiCodeSystem.MedicalHistory.Coding[0].Display);
            set => AddOrUpdateSection("medical-history", MdiCodeSystem.MedicalHistory.Coding[0].Display, value);
        }

        /// <summary>
        /// Exam Autopsy
        /// </summary>
        public SectionComponent ExamAutopsy
        {
            get => GetOrAddSection("exam-autopsy", null);
            set => AddOrUpdateSection("exam-autopsy", null, value);
        }

        /// <summary>
        /// Narratives
        /// </summary>
        public SectionComponent Narratives
        {
            get => GetOrAddSection("narratives", null);
            set => AddOrUpdateSection("narratives", null, value);
        }

        protected SectionComponent GetOrAddSection(Coding coding)
        {
            return composition.Section.GetOrAddSection(coding.System, coding.Code,
                    coding.Display, coding.Display);
        }

        protected SectionComponent GetOrAddSection(string code, string display)
        {
            return composition.Section.GetOrAddSection(
                    "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", code,
                    display, display);
        }

        protected SectionComponent GetOrAddSection(string code, string display, string title)
        {
            return composition.Section.GetOrAddSection(
                    "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes",
                    code, title, display);
        }

        protected void AddOrUpdateSection(string code, string display, Composition.SectionComponent section)
        {
            composition.Section.AddOrUpdateSection(
                    "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", code,
                    display, display, section);
        }

        protected void AddOrUpdateSection(string code, string display, string title, Composition.SectionComponent section)
        {
            composition.Section.AddOrUpdateSection(
                    "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes",
                    code, title, display, section);
        }
    }
}