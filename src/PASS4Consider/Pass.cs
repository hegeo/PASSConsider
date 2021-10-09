using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PASS4Consider
{
    class Pass
    {
        //1、PASS初始化
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_Init", CharSet = CharSet.Ansi)]
        public static extern int MDC_Init(String pcCheckMode,
                    String pcHisCode,
                    String pcDoctorCode);

        //2、传病人基本记录信息函数
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_SetPatient", CharSet = CharSet.Ansi)]
        public static extern int MDC_SetPatient(String pcPatCode,
                            String pcInHospNo,
                            String pcVisitCode,
                            String pcName,
                            String pcSex,
                            String pcBirthday,
                            String pcHeightCM,
                            String pcWeighKG,
                            String pcDeptCode,
                            String pcDeptName,
                            String pcDoctorCode,
                            String pcDoctorName,
                            int piPatStatus,
                            int piIsLactation,
                            int piIsPregnancy,
                            String pcPregStartDate,
                            int piHepDamageDegree,
                        int piRenDamageDegree);

        //3、传病人药品记录信息
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_AddScreenDrug", CharSet = CharSet.Ansi)]
        public static extern int MDC_AddScreenDrug(String pcIndex,
                           int piOrderNo,
                           String pcDrugUniqueCode,
                           String pcDrugName,
                           String pcDosePerTime,
                           String pcDoseUnit,
                           String pcFrequency,
                           String pcRouteCode,
                           String pcRouteName,
                           String pcStartTime,
                           String pcEndTime,
                           String pcExecuteTime,
                           String pcGroupTag,
                           String pcIsTempDrug,
                           String pcOrderType,
                           String pcDeptCode,
                           String pcDeptName,
                           String pcDoctorCode,
                           String pcDoctorName,
                           String pcRecipNo,
                           String pcNum,
                           String pcNumUnit,
                           String pcPurpose,
                           String pcOprCode,
                           String pcMediTime,
                           String pcRemark);

        //4、传入病人过敏史记录信息
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_AddAller", CharSet = CharSet.Ansi)]
        public static extern int MDC_AddAller(string pcIndex,
                           string pcAllerCode,
                           string pcAllerName,
                           string pcAllerSymptom);

        //5、传入病人诊断记录信息
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_AddMedCond", CharSet = CharSet.Ansi)]
        public static extern int MDC_AddMedCond(string pcIndex,
                           string pcDiseaseCode,
                           string pcDiseaseName,
                           string pcRecipNo);

        //6、传入病人手术记录信息
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_AddOperation", CharSet = CharSet.Ansi)]
        public static extern int MDC_AddOperation(string pcIndex,
                           string pcOprCode,
                           string pcOprName,
                           string pcIncisionType,
                           string pcOprStartDateTime,
                           string pcOprEndDateTime);
        //7、调用病人补充信息
        [DllImport("PASS4Invoke.dll", EntryPoint = " MDC_AddJsonInfo ", CharSet = CharSet.Ansi)]
        public static extern int MDC_AddJsonInfo(string pcJson);

        //7、审查函数
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_DoCheck", CharSet = CharSet.Ansi)]
        public static extern int MDC_DoCheck(int piShowMode,
                           int piIsSave);

        //8、获取药品医嘱警示级别
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_GetWarningCode", CharSet = CharSet.Ansi)]
        public static extern int MDC_GetWarningCode(string pcIndex);

        //9、获取一条药品医嘱的审查结果提示窗口函数
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_ShowWarningHint", CharSet = CharSet.Ansi)]
        public static extern int MDC_ShowWarningHint(string pcIndex);

        //10、关闭一条药品医嘱的审查结果提示窗口函数
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_CloseWarningHint", CharSet = CharSet.Ansi)]
        public static extern int MDC_CloseWarningHint();




        //13、传入一个查询药品函数
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_DoSetDrug", CharSet = CharSet.Ansi)]
        public static extern int MDC_DoSetDrug(String pcDrugUniqueCode, String pcDrugName);

        //14、获取药品查询项目有效性函数
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_DoRefDrugEnable", CharSet = CharSet.Ansi)]
        public static extern string MDC_DoRefDrugEnable(int piQueryType);

        //15、查询药品信息函数
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_DoRefDrug", CharSet = CharSet.Ansi)]
        public static extern int MDC_DoRefDrug(int piQueryType);

        //16、关闭浮动窗口函数
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_CloseDrugHint", CharSet = CharSet.Ansi)]
        public static extern int MDC_CloseDrugHint();

        //17、本地参数设置窗口函数
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_Settings", CharSet = CharSet.Ansi)]
        public static extern int MDC_Settings();
        //18、PASS综合和命令函数
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_DoPASSCommand", CharSet = CharSet.Ansi)]
        public static extern int MDC_DoPASSCommand(String pcCommandType);
        //19、关闭药品剂量推荐窗口
        [DllImport("PASS4Invoke.dll", EntryPoint = " MDC_CloseRecomDose ", CharSet = CharSet.Ansi)]
        public static extern int MDC_CloseRecomDose();

        //20、调用药研究窗口函数
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_DoMediStudy", CharSet = CharSet.Ansi)]
        public static extern int MDC_DoMediStudy(string pcUseTime);

        //21、获取PASS系统最后一次错误信息函数
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_GetLastError", CharSet = CharSet.Ansi)]
        public static extern string MDC_GetLastError();

        //22、PASS退出
        [DllImport("PASS4Invoke.dll", EntryPoint = "MDC_Quit", CharSet = CharSet.Ansi)]
        public static extern int MDC_Quit();
    }
}
