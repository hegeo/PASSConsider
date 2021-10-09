using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PASS4Consider
{
    class Model
    {

    }
    public class PatInfo 
    {
        public string pcPatCode { get; set; }
        public string pcInHospNo { get; set; }
        public string pcVisitCode { get; set; }
        public string pcName { get; set; }
        public string pcSex { get; set; }
        public string pcBirthday { get; set; }
        public string pcHeightCM { get; set; }
        public string pcWeighKG { get; set; }
        public string pcDeptCode { get; set; }
        public string pcDeptName { get; set; }
        public string pcDoctorCode { get; set; }
        public string pcDoctorName { get; set; }
        public int piPatStatus { get; set; }
        public int piIsLactation { get; set; }
        public int piIsPregnancy { get; set; }
        public string pcPregStartDate { get; set; }
        public int piHepDamageDegree { get; set; }
        public int piRenDamageDegree { get; set; }
    }
    public class DrugInfo
    {
        public string PassState { get; set; }
        public SolidColorBrush PassColor { get; set; }

        public string pcIndex { get; set; }
        public int pcOrderNo { get; set; }
        public string pcDrugUniqueCode { get; set; }
        public string pcDrugName { get; set; }
        public string pcDosePerTime { get; set; }
        public string pcDoseUnit { get; set; }
        public string pcFrequency { get; set; }
        public string pcRouteCode { get; set; }
        public string pcRouteName { get; set; }
        public string pcStartTime { get; set; }
        public string pcEndTime { get; set; }
        public string pcExecuteTime { get; set; }
        public string pcGroupTag { get; set; }
        public string pcIsTempDrug { get; set; }
        public string pcOrderType { get; set; }
        public string pcDeptCode { get; set; }
        public string pcDeptName { get; set; }
        public string pcDoctorCode { get; set; }
        public string pcDoctorName { get; set; }
        public string pcRecipNo { get; set; }
        public string pcNum { get; set; }
        public string pcNumUnit { get; set; }
        public string pcPurpose { get; set; }
        public string pcMediTime { get; set; }
        public string pcRemark { get; set; }


    }
    public class MedInfo {
        public string pcIndex { get; set; }
        public string pcDiseaseCode { get; set; }
        public string pcDiseaseName { get; set; }
        public string pcRecipNo { get; set; }
    }
       
    }
    public class AllerInfo
    {
        public string pcIndex { get; set; }
        public string pcAllerCode { get; set; }
        public string pcAllerName { get; set; }
        public string pcAllerSymptom { get; set; }
    }
    public class OperationInfo
    {
        public string pcIndex { get; set; }
        public string pcOprCode { get; set; }
        public string pcOprName { get; set; }
        public string pcIncisionType { get; set; }
        public string pcOprStartDateTime { get; set; }
        public string pcOprEndDateTime { get; set; }
    }

