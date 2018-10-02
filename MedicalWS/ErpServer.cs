using Model;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class ErpServer
    {
        public static string ConnectionString = ConfigurationManager.AppSettings["MName"].ToString();
        // @"Data Source=.;User Id='sa';Password='yangyunping1991';Initial Catalog='ERP'";

        protected const int ExecuteTimeout = 60;

        /// <summary>
        /// 测试连接是否成功
        /// </summary>
        /// <returns>成功返回true，否则false</returns>
        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 执行不返回结果的sql语句
        /// </summary>
        /// <param name="sqlText"></param>
        /// <returns></returns>
        protected static int ExecuteNonQuery(string sqlText)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand sqlcommand = connection.CreateCommand();
                sqlcommand.CommandText = sqlText;
                sqlcommand.CommandTimeout = ExecuteTimeout;
                return sqlcommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 执行返回一行的sql语句
        /// </summary>
        /// <param name="sqlText"></param>
        /// <returns></returns>
        protected static object ExecuteScalar(string sqlText)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand sqlcommand = connection.CreateCommand();
                sqlcommand.CommandText = sqlText;
                sqlcommand.CommandTimeout = ExecuteTimeout;
                return sqlcommand.ExecuteScalar();
            }
        }

        /// <summary>
        /// 执行返回结果的sql语句
        /// </summary>
        /// <param name="sqlText"></param>
        /// <returns></returns>
        protected static DataSet ExecuteQuery(string sqlText)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand sqlcommand = connection.CreateCommand();
                    sqlcommand.CommandText = sqlText;
                    sqlcommand.CommandTimeout = ExecuteTimeout;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcommand);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, @"result");
                    return ds;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取登录员工信息
        /// </summary>
        /// <param name="strEmp"></param>
        /// <returns></returns>
        public static DataSet GetEmployeeInfo(string strEmp)
        {
            string sql = $@"select * from Doctor dc left join Config c on c.SignID = dc.DocDutyID  where IsDelete = 0  {strEmp}";
            return ExecuteQuery(sql);
        }

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public static DataSet GetConfigInfo(int typeID)
        {
            string sql = $@"select * from View_Config where TypeID = '{typeID}'";
            return ExecuteQuery(sql);
        }

        /// <summary>
        /// 获取员工权限
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public static DataSet GetEmpPower(string empId)
        {
            string sql = $@"select * from EmpPower where DocID = '{empId}'";
            return ExecuteQuery(sql);
        }

        /// <summary>
        /// 创建员工信息和权限
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="empName"></param>
        /// <param name="passWord"></param>
        /// <param name="sex"></param>
        /// <param name="age"></param>
        /// <param name="telPhone"></param>
        /// <param name="dutyId"></param>
        /// <param name="powerIdlList"></param>
        /// <returns></returns>
        public static bool InsertEmpInfo(string empId, string empName, string passWord, string sex, string age,
            string telPhone, string dutyId, List<string> powerIdlList)
        {
            string sql =
                $@"
if not Exists(select * from Doctor where DocID = '{empId}')
Begin
insert into Doctor(DocID,DocName,DocPassword,DocSex,DocAge,DocTel,DocDutyID) 
values('{empId}','{empName}','{passWord}','{sex}','{age}','{telPhone}','{dutyId}')
End
Else
Begin
update Doctor set DocName = '{empName}',DocPassword = '{passWord}',
DocSex = '{sex}',DocAge = '{age}',DocTel = '{telPhone}',DocDutyID = '{dutyId }' where  DocID = '{empId}'
End";
            sql = powerIdlList.Aggregate(sql, (current, powerId) => current + $@"  insert into EmpPower(PowerID,DocID) values('{powerId}','{empId}')");
            return ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public static bool DeletePower(string empId)
        {
            string sql = $@"delete from EmpPower where DocID = '{empId}'";
            return ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 获取进货药品详细信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="styleName"></param>
        /// <returns></returns>
        public static DataSet GetMedInfo(string key, string styleName)
        {
            string sql = $@"  
  declare @StyleID varchar(20)
  select  @StyleID = SignID from Config where  Name = '{styleName}'
  select ms.MedID,m.MedBarCode,MedName,MedUnit,MedStandard,MedApproval,MedSpellFirst,Memary,MedTypeID,MedBid,MedUnitPrice,Quantity,ProduteDate,ReleaseDay,Name as StyleName 
  from InMed m
  left join Medicine ms on ms.MedID = m.MedID
  left join Config c on c.SignID = ms.MedTypeID  where  c.StyleID = @StyleID  {key} order by ms.MedID";
            return ExecuteQuery(sql);
        }
        /// <summary>
        /// 获取进货药品信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static DataSet GetMedcine(string key)
        {
            string sql = $@"  
  select MedID,MedName,MedUnit,MedStandard,MedApproval,MedSpellFirst,MedTypeID,c.Name as StyleName from Medicine m
  left join Config c on c.SignID = m.MedTypeID  where  1=1  {key} order by MedID";
            return ExecuteQuery(sql);
        }

        /// <summary>
        /// 药品创建和修改
        /// </summary>
        /// <param name="medId"></param>
        /// <param name="medName"></param>
        /// <param name="medStandard"></param>
        /// <param name="medUnit"></param>
        /// <param name="medTypeId"></param>
        /// <param name="medApproval"></param>
        /// <param name="medSpellFirst"></param>
        /// <returns></returns>
        public static bool InsertMedicine(Medicine medicine)
        {
            string sql =
                $@"
  if not exists(select * from Medicine where MedID ='{medicine.MedId}')
  Begin
  insert into Medicine(MedName,MedTypeID,MedUnit,MedStandard,MedApproval,MedSpellFirst,IsDelete) 
  values('{ medicine.MedName}','{medicine.MedTypeId}','{medicine.MedUnit}','{medicine.MedStandard}','{medicine.MedApproval}','{medicine.MedSpellFirst}','0')
  End
  else
  Begin
  update Medicine set  MedName = '{medicine.MedName}',MedTypeID = '{medicine.MedTypeId }',MedUnit = '{medicine.MedUnit}',MedStandard = '{medicine.MedStandard}',
  MedApproval = '{medicine.MedApproval}',MedSpellFirst = '{medicine.MedSpellFirst}'  where  MedID = '{medicine.MedId}'
  End";
            return ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 删除药品
        /// </summary>
        /// <param name="medNum"></param>
        /// <returns></returns>
        public static bool DeleteMedicine(string medNum)
        {
            string sql = $@"delete from Medicine where MedID = '{medNum}'";
            return ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 药品入库
        /// </summary>
        /// <param name="medId"></param>
        /// <param name="medName"></param>
        /// <param name="medbarcode"></param>
        /// <param name="proction"></param>
        /// <param name="prodateTime"></param>
        /// <param name="expirationTime"></param>
        /// <param name="releaseDay"></param>
        /// <param name="sum"></param>
        /// <param name="bid"></param>
        /// <param name="price"></param>
        /// <param name="memary"></param>
        /// <param name="empId"></param> 
        /// <returns></returns>
        public static bool InsertInMed(AddMedicine addMedicine)
        {
            string sql =$@"if  not exists (select * from InMed where MedID = '{addMedicine.MedID}' and MedBarCode = '{addMedicine.MedBarCode}')
Begin
insert into InMed(MedID, MedBarCode, Production, InDate, ProduteDate, DueDate, ReleaseDay, Quantity, MedBid, MedUnitPrice, Memary) values('{addMedicine.MedID}','{addMedicine.MedBarCode}','{addMedicine.Production}',GETDATE(),'{addMedicine.ProduteDate}','{addMedicine.DueDate}','{addMedicine.ReleaseDay}','{addMedicine.Quantity}','{addMedicine.MedBid}','{addMedicine.MedUnitPrice}','{addMedicine.Memary}')
Insert into MedLog(OperType,Notes,OperateTime,OperateEmpID)
values('药品进货','编号:{addMedicine.MedID},名称:{addMedicine.MedName},条码:{addMedicine.MedBarCode},数量:{addMedicine.Quantity},进价:{addMedicine.MedBid},售价:{addMedicine.MedUnitPrice},保质期:{addMedicine.ReleaseDay},备注:{addMedicine.Memary}',GETDATE(),'{Information.CurrentUser.Id}')
End
else
Begin
Update InMed set Production= '{addMedicine.Production}',ProduteDate = '{addMedicine.ProduteDate}',DueDate = '{addMedicine.DueDate}', ReleaseDay = '{addMedicine.ReleaseDay}',Quantity = '{addMedicine.Quantity}',MedBid = '{addMedicine.MedBid}',MedUnitPrice = '{addMedicine.MedUnitPrice}',Memary = '{addMedicine.Memary}' where MedID = '{addMedicine.MedID}' and MedBarCode = '{addMedicine.MedBarCode}'
Insert into MedLog(OperType,Notes,OperateTime,OperateEmpID)
values('库存修改','编号:{addMedicine.MedID},名称:{addMedicine.MedName},条码:{addMedicine.MedBarCode},数量:{addMedicine.Quantity},进价:{addMedicine.MedBid},售价:{addMedicine.MedUnitPrice},保质期:{addMedicine.ReleaseDay},备注:{addMedicine.Memary}',GETDATE(),'{Information.CurrentUser.Id}')
End";
            return ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 获取进货信息
        /// </summary>
        /// <param name="sSql"></param>
        /// <returns></returns>
        public static DataSet GetInMedDataSet(string sSql)
        {
            string sql =
 $@"  select i.MedID,MedName,i.MedBarCode,Production,InDate,ProduteDate,DueDate,ReleaseDay,Quantity,MedBid,MedUnitPrice,Memary,MedUnit,MedStandard,MedStandard,MedTypeID,
  Name as StyleName,MedApproval,MedSpellFirst
  from InMed i
  left join Medicine m on m.MedID = i.MedID
  left join Config c on c.SignID = m.MedTypeID where 1=1  {sSql} order by Quantity";
            return ExecuteQuery(sql);
        }
        /// <summary>
        /// 病人信息录入
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="medLog"></param>
        /// <returns></returns>
        public static bool InsertPation(Patient patient, MedLog medLog)
        {
            string sql =
                $@"
IF not exists(select * from Patient where ID = '{patient.PatID}')
Begin
Insert into Patient(PatName,Age,Gender,TelPhone,Addresses) values('{patient.PatName}','{patient.Age}','{patient.Gender}','{ patient.TelPhone}','{patient.Addresses}')
insert into MedLog(OperType,Notes,OperateTime,OperateEmpID) values('{ medLog.OperType}','{medLog.Notes}',GETDATE(),'{medLog.OperateEmpID}')
End
ElSE
Begin
Update Patient set Age = '{patient.Age}', PatName = '{patient.PatName}',Addresses = '{patient.Addresses}',Gender = '{patient.Gender}',TelPhone ={ patient.TelPhone},Addresses = '{patient.Addresses}'  where ID = '{patient.PatID}'
End ";
            return ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 保存门诊药品信息
        /// </summary>
        /// <param name="medList">药品详情</param> medId0, medBarCode1 medName2, timesUse3, MedUnitPrice4, price5, useAge6, Frequency7, days8 ,oneTimeUse9
        /// <param name="empId"></param>
        /// <param name="age"></param>病人年龄
        /// <param name="allPrice">总价钱</param>
        /// <param name="allBidCost">总成本</param>
        /// <param name="diagnosis">临床诊断</param>
        /// <param name="pationtName">病人姓名</param>
        /// <param name="operatetype">操作类型</param>
        /// <param name="pastHistory"></param>
        /// <returns></returns>
        public static bool SavePrescriptionInfo(List<List<string>> medList, string empId, string age, decimal allPrice, decimal allBidCost, string diagnosis, string pationtName, string operatetype,string pastHistory)
        {
            string sql = $@"
declare  @PatID int
select   @PatID= PatID from Patient where PatName = '{pationtName}' and  age = '{age}'
insert into Prescription(DoctorID,PatID,Diagnosis,PastHistory,MedCost,MedPrice,CreateDate) values('{empId}', @PatID,'{diagnosis}','{pastHistory}','{allBidCost}','{allPrice}',GETDATE())
insert into MedLog(OperType,Notes,OperateTime,OperateEmpID) values('{operatetype}','医生:{empId} 病人:{pationtName} 费用:{allPrice}  症状:{diagnosis}',GETDATE(),'{empId}')";
            foreach (List<string> medlst in medList)
            {
                sql += $@" 
insert into OutMed(MedID,MedBarCode,MedName,TimesUse,LookDate,DoctorID,PatID,MedUnitPrice,MedPrice,Useage,Frequency,Days,OneTimeUse,SpliteNum) values('{medlst[0]}','{medlst[1]}','{medlst[2]}','{medlst[3]}',GETDATE(),'{empId}',@PatID,'{medlst[4]}','{medlst[5]}','{medlst[6]}','{medlst[7]}','{medlst[8]}','{medlst[9]}','{medlst[10]}')
update InMed set Quantity = Quantity -{medlst[3]} where MedID = '{medlst[0]}'and MedBarCode = '{medlst[1]}'";
            }
            return ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 辅助检查
        /// </summary>
        /// <param name="checkList"></param>
        /// <param name="empId"></param>
        /// <param name="age"></param>
        /// <param name="pationtName"></param>
        /// <returns></returns>
        public static bool SaveCheckInfo(List<List<string>> checkList, string empId, string age,string pationtName)
        {
            string sql = $@"
declare  @PatID int
select   @PatID= PatID from Patient where PatName = '{pationtName}' and  age = '{age}'";
            foreach (List<string> checklst in checkList)
            {
                sql += $@"
Insert into Examination(CheckID,CheckName,DoctorID,PatID,CheckPrice,CheckDate) values('{checklst[0]}','{checklst[1]}','{empId}',@PatID ,'{checklst[2]}',GETDATE())";
            }
            return ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 查询病人信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static DataSet GetPationes(string key)
        {
            string sSql = $@"select * from Patient where 1=1 {key}";
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 问诊量
        /// </summary>
        /// <param name="sStr"></param>
        /// <returns></returns>
        public static DataSet GetPrescription(string sStr)
        {
            string sSql = $@"  select ID,p.PatID,PatName,Diagnosis,PastHistory,DocID,DocName,MedCost,MedPrice,CreateDate from Prescription p 
  left join Doctor d on d.DocID = p.DoctorID
  left join Patient pt on pt.PatID =p.PatID
  where  1=1 {sStr} ";
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 查询药品出库详情
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static DataSet GetMedOutInfo(string strSql)
        {
            string sSql = $@" select om.ID,om.MedID,om.SpliteNum,MedBarCode,om.MedName,m.MedSpellFirst,om.TimesUse,c.SignID,c.Name as MedStyle,MedUnit,MedStandard,MedSpellFirst,DocID,DocName,p.PatID, PatName,MedUnitPrice,MedPrice,LookDate,Useage,Frequency,OneTimeUse,Days,TimesUse from  OutMed  om
  left join Medicine m on m.MedID = om.MedID
  left join Doctor d on d.DocID = om.DoctorID
  left join Patient p on p.PatID = om.PatID
  left join Config c on c.SignID = m.MedTypeID
  where 1=1 {strSql}";
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="newPass"></param>
        /// <param name="empId"></param>
        /// <returns></returns>
        public static bool UpdatePassWord(string newPass, string empId)
        {
            string sSql = $@" update Doctor set DocPassword = '{newPass}' where DocID = '{empId}'";
            return ExecuteNonQuery(sSql) > 0;
        }
        /// <summary>
        /// 入库记录
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public static DataSet GetMedBuyInfo(string dateString)
        {
            string sSql = $@" select * from MedLog m
  left join Doctor d on d.DocID = OperateEmpID where 1=1 {dateString}";
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 获取类别 大类别-10000
        /// </summary>
        /// <returns></returns>
        public static DataSet GetConfigStyleInfo()
        {
            string sSql = @"select * from Config where StyleID = '10000'";
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 保存添加的类别内容
        /// </summary>
        /// <param name="name"></param>
        /// <param name="styleId"></param>
        /// <returns></returns>
        public static bool AddConfig(string name, string styleId)
        {
            string sSql = $@"insert into Config(name,styleID) values('{name}','{styleId}')";
            return ExecuteNonQuery(sSql) > 0;
        }
      /// <summary>
      /// 修改配置
      /// </summary>
      /// <param name="signId"></param>
      /// <param name="signName"></param>
      /// <returns></returns>
        public static bool ModifyConfig(string signId, string signName)
        {
            string sSql = $@"  Update Config set Name = '{signName}' where SignID = '{signId}'";
            return ExecuteNonQuery(sSql) > 0;
        }
        /// <summary>
        /// 删除类别内容
        /// </summary>
        /// <param name="name"></param>
        /// <param name="signId"></param>
        /// <param name="empId"></param>
        /// <returns></returns>
        public static bool DeleteConfig(string name, string signId, string empId)
        {
            string sSql = $@"  Delete from Config where SignID = '{signId}' and  Name = '{name}'
                 insert into MedLog(OperType,Notes,OperateTime,OperateEmpID) values('删除设置','{signId} {name}',GETDATE(),'{empId}')";
            return ExecuteNonQuery(sSql) > 1;
        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public static bool DeleteEmp(string empId)
        {
            string sSql = $@" 
  Delete from EmpPower where DocID = '{empId}'
  Update Doctor set IsDelete = 1  where DocID = '{empId}'";
            return ExecuteNonQuery(sSql) > 1;
        }
        /// <summary>
        /// 保存方案
        /// </summary>
        /// <param name="medList"></param>
        /// <param name="pationtName"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        public static bool InsertMedPlan(List<List<string>> medList,string pationtName, string age)
        {
            string sql = $@"declare  @PatID varchar(20), @SignID varchar(20)
select  @PatID= PatID from Patient where PatName = '{pationtName}' and  age = '{age}'
select  @SignID = ISNULL(MAX(SignID),0) + 1  from MedPlan";
            foreach (List<string> medlst in medList)
            {
                sql += $@"
Insert into MedPlan(MedID,DoctorID,PatID,Useage,Frequency,OneTimeUse,Days,TimesUse,CreateDate,SignID,StyleName,SpliteNum) values('{medlst[0]}','{medlst[1]}',@PatID,'{medlst[2]}',
'{medlst[3]}','{medlst[4]}','{medlst[5]}','{medlst[6]}',GETDATE(),@SignID,'{medlst[7]}','{medlst[8]}')
insert into MedLog(OperType,Notes,OperateTime,OperateEmpID) values('保存方案','医生ID:{medlst[1]} 病人ID:'+@PatID,GETDATE(),'{medlst[1]}')";
            }
            return ExecuteNonQuery(sql) > 0;
        }
        /// <summary>
        /// 方案查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetMedPlans(string sql)
        {
            string sSql = $@"
 select a.ID,a.MedID,a.Frequency,a.TimesUse,a.Days,a.OneTimeUse,a.TimesUse,a.Useage,a.StyleName,a.SignID,a.SpliteNum, 
b.DocName,c.PatName,d.MedApproval,d.MedID,d.MedName,d.MedStandard,d.MedTypeID,d.MedUnit,d.MedSpellFirst,e.Name  as MedStyle from( select  ROW_NUMBER() OVER(partition by SignId
order by id) as newRow,*  from MedPlan where IsDelete = 0) as a 
 left join Doctor b on b.DocID = a.DoctorID
 left join Patient c on c.PatID = a.PatID
 left join Medicine d on d.MedID = a.MedID
 left join Config e on e.SignID = d.MedTypeID 
 where 1=1 {sql}";
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 删除整个方案
        /// </summary>
        /// <param name="signId"></param>
        /// <returns></returns>
        public static bool DeletePlan(string signId)
        {
            string sSql = $@" Update MedPlan set IsDelete = 1 where SignID = '{signId}' ";
            return ExecuteNonQuery(sSql) > 0;
        }
        /// <summary>
        /// 删除方案药品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeletePlanMed(string id)
        {
            string sSql = $@"Update MedPlan set IsDelete = 1 where ID = '{id}'";
            return ExecuteNonQuery(sSql) > 0;
        }
        /// <summary>
        /// 辅助检查
        /// </summary>
        /// <param name="checkId"></param>
        /// <param name="checkName"></param>
        /// <param name="checkPrice"></param>
        /// <returns></returns>
        public static bool AddExamine(string checkId,string  checkName, decimal checkPrice)
        {
            string sSql = $@"
IF NOT EXISTS(Select * from ExaminePrice where CheckID = '{checkId}')
Begin
Insert into ExaminePrice(CheckID,CheckName,CheckPrice) values('{checkId}','{checkName}','{checkPrice}')
End
ElSE
Begin
Update ExaminePrice set CheckName = '{checkName}',CheckPrice = '{checkPrice}'  where CheckID = '{checkId}'
End 
";
            return ExecuteNonQuery(sSql) > 0;
        }
        /// <summary>
        /// 获取检查费用
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetExamineInfo(string sql)
        {
            string sSql = $@" Select * from ExaminePrice where 1=1 {sql}";
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 获取添加到治疗单的信息
        /// </summary>
        /// <returns></returns>
        public static object GetTreatmentInfo()
        {
            string sSql = @"select SignName + ',' from Treatment for xml path('')";
            return ExecuteScalar(sSql);
        }
        /// <summary>
        /// 删除整个方案
        /// </summary>
        /// <param name="signId"></param>
        /// <returns></returns>
        public static bool AddTreatment(Dictionary<string,string> sign)
        {
            string sSql = string.Empty;
            for (int i = 0; i < sign.Count; i++)
            {
                sSql += $@" 
IF NOT EXISTS(Select * from Treatment where SignID = '{sign.Keys.ToArray()[i]}')
BEGIN
Insert into Treatment(SignID,SignName) values('{sign.Keys.ToArray()[i]}','{sign.Values.ToArray()[i]}')
END";
            }
            return ExecuteNonQuery(sSql) > 0;
        }
        /// <summary>
        /// 删除整个方案
        /// </summary>
        /// <param name="signId"></param>
        /// <returns></returns>
        public static bool DeleteTreatment(List<string> signId)
        {
            string sSql = string.Empty;
            for (int i = 0; i < signId.Count; i++)
            {
                sSql += $@" 
Delete from Treatment where  SignID = '{signId[i]}' ";
            }
            return ExecuteNonQuery(sSql) > 0;
        }
    }
}
