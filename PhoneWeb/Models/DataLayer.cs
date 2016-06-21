using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace PhoneWeb.Models
{
    public class DataLayer
    {
        public Employees GetEmployees()
        {
            Employees _emps = new Employees();
            using (OracleConnection connOra = new OracleConnection(@"Data Source=PROJ;Persist Security Info=True;User ID=PDM_MONITOR;Password=soft77;Unicode=True"))
            {
                using (OracleCommand cmdOra = new OracleCommand())
                {
                    cmdOra.CommandText = @"SELECT st.FAMILY,
                                                st.FIRST_NAME,
                                                st.FATHER_NAME,       
                                                st.WORK_TEL,
                                                st.N_KOMNATY,
                                                F_GET_BURO_NAME(st.KOD_BURO) as Buro_Name,
                                           F_GET_DIVISION_NAME(st.KOD_BURO) AS Division_Name
                                           FROM PDM_MONITOR.OGT_SHTAT st
                                           WHERE st.KOD_STATUSA != 1 AND st.KOD_STATUSA != 2
                                           ORDER by Division_Name, st.FAMILY, st.FIRST_NAME";
                    cmdOra.Connection = connOra;

                    connOra.Open();

                    using (OracleDataReader resultReader = cmdOra.ExecuteReader())
                    {
                        while (resultReader.Read())
                        {

                            var _room = resultReader["N_KOMNATY"] != DBNull.Value ? int.Parse(resultReader["N_KOMNATY"].ToString()) : 0;

                            _emps.AddEmployee(

                                name: resultReader["FIRST_NAME"].ToString(),
                                surname: resultReader["FAMILY"].ToString(),
                                patronymic: resultReader["FATHER_NAME"].ToString(),
                                phone: resultReader["WORK_TEL"].ToString(),
                                room: _room,
                                bureau: resultReader["Buro_Name"].ToString(),
                                division: resultReader["Division_Name"].ToString()

                                );
                        }
                        resultReader.Close();
                    }
                    connOra.Close();
                }
            }

            return _emps;
        }
    }
}