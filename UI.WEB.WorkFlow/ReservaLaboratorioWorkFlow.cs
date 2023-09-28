using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.WEB.Model;
using UI.WEB.WorkFlow.Outros;

namespace UI.WEB.WorkFlow
{
    public class ReservaLaboratorioWorkFlow : BaseWeb
    {
        DBComando db = new DBComando();
        public ReservaLaboratorioEntity RetornaObjInclusao()
        {
            ReservaLaboratorioEntity _obj = new ReservaLaboratorioEntity();

            return _obj;
        }

        public List<LaboratorioEntity> listaLaboratorios()
        {
            List<LaboratorioEntity> lista = new List<LaboratorioEntity>();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" SELECT                       ");
            sb.AppendLine("    LABID,                    ");
            sb.AppendLine("    LABDESCRICAO              ");
            sb.AppendLine(" FROM TB_LAB_LABORATORIO LAB  ");


            SqlDataReader dr = ListarDadosEntity(sb.ToString());


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    LaboratorioEntity _Laboratorio = new LaboratorioEntity();

                    _Laboratorio.LABID = int.Parse(dr["LABID"].ToString());
                    _Laboratorio.LABDESCRICAO = dr["LABDESCRICAO"].ToString();

                    lista.Add(_Laboratorio);
                }
            }

            return lista;
        }

        public string GravarReservaLaboratorio(ReservaLaboratorioEntity _ReservaLaboratorio)
        {
            string sRetorno = "NOTOK";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" SELECT                                                                                   ");
            sb.AppendLine("     *                                                                                    ");
            sb.AppendLine(" FROM TB_REL_RESERVALABORATORIO REL                                                       ");
            sb.AppendLine(" WHERE REL.RELDATA = @RELDATA and REL.LABID = @LABID and REL.RELHORARIO = @RELHORARIO     ");

            SqlCommand _Comando = new SqlCommand(sb.ToString(), db.MinhaConexao());

            SqlParameter parameterRELDATA = new SqlParameter("@RELDATA", _ReservaLaboratorio.RELDATA);
            SqlParameter parameterLABID = new SqlParameter("@LABID", _ReservaLaboratorio.LABID);
            SqlParameter parameterRELHORARIO = new SqlParameter("@RELHORARIO", _ReservaLaboratorio.RELHORARIO);

            _Comando.Parameters.Add(parameterRELDATA);
            _Comando.Parameters.Add(parameterLABID);
            _Comando.Parameters.Add(parameterRELHORARIO);

            _Comando.CommandType = CommandType.Text;
            SqlDataReader dr = _Comando.ExecuteReader();

            if (dr.HasRows)
            {
                sRetorno = "Não foi possível fazer a reserva, por favor tenta mais tarde.";
            }
            else
            {

                _ReservaLaboratorio.RELDATA = DateTime.ParseExact(_ReservaLaboratorio.RELDATA, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("dd-MM-yyyy");

                AddListaSalvar(_ReservaLaboratorio);

                sRetorno = ExecuteTransacao();
            }

            if (sRetorno == "OK")
            {
                sRetorno = "approved";
            }
            else
            {
                sRetorno = "Não foi possível fazer a reserva, por favor tenta mais tarde.";
            }

            return sRetorno;
        }
    }
}
