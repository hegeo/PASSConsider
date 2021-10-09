using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PASS4Consider
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<PatInfo> patData = new ObservableCollection<PatInfo>();
        ObservableCollection<MedInfo> medData = new ObservableCollection<MedInfo>();
        ObservableCollection<AllerInfo> allerData = new ObservableCollection<AllerInfo>();
        ObservableCollection<OperationInfo> oprData = new ObservableCollection<OperationInfo>();
        ObservableCollection<DrugInfo> drugData = new ObservableCollection<DrugInfo>();

        int passstate = 0;
        string openfilepath="";

        public MainWindow()
        {

            InitializeComponent();



            表格疾病信息.DataContext = medData;
            表格过敏原.DataContext = allerData;
            表格手术信息.DataContext = oprData;
            表格医嘱信息.DataContext = drugData;
            /*PASS嵌套兼容性*/
            medData.Add(new MedInfo());
            allerData.Add(new AllerInfo());
            oprData.Add(new OperationInfo());
            drugData.Add(new DrugInfo());
            输入出生日期.Text = "2000-01-01";
            输入妊娠时间.Text = "2000-01-01";
            输入审查时间.Text = DateTime.Now.ToString("yyyy-MM-dd");

            // 输入姓名.SetBinding(TextBox.TextProperty, new Binding("pcName") { Source = patData });
            // 选择性别.SetBinding(ComboBox.SelectedValueProperty, new Binding("pcSex") { Source = patData });


        }

        private void 按钮医嘱信息增加_Click(object sender, RoutedEventArgs e)
        {
            drugData.Add(new DrugInfo());
        }

        private void 按钮医嘱信息删除_Click(object sender, RoutedEventArgs e)
        {
            if (表格医嘱信息.SelectedItems.Count > 0 && 表格医嘱信息.Items.Count > 1)
            {
                while (表格医嘱信息.SelectedItems.Count > 0)
                {
                    int index = 表格医嘱信息.SelectedIndex;
                    drugData.RemoveAt(index);
                }
            }
            else if (表格医嘱信息.SelectedItems.Count == 0 && 表格医嘱信息.Items.Count > 1)
            {
                int index = 表格医嘱信息.Items.Count - 1;
                drugData.RemoveAt(index);
            }
            else if (表格医嘱信息.Items.Count == 1) { drugData[0] = new DrugInfo(); }
        }

        private void 按钮手术信息增加_Click(object sender, RoutedEventArgs e)
        {
            oprData.Add(new OperationInfo());
        }

        private void 按钮手术信息删除_Click(object sender, RoutedEventArgs e)
        {
            if (表格手术信息.SelectedItems.Count > 0 && 表格手术信息.Items.Count > 1)
            {
                while (表格手术信息.SelectedItems.Count > 0)
                {
                    int index = 表格手术信息.SelectedIndex;
                    oprData.RemoveAt(index);
                }
            }
            else if (表格手术信息.SelectedItems.Count == 0 && 表格手术信息.Items.Count > 1)
            {
                int index = 表格手术信息.Items.Count - 1;
                oprData.RemoveAt(index);
            }
            else if (表格手术信息.Items.Count == 1) { oprData[0] = new OperationInfo(); }
           ;
        }

        private void 按钮过敏原增加_Click(object sender, RoutedEventArgs e)
        {
            allerData.Add(new AllerInfo());
        }

        private void 按钮过敏原删除_Click(object sender, RoutedEventArgs e)
        {
            if (表格过敏原.SelectedItems.Count > 0 && 表格过敏原.Items.Count > 1)
            {
                while (表格过敏原.SelectedItems.Count > 0)
                {
                    int index = 表格过敏原.SelectedIndex;
                    allerData.RemoveAt(index);
                }
            }
            else if (表格过敏原.SelectedItems.Count == 0 && 表格过敏原.Items.Count > 1)
            {
                int index = 表格过敏原.Items.Count - 1;
                allerData.RemoveAt(index);
            }
            else if (表格过敏原.Items.Count == 1) { allerData[0] = new AllerInfo(); }
        }

        private void 按钮疾病信息增加_Click(object sender, RoutedEventArgs e)
        {
            medData.Add(new MedInfo());
        }

        private void 按钮疾病信息删除_Click(object sender, RoutedEventArgs e)
        {
            if (表格疾病信息.SelectedItems.Count > 0 && 表格疾病信息.Items.Count > 1)
            {
                while (表格疾病信息.SelectedItems.Count > 0)
                {
                    int index = 表格疾病信息.SelectedIndex;
                    medData.RemoveAt(index);
                }
            }
            else if (表格疾病信息.SelectedItems.Count == 0 && 表格疾病信息.Items.Count > 1)
            {
                int index = 表格疾病信息.Items.Count - 1;
                medData.RemoveAt(index);
            }
            else if (表格疾病信息.Items.Count == 1) { medData[0] = new MedInfo(); }

            /*原始的选择删除或自动删除最后一行代码，上面的为兼容PASS嵌套保留最后一行
            if (表格疾病信息.SelectedItems.Count > 0)
            {
                while (表格疾病信息.SelectedItems.Count > 0)
                {
                    int index = 表格疾病信息.SelectedIndex;
                    medData.RemoveAt(index);
                }
            }
            else if (表格疾病信息.SelectedItems.Count == 0 && 表格疾病信息.Items.Count > 0)
            {
                int index = 表格疾病信息.Items.Count - 1;
                medData.RemoveAt(index);
            }
            */
        }

        private void 按钮医嘱信息组合_Click(object sender, RoutedEventArgs e)
        {
            int grouptag = 1; ;
            if ((drugData.Max(t => t.pcGroupTag)) != null)
            {
                if ((drugData.Max(t => t.pcGroupTag)) != "")
                {
                    grouptag = (Convert.ToInt32(drugData.Max(t => t.pcGroupTag)) + 1);
                }
            }
            if (表格医嘱信息.SelectedItems.Count > 1)
            {

                while (表格医嘱信息.SelectedItems.Count > 0)
                {
                    int index = 表格医嘱信息.SelectedIndex;
                    drugData[index].pcGroupTag = grouptag.ToString();
                    表格医嘱信息.SelectedItems.Remove(表格医嘱信息.SelectedItem);
                }
                表格医嘱信息.ItemsSource = null;
                表格医嘱信息.ItemsSource = drugData;

                /* 使用foreach方式更新
                var selectedRows = 表格医嘱信息.SelectedItems;
                ItemCollection dvgitems = 表格医嘱信息.Items;
                 int grouptag = 1; ;
                if ((drugData.Max(t => t.pcGroupTag)) != null )
                {
                if ((drugData.Max(t => t.pcGroupTag)) != "")
                {
                    grouptag = (Convert.ToInt32(drugData.Max(t => t.pcGroupTag)) + 1);
                }
                }
                  foreach (var sltitem in selectedRows)
                {
                    int rindex = dvgitems.IndexOf(sltitem);
                     drugData[rindex].pcGroupTag = grouptag.ToString();
                    //MessageBox.Show("已选" + rindex);
                }
                */


            }

        }

        private void 按钮医嘱信息拆分_Click(object sender, RoutedEventArgs e)
        {
            if (表格医嘱信息.SelectedItems.Count > 0)
            {
                while (表格医嘱信息.SelectedItems.Count > 0)
                {
                    int index = 表格医嘱信息.SelectedIndex;
                    drugData[index].pcGroupTag = "";
                    表格医嘱信息.SelectedItems.Remove(表格医嘱信息.SelectedItem);
                }
                表格医嘱信息.ItemsSource = null;
                表格医嘱信息.ItemsSource = drugData;

            }
        }

        private void 菜单打开_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "用药研究文件(*.pass)|*.pass|用药研究文件(*.mrcp)|*.mrcp";
            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    JObject jsonData = LoadJson(openFileDialog.FileName);
                    CleanData();
                    LoadPatinfo(jsonData);
                    LoadMedinfo(jsonData);
                    LoadAllerinfo(jsonData);
                    LoadOperationinfo(jsonData);
                    LoadDurginfo(jsonData);
                    openfilepath = openFileDialog.FileName;
                    consider.Content = openFileDialog.FileName;

                    /*以下代码为PASS兼容性需要，去除读取文件后表格一个空白格*/
                    if (表格疾病信息.Items.Count > 1) { medData.RemoveAt(0); }
                    if (表格过敏原.Items.Count > 1) { allerData.RemoveAt(0); }
                    if (表格手术信息.Items.Count > 1) { oprData.RemoveAt(0); }
                    if (表格医嘱信息.Items.Count > 1) { drugData.RemoveAt(0); }
                  
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("文件加载失败，请确认是否为有效的格式");
            }


        }

        private void 菜单新建_Click(object sender, RoutedEventArgs e)
        {
            consider.Content = "consider";
            openfilepath = "";
            CleanData();
        }

        private void 菜单保存_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (openfilepath != "")
                {
                    string export = SaveJson().ToString();
                    FileStream myFs = new FileStream(openfilepath, FileMode.Create);
                    StreamWriter mySw = new StreamWriter(myFs, Encoding.UTF8);
                    mySw.Write(export);
                    mySw.Close();
                    myFs.Close();
                }
                else
                {
                    //创建保存文件对话窗体
                    SaveFileDialog savefile = new SaveFileDialog();
                    savefile.FileName = "用药研究_" + 输入姓名.Text;
                    savefile.Filter = "用药研究文件(*.pass)|*.pass";

                    if (savefile.ShowDialog() == true)
                    {
                        string fileName = savefile.FileName;   //获取要保存文件的路径
                        string export = SaveJson().ToString();
                        FileStream myFs = new FileStream(fileName, FileMode.Create);
                        StreamWriter mySw = new StreamWriter(myFs, Encoding.UTF8);
                        mySw.Write(export);
                        mySw.Close();
                        myFs.Close();
                    }
                }
                MessageBox.Show("保存成功");
            }
            catch (Exception) { MessageBox.Show("输入的信息不完整或有误，保存失败"); }
        }

        private void 菜单另存为_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //创建保存文件对话窗体
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = "用药研究_" + 输入姓名.Text;
                savefile.Filter = "用药研究文件(*.pass)|*.pass";
                if (savefile.ShowDialog() == true)
                {
                    string fileName = savefile.FileName;   //获取要保存文件的路径
                    string export = SaveJson().ToString();
                    FileStream myFs = new FileStream(fileName, FileMode.Create);
                    StreamWriter mySw = new StreamWriter(myFs, Encoding.UTF8);
                    mySw.Write(export);
                    mySw.Close();
                    myFs.Close();
                }
                MessageBox.Show("保存成功");
            }
            catch (Exception)
            { MessageBox.Show("输入的信息不完整或有误，保存失败"); }
        }

        private void 菜单关闭_Click(object sender, RoutedEventArgs e)
        {
            consider.Content = "consider";
            openfilepath = "";
            CleanData();
        }

        private void 菜单退出_Click(object sender, RoutedEventArgs e)
        {
            if (passstate == 1)
            {
                Pass.MDC_Quit();
            }
            Application.Current.Shutdown();
        }

        private void 菜单清空_Click(object sender, RoutedEventArgs e)
        {
            CleanData();
        }

        private void 菜单关于_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("PASS用药研究\n版本：v1.1\n邮箱：hegeo@foxmail.com\n四川美康合理用药 | Hegeo | 2020");
        }

        //清除界面数据
        private void CleanData()
        {

            while (表格疾病信息.Items.Count > 1)
            {
                int index = 表格疾病信息.Items.Count - 1;
                medData.RemoveAt(index);
            }
            medData[0] = new MedInfo();
            while (表格过敏原.Items.Count > 1)
            {
                int index = 表格过敏原.Items.Count - 1;
                allerData.RemoveAt(index);
            }
            allerData[0] = new AllerInfo();
            while (表格手术信息.Items.Count > 1)
            {
                int index = 表格手术信息.Items.Count - 1;
                oprData.RemoveAt(index);
            }
            oprData[0] = new OperationInfo();
            while (表格医嘱信息.Items.Count > 1)
            {
                int index = 表格医嘱信息.Items.Count - 1;
                drugData.RemoveAt(index);
            }
            drugData[0] = new DrugInfo();

            /*原始的清除表格代码，上方的为兼容PASS嵌套保留最后一行
            medData.Clear();
            allerData.Clear();
            oprData.Clear();
            drugData.Clear();
            */

            输入姓名.Text = "";
            选择性别.SelectedIndex = -1;
            输入出生日期.Text = "";
            输入身高.Text = "";
            输入年龄.Text = "";
            输入体重.Text = "";
            输入科室.Text = "";
            选择哺乳状态.SelectedIndex = -1;
            选择妊娠状态.SelectedIndex = -1;
            输入妊娠时间.Text = "";
            选择肝损状态.SelectedIndex = -1;
            选择肾损状态.SelectedIndex = -1;
            输入主管医生.Text = "";
            选择处方类型.SelectedIndex = -1;
            输入出生日期.Text = "2000-01-01";
            输入妊娠时间.Text = "2000-01-01";
            输入审查时间.Text = DateTime.Now.ToString("yyyy-MM-dd");
            输入病人编号.Text = "";
            输入住院号.Text = "";
            输入会诊编号.Text = "";
        }
        //加载病人信息
        private void LoadPatinfo(JObject o)
        {
            输入姓名.Text = o["Patient"]["Name"].ToString();
            if (o["Patient"]["Sex"].ToString() == "男")
            {
                选择性别.SelectedIndex = 0;
            }
            else if (o["Patient"]["Sex"].ToString() == "女")
            {
                选择性别.SelectedIndex = 1;
            }

            if (o["Patient"]["Age"].ToString() == "")
            {
                输入年龄.Text = GetAgeByBirthdate(Convert.ToDateTime(o["Patient"]["Birthday"].ToString())).ToString();
            }
            else
            {
                输入年龄.Text = o["Patient"]["Age"].ToString();
            }
            输入出生日期.Text = o["Patient"]["Birthday"].ToString();
            输入身高.Text = o["Patient"]["HeightCM"].ToString();
            输入体重.Text = o["Patient"]["WeighKG"].ToString();
            输入科室.Text = o["Patient"]["DeptName"].ToString();
            选择哺乳状态.SelectedIndex = Convert.ToInt32(o["Patient"]["IsLactation"].ToString());
            选择妊娠状态.SelectedIndex = Convert.ToInt32(o["Patient"]["IsPregnancy"].ToString());

            输入妊娠时间.Text = o["Patient"]["PregStartDate"].ToString();
            if (Convert.ToInt32(o["Patient"]["HepDamageDegree"].ToString()) <= 0)
            {
                选择肝损状态.SelectedIndex = 0;
            }
            else { 选择肝损状态.SelectedIndex = Convert.ToInt32(o["Patient"]["HepDamageDegree"].ToString()); }
            if (Convert.ToInt32(o["Patient"]["RenDamageDegree"].ToString()) <= 0)
            {
                选择肾损状态.SelectedIndex = 0;
            }
            else
            {
                选择肾损状态.SelectedIndex = Convert.ToInt32(o["Patient"]["RenDamageDegree"].ToString());
            }
            输入主管医生.Text = o["Patient"]["DoctorName"].ToString();
            if (o["Patient"]["CheckMode"].ToString() == "mz") { 选择处方类型.SelectedIndex = 0; }
            else if (o["Patient"]["CheckMode"].ToString() == "zy") { 选择处方类型.SelectedIndex = 1; }
            else { 选择处方类型.SelectedIndex = 2; }

            输入审查时间.Text = o["Patient"]["UseTime"].ToString();
            输入病人编号.Text = o["Patient"]["PatCode"].ToString();
            输入住院号.Text = o["Patient"]["InHospNo"].ToString();
            输入会诊编号.Text = o["Patient"]["VisitCode"].ToString();
        }
        //加载疾病信息
        private void LoadMedinfo(JObject o)
        {
            if (o["ScreenMedCondList"]["ScreenMedConds"].Count() > 0)
            {
                for (int i = 0; i < o["ScreenMedCondList"]["ScreenMedConds"].Count(); i++)
                {
                    medData.Add(new MedInfo()
                    {
                        pcIndex = o["ScreenMedCondList"]["ScreenMedConds"][i]["Index"].ToString(),
                        pcDiseaseCode = o["ScreenMedCondList"]["ScreenMedConds"][i]["DiseaseCode"].ToString(),
                        pcDiseaseName = o["ScreenMedCondList"]["ScreenMedConds"][i]["DiseaseName"].ToString(),
                        pcRecipNo = o["ScreenMedCondList"]["ScreenMedConds"][i]["RecipNo"].ToString()
                    });

                }
            }

        }
        //加载过敏源信息
        private void LoadAllerinfo(JObject o)
        {
            if (o["ScreenAllergenList"]["ScreenAllergens"].Count() > 0)
            {
                for (int i = 0; i < o["ScreenAllergenList"]["ScreenAllergens"].Count(); i++)
                {
                    allerData.Add(new AllerInfo()
                    {
                        pcIndex = o["ScreenAllergenList"]["ScreenAllergens"][i]["Index"].ToString(),
                        pcAllerCode = o["ScreenAllergenList"]["ScreenAllergens"][i]["AllerCode"].ToString(),
                        pcAllerName = o["ScreenAllergenList"]["ScreenAllergens"][i]["AllerName"].ToString(),
                        pcAllerSymptom = o["ScreenAllergenList"]["ScreenAllergens"][i]["AllerSymptom"].ToString()
                    });
                }
            }
        }
        //加载手术信息
        private void LoadOperationinfo(JObject o)
        {
            if (o["ScreenOperationList"]["ScreenOperations"].Count() > 0)
            {
                for (int i = 0; i < o["ScreenOperationList"]["ScreenOperations"].Count(); i++)
                {
                    oprData.Add(new OperationInfo()
                    {
                        pcIndex = o["ScreenOperationList"]["ScreenOperations"][i]["Index"].ToString(),
                        pcOprCode = o["ScreenOperationList"]["ScreenOperations"][i]["OprCode"].ToString(),
                        pcOprName = o["ScreenOperationList"]["ScreenOperations"][i]["OprName"].ToString(),
                        pcIncisionType = o["ScreenOperationList"]["ScreenOperations"][i]["IncisionType"].ToString(),
                        pcOprStartDateTime = o["ScreenOperationList"]["ScreenOperations"][i]["OprStartDate"].ToString(),
                        pcOprEndDateTime = o["ScreenOperationList"]["ScreenOperations"][i]["OprEndDate"].ToString()
                    });
                }
            }
        }
        //加载医嘱信息
        private void LoadDurginfo(JObject o)
        {
            if (o["ScreenDrugList"]["ScreenDrugs"].Count() > 0)
            {
                for (int i = 0; i < o["ScreenDrugList"]["ScreenDrugs"].Count(); i++)
                {
                    drugData.Add(new DrugInfo()
                    {
                        pcIndex = o["ScreenDrugList"]["ScreenDrugs"][i]["Index"].ToString(),
                        pcOrderNo = Convert.ToInt32(o["ScreenDrugList"]["ScreenDrugs"][i]["OrderNo"].ToString()),
                        pcDrugUniqueCode = o["ScreenDrugList"]["ScreenDrugs"][i]["DrugUniqueCode"].ToString(),
                        pcDrugName = o["ScreenDrugList"]["ScreenDrugs"][i]["DrugName"].ToString(),
                        pcDosePerTime = o["ScreenDrugList"]["ScreenDrugs"][i]["DosePerTime"].ToString(),
                        pcDoseUnit = o["ScreenDrugList"]["ScreenDrugs"][i]["DoseUnit"].ToString(),
                        pcFrequency = o["ScreenDrugList"]["ScreenDrugs"][i]["Frequency"].ToString(),
                        pcRouteCode = o["ScreenDrugList"]["ScreenDrugs"][i]["RouteCode"].ToString(),
                        pcRouteName = o["ScreenDrugList"]["ScreenDrugs"][i]["RouteName"].ToString(),
                        pcStartTime = o["ScreenDrugList"]["ScreenDrugs"][i]["StartTime"].ToString(),
                        pcEndTime = o["ScreenDrugList"]["ScreenDrugs"][i]["EndTime"].ToString(),
                        pcExecuteTime = o["ScreenDrugList"]["ScreenDrugs"][i]["ExecuteTime"].ToString(),
                        pcGroupTag = o["ScreenDrugList"]["ScreenDrugs"][i]["GroupTag"].ToString(),
                        pcIsTempDrug = o["ScreenDrugList"]["ScreenDrugs"][i]["IsTempDrug"].ToString(),
                        pcOrderType = o["ScreenDrugList"]["ScreenDrugs"][i]["OrderType"].ToString(),
                        pcDeptCode = o["ScreenDrugList"]["ScreenDrugs"][i]["DeptCode"].ToString(),
                        pcDeptName = o["ScreenDrugList"]["ScreenDrugs"][i]["DeptName"].ToString(),
                        pcDoctorCode = o["ScreenDrugList"]["ScreenDrugs"][i]["DoctorCode"].ToString(),
                        pcDoctorName = o["ScreenDrugList"]["ScreenDrugs"][i]["DoctorName"].ToString(),
                        pcRecipNo = o["ScreenDrugList"]["ScreenDrugs"][i]["RecipNo"].ToString(),
                        pcNum = o["ScreenDrugList"]["ScreenDrugs"][i]["Num"].ToString(),
                        pcNumUnit = o["ScreenDrugList"]["ScreenDrugs"][i]["NumUnit"].ToString(),
                        pcPurpose = o["ScreenDrugList"]["ScreenDrugs"][i]["Purpose"].ToString(),
                        pcMediTime = o["ScreenDrugList"]["ScreenDrugs"][i]["MediTime"].ToString(),
                        pcRemark = o["ScreenDrugList"]["ScreenDrugs"][i]["Remark"].ToString()
                    });
                }
            }
        }
        //计算生日
        public int GetAgeByBirthdate(DateTime birthdate)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthdate.Year;
            if (now.Month < birthdate.Month || (now.Month == birthdate.Month && now.Day < birthdate.Day))
            {
                age--;
            }
            return age < 0 ? 0 : age;
        }

        //读取Json文件
        public JObject LoadJson(string path)
        {
            JObject o = new JObject();
            FileStream fs = new FileStream(path, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);
            using (System.IO.StreamReader file = new StreamReader(fs, UTF8Encoding.Default))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    o = (JObject)JToken.ReadFrom(reader);
                }
            }
            return o;
        }
        //保存Json文件
        public StringWriter SaveJson()
        {
            StringWriter sw = new StringWriter();
            JsonTextWriter writer = new JsonTextWriter(sw);

            #region  写入基本信息
            writer.WriteStartObject();
            writer.WritePropertyName("Patient");
            writer.WriteStartObject();
            writer.WritePropertyName("PatCode");
            writer.WriteValue(输入病人编号.Text);
            writer.WritePropertyName("InHospNo");
            writer.WriteValue(输入住院号.Text);
            writer.WritePropertyName("VisitCode");
            writer.WriteValue(输入会诊编号.Text);
            writer.WritePropertyName("Name");
            writer.WriteValue(输入姓名.Text);
            writer.WritePropertyName("Sex");
            if (选择性别.SelectedIndex == 0)
            {
                writer.WriteValue("男");
            }
            else if (选择性别.SelectedIndex == 1)
            {
                writer.WriteValue("女");
            }
            writer.WritePropertyName("Birthday");
            writer.WriteValue(输入出生日期.SelectedDate.Value.ToString("yyyy-MM-dd"));
            writer.WritePropertyName("HeightCM");
            writer.WriteValue(输入身高.Text);
            writer.WritePropertyName("WeighKG");
            writer.WriteValue(输入体重.Text);
            writer.WritePropertyName("DeptName");
            writer.WriteValue(输入科室.Text);
            writer.WritePropertyName("DoctorName");
            writer.WriteValue(输入主管医生.Text);
            writer.WritePropertyName("IsLactation");
            writer.WriteValue(选择哺乳状态.SelectedIndex);
            writer.WritePropertyName("IsPregnancy");
            writer.WriteValue(选择妊娠状态.SelectedIndex);
            writer.WritePropertyName("PregStartDate");
            if (选择妊娠状态.SelectedIndex == 1)
            {
                writer.WriteValue(输入妊娠时间.SelectedDate.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                writer.WriteValue("");
            }
            writer.WritePropertyName("HepDamageDegree");
            writer.WriteValue(选择肝损状态.SelectedIndex);
            writer.WritePropertyName("RenDamageDegree");
            writer.WriteValue(选择肾损状态.SelectedIndex);
            writer.WritePropertyName("UseTime");
            writer.WriteValue(输入审查时间.SelectedDate.Value.ToString("yyyy-MM-dd"));
            writer.WritePropertyName("Age");
            writer.WriteValue(输入年龄.Text);
            writer.WritePropertyName("CheckMode");
            writer.WriteValue(选择处方类型.SelectedIndex);
            writer.WriteEndObject();
            #endregion

            #region 写入疾病信息
            writer.WritePropertyName("ScreenMedCondList");
            writer.WriteStartObject();
            writer.WritePropertyName("ScreenMedConds");
            writer.WriteStartArray();
            if (表格疾病信息.Items.Count > 0 && medData[0].pcDiseaseName!=null)
            {
                MessageBox.Show(medData[0].pcDiseaseName);
                MessageBox.Show(allerData[0].pcAllerName);
                MessageBox.Show(oprData[0].pcOprName);
                for (int i = 0; i < 表格疾病信息.Items.Count; i++)
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("Index");
                    writer.WriteValue(i);
                    writer.WritePropertyName("DiseaseCode");
                    writer.WriteValue(medData[i].pcDiseaseCode.ToString());
                    writer.WritePropertyName("DiseaseName");
                    writer.WriteValue(medData[i].pcDiseaseName.ToString());
                    writer.WritePropertyName("RecipNo");
                    writer.WriteValue(medData[i].pcRecipNo.ToString());
                    writer.WriteEndObject();
                };
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
            #endregion

            #region 写入过敏原
            writer.WritePropertyName("ScreenAllergenList");
            writer.WriteStartObject();
            writer.WritePropertyName("ScreenAllergens");
            writer.WriteStartArray();
            if (表格过敏原.Items.Count > 0 && allerData[0].pcAllerName != null)
            {
                for (int i = 0; i < 表格过敏原.Items.Count; i++)
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("Index");
                    writer.WriteValue(i);
                    writer.WritePropertyName("AllerCode");
                    writer.WriteValue(allerData[i].pcAllerCode.ToString());
                    writer.WritePropertyName("AllerName");
                    writer.WriteValue(allerData[i].pcAllerName.ToString());
                    writer.WritePropertyName("AllerSymptom");
                    writer.WriteValue(allerData[i].pcAllerSymptom.ToString());
                    writer.WriteEndObject();
                };
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
            #endregion

            #region 写入手术信息
            writer.WritePropertyName("ScreenOperationList");
            writer.WriteStartObject();
            writer.WritePropertyName("ScreenOperations");
            writer.WriteStartArray();
            if (表格手术信息.Items.Count > 0 && oprData[0].pcOprName != null)
            {               
                for (int i = 0; i < 表格手术信息.Items.Count; i++ )
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("Index");
                    writer.WriteValue(i);
                    writer.WritePropertyName("OprCode");
                    writer.WriteValue(oprData[i].pcOprCode.ToString());
                    writer.WritePropertyName("OprName");
                    writer.WriteValue(oprData[i].pcOprName.ToString());
                    writer.WritePropertyName("IncisionType");
                    writer.WriteValue(oprData[i].pcIncisionType.ToString());
                    writer.WritePropertyName("OprStartDate");
                    writer.WriteValue(oprData[i].pcOprStartDateTime.ToString());
                    writer.WritePropertyName("OprEndDate");
                    writer.WriteValue(oprData[i].pcOprEndDateTime.ToString());
                    writer.WriteEndObject();
                };
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
            #endregion

            #region 写入医嘱信息
            writer.WritePropertyName("ScreenDrugList");
            writer.WriteStartObject();
            writer.WritePropertyName("ScreenDrugs");
            writer.WriteStartArray();
            if (表格医嘱信息.Items.Count > 0 && drugData[0].pcDrugName != null)
            {
                for (int i = 0; i < 表格医嘱信息.Items.Count; i++)
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("Index");
                    writer.WriteValue(i);
                    writer.WritePropertyName("OrderNo");
                    writer.WriteValue(drugData[i].pcOrderNo);
                    writer.WritePropertyName("DrugUniqueCode");
                    writer.WriteValue(drugData[i].pcDrugUniqueCode);
                    writer.WritePropertyName("DrugName");
                    writer.WriteValue(drugData[i].pcDrugName);
                    writer.WritePropertyName("DosePerTime");
                    writer.WriteValue(drugData[i].pcDosePerTime);
                    writer.WritePropertyName("DoseUnit");
                    writer.WriteValue(drugData[i].pcDoseUnit);
                    writer.WritePropertyName("Frequency");
                    writer.WriteValue(drugData[i].pcFrequency);
                    writer.WritePropertyName("RouteCode");
                    writer.WriteValue(drugData[i].pcRouteCode);
                    writer.WritePropertyName("RouteName");
                    writer.WriteValue(drugData[i].pcRouteName);
                    writer.WritePropertyName("StartTime");
                    writer.WriteValue(drugData[i].pcStartTime);
                    writer.WritePropertyName("EndTime");
                    writer.WriteValue(drugData[i].pcEndTime);
                    writer.WritePropertyName("ExecuteTime");
                    writer.WriteValue(drugData[i].pcExecuteTime);
                    writer.WritePropertyName("GroupTag");
                    writer.WriteValue(drugData[i].pcGroupTag);
                    writer.WritePropertyName("IsTempDrug");
                    writer.WriteValue(drugData[i].pcIsTempDrug);
                    writer.WritePropertyName("OrderType");
                    writer.WriteValue(drugData[i].pcOrderType);
                    writer.WritePropertyName("DeptCode");
                    writer.WriteValue(drugData[i].pcDeptCode);
                    writer.WritePropertyName("DeptName");
                    writer.WriteValue(drugData[i].pcDeptName);
                    writer.WritePropertyName("DoctorCode");
                    writer.WriteValue(drugData[i].pcDoctorCode);
                    writer.WritePropertyName("DoctorName");
                    writer.WriteValue(drugData[i].pcDoctorName);
                    writer.WritePropertyName("RecipNo");
                    writer.WriteValue(drugData[i].pcRecipNo);
                    writer.WritePropertyName("Num");
                    writer.WriteValue(drugData[i].pcNum);
                    writer.WritePropertyName("NumUnit");
                    writer.WriteValue(drugData[i].pcNumUnit);
                    writer.WritePropertyName("Purpose");
                    writer.WriteValue(drugData[i].pcPurpose);
                    writer.WritePropertyName("MediTime");
                    writer.WriteValue(drugData[i].pcMediTime);
                    writer.WritePropertyName("Remark");
                    writer.WriteValue(drugData[i].pcRemark);
                    writer.WriteEndObject();
                };
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
            #endregion




            writer.WriteEndObject();

            return sw;
        }

        //无边框窗体移动方法
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        //初始化PASS
        private void 按钮初始化_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                passstate = Pass.MDC_Init("mz", "0", "test");
                if (passstate == 1)
                {
                    按钮初始化.Visibility = Visibility.Hidden;
                    按钮审查.IsEnabled = true;
                    按钮审查.Opacity = 1;
                    按钮说明书.IsEnabled = true;
                    按钮说明书.Opacity = 1;
                    按钮指导单.IsEnabled = true;
                    按钮指导单.Opacity = 1;
                }
                else
                {
                    MessageBox.Show("初始化PASS失败,请检查配置文件\n相关审查功能将不可用");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("未找到PASS系统, 请联系管理员\n相关审查功能将不可用");
            }

        }
        //单药提示
        private void 表格医嘱信息_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (passstate == 1  && drugData[表格医嘱信息.SelectedIndex].pcDrugName != null && drugData[表格医嘱信息.SelectedIndex].pcDrugUniqueCode != null)
                {       
                    Pass.MDC_DoSetDrug(drugData[表格医嘱信息.SelectedIndex].pcDrugUniqueCode.ToString(), drugData[表格医嘱信息.SelectedIndex].pcDrugName.ToString());
                    Pass.MDC_DoRefDrug(51);
                }

            }
            catch (Exception) { MessageBox.Show("医嘱内容不能为空或其他错误"); }
        }

    private void 按钮说明书_Click(object sender, RoutedEventArgs e)
        {
            if (表格医嘱信息.SelectedItems.Count != 0)
            {
                try
                {
                    if (passstate == 1)
                    {
                        Pass.MDC_DoSetDrug(drugData[表格医嘱信息.SelectedIndex].pcDrugUniqueCode.ToString(), drugData[表格医嘱信息.SelectedIndex].pcDrugName.ToString());
                        Pass.MDC_DoRefDrug(11);
                    }
                    else
                    {
                        MessageBox.Show(drugData[表格医嘱信息.SelectedIndex].pcDrugName.ToString());
                    }
                }
                catch (Exception) { MessageBox.Show("调取说明书失败了！"); }
            }
            else { MessageBox.Show("未选取任何药品！"); }
        }
          

        private void 按钮指导单_Click(object sender, RoutedEventArgs e)
        {
            int setstate = Pass.MDC_SetPatient(输入病人编号.Text,输入住院号.Text,输入会诊编号.Text, 输入姓名.Text, 选择性别.Text, 输入出生日期.Text, 输入身高.Text, 输入体重.Text, "", 输入科室.Text, 输入主管医生.Text, "", 选择处方类型.SelectedIndex, 选择哺乳状态.SelectedIndex, 选择妊娠状态.SelectedIndex, 输入妊娠时间.Text, 选择肝损状态.SelectedIndex, 选择肾损状态.SelectedIndex);
            if (setstate != 1)
            {
                MessageBox.Show("传入病人信息有误，请检查信息是否完整！");
            }
            else
            {
                if (表格医嘱信息.Items.Count > 0 && drugData[0].pcDrugName != null)
                {
                    for (int i = 0; i < 表格医嘱信息.Items.Count; i++)
                    {
                        int drugstate = Pass.MDC_AddScreenDrug(i.ToString(), drugData[i].pcOrderNo, drugData[i].pcDrugUniqueCode, drugData[i].pcDrugName, drugData[i].pcDosePerTime, drugData[i].pcDoseUnit, drugData[i].pcFrequency, drugData[i].pcRouteCode, drugData[i].pcRouteName, drugData[i].pcStartTime, drugData[i].pcEndTime, drugData[i].pcExecuteTime, drugData[i].pcGroupTag, drugData[i].pcIsTempDrug, drugData[i].pcOrderType, drugData[i].pcDeptCode, drugData[i].pcDeptName, drugData[i].pcDoctorCode, drugData[i].pcDoctorName, drugData[i].pcRecipNo, drugData[i].pcNum, drugData[i].pcNumUnit, drugData[i].pcPurpose, "", drugData[i].pcMediTime, drugData[i].pcRemark);
                        if (drugstate != 1)
                        {
                            MessageBox.Show("传入医嘱信息有误，请检查信息是否完整！");
                        }
                    }
                }
                int checkstate = Pass.MDC_DoPASSCommand("34");
                if (checkstate == 0)
                {
                    MessageBox.Show("无法生成用药指引单！");
                }

            }
               
        }

        private void 按钮审查_Click(object sender, RoutedEventArgs e)
        {
            int setstate = Pass.MDC_SetPatient(输入病人编号.Text, 输入住院号.Text, 输入会诊编号.Text, 输入姓名.Text, 选择性别.Text, 输入出生日期.Text, 输入身高.Text, 输入体重.Text, "", 输入科室.Text, "", 输入主管医生.Text, 选择处方类型.SelectedIndex, 选择哺乳状态.SelectedIndex, 选择妊娠状态.SelectedIndex, 输入妊娠时间.Text, 选择肝损状态.SelectedIndex, 选择肾损状态.SelectedIndex);
            if (setstate != 1)
            {
                MessageBox.Show("传入病人信息有误，请检查信息是否完整！");
            }
            else
            {
                if (表格疾病信息.Items.Count > 0 && medData[0].pcDiseaseName != null)
                {
                    for (int i = 0; i < 表格疾病信息.Items.Count; i++)
                    {
                        int medstate = Pass.MDC_AddMedCond(medData[i].pcIndex, medData[i].pcDiseaseCode, medData[i].pcDiseaseName, medData[i].pcRecipNo);
                        if (medstate != 1)
                        {
                            MessageBox.Show("传入疾病信息有误，请检查信息是否完整！");
                        }
                    }
                }
                if (表格过敏原.Items.Count > 0 && allerData[0].pcAllerName != null)
                {
                    for (int i = 0; i < 表格过敏原.Items.Count; i++)
                    {
                        int allerstate = Pass.MDC_AddAller(allerData[i].pcIndex, allerData[i].pcAllerCode, allerData[i].pcAllerName, allerData[i].pcAllerSymptom);
                        if (allerstate != 1)
                        {
                            MessageBox.Show("传入过敏原有误，请检查信息是否完整！");
                        }
                    }
                }
                if (表格手术信息.Items.Count > 0 && oprData[0].pcOprName != null)
                {
                    for (int i = 0; i < 表格手术信息.Items.Count; i++)
                    {
                        int oprstate = Pass.MDC_AddOperation(oprData[i].pcIndex, oprData[i].pcOprCode, oprData[i].pcOprName, oprData[i].pcIncisionType, oprData[i].pcOprStartDateTime, oprData[i].pcOprEndDateTime);
                        if (oprstate != 1)
                        {
                            MessageBox.Show("传入手术信息有误，请检查信息是否完整！");
                        }
                    }
                }
                if (表格医嘱信息.Items.Count > 0 && drugData[0].pcDrugName != null)
                {
                    for (int i = 0; i < 表格医嘱信息.Items.Count; i++)
                    {
                        int drugstate = Pass.MDC_AddScreenDrug(i.ToString(), drugData[i].pcOrderNo, drugData[i].pcDrugUniqueCode, drugData[i].pcDrugName, drugData[i].pcDosePerTime, drugData[i].pcDoseUnit, drugData[i].pcFrequency, drugData[i].pcRouteCode, drugData[i].pcRouteName, drugData[i].pcStartTime, drugData[i].pcEndTime, drugData[i].pcExecuteTime, drugData[i].pcGroupTag, drugData[i].pcIsTempDrug, drugData[i].pcOrderType, drugData[i].pcDeptCode, drugData[i].pcDeptName, drugData[i].pcDoctorCode, drugData[i].pcDoctorName, drugData[i].pcRecipNo, drugData[i].pcNum, drugData[i].pcNumUnit, drugData[i].pcPurpose, "", drugData[i].pcMediTime, drugData[i].pcRemark);
                        if (drugstate != 1)
                        {
                            MessageBox.Show("传入医嘱信息有误，请检查信息是否完整！");
                        }
                    }
                    int checkstate = Pass.MDC_DoCheck(1, 0);
                    if (checkstate != 1)
                    {
                        MessageBox.Show("无法完成审查，请检查信息是否正确！");
                    }
                    else
                    {
                        int num = 0; int err = 0;
                        for (int s = 0; s < 表格医嘱信息.Items.Count; s++)
                        {
                            int state = Pass.MDC_GetWarningCode(s.ToString());
                            switch (state)
                            {
                                case 0:
                                    drugData[s].PassState = "●";
                                    drugData[s].PassColor = Brushes.Blue;
                                    break;
                                case 1:
                                    drugData[s].PassState = "●";
                                    drugData[s].PassColor = Brushes.Black;
                                    num += 1;
                                    break;
                                case 2:
                                    drugData[s].PassState = "●";
                                    drugData[s].PassColor = Brushes.Red;
                                    num += 1;
                                    break;
                                case 3:
                                    drugData[s].PassState = "●";
                                    drugData[s].PassColor = Brushes.Orange;
                                    num += 1;
                                    break;
                                default:
                                    err = state;
                                    break;

                            }
                        }
                        if (num != 0 && err == 0) { MessageBox.Show("审查结束，发现" + num + "个不合理问题，请返回修改！"); }
                        else if (num == 0 && err == 0)
                        {
                            MessageBox.Show("审查通过！未发现问题\n");
                        }
                        else
                        {
                            switch (err)
                            {
                                case -1:
                                    MessageBox.Show("审查失败！医嘱中有药品在PASS中不存在或未配对");
                                    break;
                                case -2:
                                    MessageBox.Show("审查失败！医嘱中有药品用药时间不在审查时间内");
                                    break;
                                case -3:
                                    MessageBox.Show("审查失败！医嘱已停嘱，不进行监测");
                                    break;
                                case -4:
                                    MessageBox.Show("审查失败！医嘱已作废，不进行监测");
                                    break;
                                case -5:
                                    MessageBox.Show("审查失败！系统设置出院带药不进行监测");
                                    break;
                                case -6:
                                    MessageBox.Show("审查失败！调用PASS系统失败，请联系管理员");
                                    break;
                                case -9:
                                    MessageBox.Show("审查失败！医嘱中无开始和结束时间");
                                    break;
                                default:
                                    MessageBox.Show("审查失败！错误码：" + err);
                                    break;
                            }
                        }

                        表格医嘱信息.ItemsSource = null;
                        表格医嘱信息.ItemsSource = drugData;
                    }
                }

            }
        }

        //退出程序
        private void 按钮退出图标_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (passstate == 1)
            {
                Pass.MDC_Quit();
            }
            Application.Current.Shutdown();
        }

        private void 菜单超量用药_Click(object sender, RoutedEventArgs e)
        {
            CleanData();
            输入姓名.Text = "石磊";
            选择性别.SelectedIndex = 0;
            输入出生日期.Text = DateTime.Now.AddYears(-45).ToString("yyyy-MM-dd"); 
            输入年龄.Text =  GetAgeByBirthdate(Convert.ToDateTime(输入出生日期.Text)).ToString();
            输入身高.Text = "180";
            输入体重.Text = "65";
            输入科室.Text = "外科";
            选择哺乳状态.SelectedIndex = -1;
            选择妊娠状态.SelectedIndex = -1;
            输入妊娠时间.Text = "0000-00-00";
            选择肝损状态.SelectedIndex = -1;
            选择肾损状态.SelectedIndex = -1;
            输入主管医生.Text = "张林";
            选择处方类型.SelectedIndex = 0;
            输入审查时间.Text = DateTime.Now.ToString("yyyy-MM-dd");
            输入病人编号.Text = "10001";
            输入住院号.Text = "0";
            输入会诊编号.Text = "1";
            drugData.Add(new DrugInfo()
            {   
                pcDrugUniqueCode = "115646",
                pcDrugName = "阿奇霉素片",
                pcDosePerTime="5000",
                pcDoseUnit = "mg",
                pcFrequency="1/3",
                pcNum = "15000",
                pcNumUnit = "mg",
                pcRouteCode = "1",
                pcRouteName = "口服",
                pcStartTime= DateTime.Now.ToString("yyyy-MM-dd"),
                pcEndTime = DateTime.Now.AddDays(10).ToString("yyyy-MM-dd")
        });
            drugData.Add(new DrugInfo()
            {
                pcDrugUniqueCode = "113215",
                pcDrugName = "盐酸左氧氟沙星注射液",
                pcDosePerTime = "760",
                pcDoseUnit = "mg",
                pcFrequency = "",
                pcNum = "760",
                pcNumUnit = "mg",
                pcRouteCode = "57",
                pcRouteName = "静脉滴注",
                pcStartTime = DateTime.Now.ToString("yyyy-MM-dd"),
                pcEndTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
            });
            drugData.RemoveAt(0);

        }

        private void 菜单儿童用药_Click(object sender, RoutedEventArgs e)
        {
            CleanData();
            输入姓名.Text = "米小明";
            选择性别.SelectedIndex = 0;
            输入出生日期.Text = DateTime.Now.AddYears(-10).ToString("yyyy-MM-dd"); 
            输入年龄.Text = GetAgeByBirthdate(Convert.ToDateTime(输入出生日期.Text)).ToString();
            输入身高.Text = "120";
            输入体重.Text = "34";
            输入科室.Text = "儿科";
            选择哺乳状态.SelectedIndex = -1;
            选择妊娠状态.SelectedIndex = -1;
            输入妊娠时间.Text = "0000-00-00";
            选择肝损状态.SelectedIndex = -1;
            选择肾损状态.SelectedIndex = -1;
            输入主管医生.Text = "李多雄";
            选择处方类型.SelectedIndex = 0;
            输入审查时间.Text = DateTime.Now.ToString("yyyy-MM-dd");
            输入病人编号.Text = "10002";
            输入住院号.Text = "0";
            输入会诊编号.Text = "1";

            drugData.Add(new DrugInfo()
            {
                pcDrugUniqueCode = "129561",
                pcDrugName = "注射用己酮可可碱",
                pcDoseUnit= "mg",
                pcRouteCode = "774",
                pcRouteName = "外周静脉滴注",
                pcStartTime = DateTime.Now.ToString("yyyy-MM-dd"),
                pcEndTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
            });
            drugData.RemoveAt(0);
        }

        private void 菜单妊娠用药_Click(object sender, RoutedEventArgs e)
        {
            CleanData();
            输入姓名.Text = "李琳";
            选择性别.SelectedIndex = 1;
            输入出生日期.Text = DateTime.Now.AddYears(-32).ToString("yyyy-MM-dd"); 
            输入年龄.Text = GetAgeByBirthdate(Convert.ToDateTime(输入出生日期.Text)).ToString();
            输入身高.Text = "165";
            输入体重.Text = "46";
            输入科室.Text = "妇产科";
            选择哺乳状态.SelectedIndex = -1;
            选择妊娠状态.SelectedIndex = 1;
            输入妊娠时间.Text = DateTime.Now.AddDays(-280).ToString("yyyy-MM-dd");
            选择肝损状态.SelectedIndex = -1;
            选择肾损状态.SelectedIndex = -1;
            输入主管医生.Text = "张莉莉";
            选择处方类型.SelectedIndex = 3;
            输入审查时间.Text = DateTime.Now.ToString("yyyy-MM-dd");
            输入病人编号.Text = "10003";
            输入住院号.Text = "100031";
            输入会诊编号.Text = "1";

            drugData.Add(new DrugInfo()
            {
                pcDrugUniqueCode = "4576",
                pcDrugName = "去羟肌苷分散片",
                pcDosePerTime = "50",
                pcDoseUnit = "mg",
                pcFrequency = "1/3",
                pcNum = "100",
                pcNumUnit = "mg",
                pcRouteCode = "129",
                pcRouteName = "分次口服",
                pcStartTime = DateTime.Now.ToString("yyyy-MM-dd"),
                pcEndTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
            });
            drugData.RemoveAt(0);
        }

        private void 菜单配伍浓度_Click(object sender, RoutedEventArgs e)
        {
            CleanData();
            输入姓名.Text = "张超";
            选择性别.SelectedIndex = 0;
            输入出生日期.Text = DateTime.Now.AddYears(-56).ToString("yyyy-MM-dd"); 
            输入年龄.Text = GetAgeByBirthdate(Convert.ToDateTime(输入出生日期.Text)).ToString();
            输入身高.Text = "175";
            输入体重.Text = "65";
            输入科室.Text = "肝胆肾科";
            选择哺乳状态.SelectedIndex = -1;
            选择妊娠状态.SelectedIndex = -1;
            输入妊娠时间.Text = "0000-00-00";
            选择肝损状态.SelectedIndex = -1;
            选择肾损状态.SelectedIndex = -1;
            输入主管医生.Text = "周国华";
            选择处方类型.SelectedIndex = 0;
            输入审查时间.Text = DateTime.Now.ToString("yyyy-MM-dd");
            输入病人编号.Text = "10004";
            输入住院号.Text = "0";
            输入会诊编号.Text = "1";
            drugData.Add(new DrugInfo()
            {
                pcGroupTag = "1",
                pcDrugUniqueCode = "156226",
                pcDrugName = "氨茶碱注射液",
                pcDosePerTime = "1000",
                pcDoseUnit = "mg",
                pcFrequency = "1/1",
                pcNum = "1000",
                pcNumUnit = "mg",
                pcRouteCode = "57",
                pcRouteName = "静脉滴注",
                pcStartTime = DateTime.Now.ToString("yyyy-MM-dd"),
                pcEndTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
            });
            drugData.Add(new DrugInfo()
            {
                pcGroupTag = "1",
                pcDrugUniqueCode = "118183",
                pcDrugName = "盐酸川芎嗪注射液",
                pcDosePerTime = "1000",
                pcDoseUnit = "mg",
                pcFrequency = "1/1",
                pcNum = "1000",
                pcNumUnit = "mg",
                pcRouteCode = "57",
                pcRouteName = "静脉滴注",
                pcStartTime = DateTime.Now.ToString("yyyy-MM-dd"),
                pcEndTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
            });
            drugData.RemoveAt(0);
        }
    }
}
