using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WEB.Query
{
    public class ResetarTabelasSQLQuery
    {
        public string CreateTableNCMQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("   CREATE TABLE TB_NCM_NCM(");
            sb.AppendLine("   NCMID int,");
            sb.AppendLine("   NCMCODIGO int,");
            sb.AppendLine("   NCMDESCRICAO varchar(30),");
            sb.AppendLine("   NCMSTATUS char(1)");
            sb.AppendLine("   PRIMARY KEY(NCMID))");

            return sb.ToString();
        }
        public string CreateTableCentroCustoQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    CREATE TABLE TB_CCU_CENTROCUSTO(");
            sb.AppendLine("   CCUID int,");
            sb.AppendLine("   CCUDESCRICAO varchar(60),");
            sb.AppendLine("   CCUSTATUS char(1)");
            sb.AppendLine("   PRIMARY KEY(CCUID))");

            return sb.ToString();
        }
        public string CreateTablePlanoContasQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("  CREATE TABLE TB_PCT_PLANOCONTAS(");
            sb.AppendLine(" PCTID int,");
            sb.AppendLine(" PCTDESCRICAO varchar(60),");
            sb.AppendLine(" PCTSTATUS char(1),");
            sb.AppendLine(" PCTTIPO char(1)");
            sb.AppendLine(" PRIMARY KEY(PCTID))");

            return sb.ToString();
        }
        public string CreateTableEmailQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("   CREATE TABLE TB_EML_EMAIL(");
            sb.AppendLine("  EMLID int,");
            sb.AppendLine("  PESID int,");
            sb.AppendLine("  EMLEMAIL VARCHAR(70),");
            sb.AppendLine("  PRIMARY KEY(EMLID),");
            sb.AppendLine("  FOREIGN KEY(PESID) REFERENCES TB_PES_PESSOA(PESID)) ");

            return sb.ToString();
        }
        public string CreateTableEnderecoQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    CREATE TABLE TB_EDN_ENDERECO(");
            sb.AppendLine("   EDNID int,");
            sb.AppendLine("   PESID int,");
            sb.AppendLine("   EDNCEP VARCHAR(9),");
            sb.AppendLine("   EDNUF CHAR(2),");
            sb.AppendLine("   EDNCIDADE VARCHAR(25),");
            sb.AppendLine("   EDNLOGRADOURO VARCHAR(25),");
            sb.AppendLine("   EDNBAIRRO VARCHAR(25),");
            sb.AppendLine("   EDNNUMERO CHAR(5),");
            sb.AppendLine("   EDNCOMPLEMENTO VARCHAR(30),");
            sb.AppendLine("   PRIMARY KEY(EDNID),");
            sb.AppendLine("   FOREIGN KEY(PESID) REFERENCES TB_PES_PESSOA(PESID)) ");

            return sb.ToString();
        }
        public string CreateTableFornecedorQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("           CREATE TABLE TB_FOR_FORNECEDOR(");
            sb.AppendLine("   FORID int,");
            sb.AppendLine("   PESID int,");
            sb.AppendLine("   CCUID int,");
            sb.AppendLine("   PCTID int,");
            sb.AppendLine("   FORSEQUENCIAL int,");
            sb.AppendLine("   FOROBSERVACAO varchar(250),");
            sb.AppendLine("   FORSITE varchar(70),");
            sb.AppendLine("   FORSTATUS char(1),");
            sb.AppendLine("   PRIMARY KEY(FORID),");
            sb.AppendLine("   FOREIGN KEY(PESID) REFERENCES TB_PES_PESSOA(PESID),");
            sb.AppendLine("   FOREIGN KEY(CCUID) REFERENCES TB_CCU_CENTROCUSTO(CCUID),");
            sb.AppendLine("   FOREIGN KEY(PCTID) REFERENCES TB_PCT_PLANOCONTAS(PCTID))  ");

            return sb.ToString();
        }
        public string CreateTablePrecoCustoQuery()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    CREATE TABLE TB_MPC_MATPRECOCUSTO(");
            sb.AppendLine("   MPCID int,");
            sb.AppendLine("   MATID int,");
            sb.AppendLine("   MPCPRECOCUSTO float,");
            sb.AppendLine("   MPCDTALTERACAO date,");
            sb.AppendLine("   PRIMARY KEY(MPCID),");
            sb.AppendLine("   FOREIGN KEY(MATID) REFERENCES TB_MAT_MATERIAL(MATID))");

            return sb.ToString();
        }
        public string CreateTablePrecoVendaQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    CREATE TABLE TB_MPV_MATPRECOVENDA(");
            sb.AppendLine("   MPVID int,");
            sb.AppendLine("   MATID int,");
            sb.AppendLine("   MPVPRECOVENDA float,");
            sb.AppendLine("   MPVMARKUP float,");
            sb.AppendLine("   MPVPRECOPROMO float,");
            sb.AppendLine("   MPVINICIOPROMO date,");
            sb.AppendLine("   MPVFIMPROMO date,");
            sb.AppendLine("   MPVDTALTERACAO date,");
            sb.AppendLine("   PRIMARY KEY(MPVID),");
            sb.AppendLine("   FOREIGN KEY(MATID) REFERENCES TB_MAT_MATERIAL(MATID))");

            return sb.ToString();
        }
        public string CreateTableTelefoneQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    CREATE TABLE TB_TEL_TELEFONE(");
            sb.AppendLine("   TELID int,");
            sb.AppendLine("   PESID int,");
            sb.AppendLine("   TELNUMERO VARCHAR(20),");
            sb.AppendLine("   TELDDD VARCHAR(3),");
            sb.AppendLine("   TELCELULAR VARCHAR(20),");
            sb.AppendLine("   TELDDDC VARCHAR(3),");
            sb.AppendLine("   PRIMARY KEY(TELID),");
            sb.AppendLine("   FOREIGN KEY(PESID) REFERENCES TB_PES_PESSOA(PESID))");

            return sb.ToString();
        }
        public string CreateTableVendedorQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    CREATE TABLE TB_VND_VENDEDOR(");
            sb.AppendLine("   VNDID int,");
            sb.AppendLine("   PESID int,");
            sb.AppendLine("   VNDSEQUENCIAL int,");
            sb.AppendLine("   VNDSTATUS char(1),");
            sb.AppendLine("   VNDNASCIMENTO date,");
            sb.AppendLine("   PRIMARY KEY(VNDID),");
            sb.AppendLine("   FOREIGN KEY(PESID) REFERENCES TB_PES_PESSOA(PESID)) ");

            return sb.ToString();
        }
        public string CreateTablePessoaQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    CREATE TABLE TB_PES_PESSOA(");
            sb.AppendLine("   PESID int,");
            sb.AppendLine("   PESNOME VARCHAR(40),");
            sb.AppendLine("   PESSOBRENOME VARCHAR(40),");
            sb.AppendLine("   PESDTCADASTRO DATE DEFAULT CONVERT(VARCHAR(10), GETDATE(), 103),");
            sb.AppendLine("   PESTIPO CHAR(1),");
            sb.AppendLine("   PESDOCESTADUAL VARCHAR(15),");
            sb.AppendLine("   PESDOCFEDERAL VARCHAR(15),");
            sb.AppendLine("   PRIMARY KEY(PESID))");

            return sb.ToString();
        }
        public string CreateTableTipoVendaQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CREATE TABLE TB_TPV_TIPOVENDA(");
            sb.AppendLine("TPVID int,");
            sb.AppendLine("TPVDESCRICAO varchar(30),");
            sb.AppendLine("TPVDEFAULTVENDA char(1)");
            sb.AppendLine("PRIMARY KEY(TPVID))");

            return sb.ToString();
        }
        public string CreateTableIndicacaoQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CREATE TABLE TB_IND_INDICACAO(");
            sb.AppendLine("INDID int,");
            sb.AppendLine("INDDESCRICAO varchar(40),");
            sb.AppendLine("INDDEFAULTVENDA char(1),");
            sb.AppendLine("INDSTATUS char(1)");
            sb.AppendLine("PRIMARY KEY(INDID))");

            return sb.ToString();
        }
        public string CreateTableParametroValorQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("   CREATE TABLE TB_PRV_PARAMETROVALOR( ");
            sb.AppendLine("   PRVID int IDENTITY(1, 1),");
            sb.AppendLine("   PRVVALOR int,");
            sb.AppendLine("   PRVCAMPO varchar(20),");
            sb.AppendLine("   PRIMARY KEY(PRVID))");

            return sb.ToString();


        }
        public string CreateTableMaterialQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    CREATE TABLE TB_MAT_MATERIAL(");
            sb.AppendLine("   MATID int,");
            sb.AppendLine("   NCMID int,");
            sb.AppendLine("   FORID int,");
            sb.AppendLine("   MATSEQUENCIAL int,");
            sb.AppendLine("   MATRECSOL char(1),");
            sb.AppendLine("   MATDESCRICAO varchar(60),");
            sb.AppendLine("   MATDESCRICAOECF varchar(60),");
            sb.AppendLine("   MATVENDA char(1),");
            sb.AppendLine("   MATFANTASIA varchar(60),");
            sb.AppendLine("   MATCONTROLAEST char(1),");
            sb.AppendLine("   MATDTCADASTRO date,");
            sb.AppendLine("   MATACEITANEGATIVO char(1),");
            sb.AppendLine("   PRIMARY KEY(MATID),");
            sb.AppendLine("   FOREIGN KEY(NCMID) REFERENCES TB_NCM_NCM(NCMID),");
            sb.AppendLine("   FOREIGN KEY(FORID) REFERENCES TB_FOR_FORNECEDOR(FORID))");


            return sb.ToString();
        }
        public string CreateTableAtributosQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("   CREATE TABLE TB_AAT_ATRIBUTOS(");
            sb.AppendLine("   AATID int,");
            sb.AppendLine("   MATID int,");
            sb.AppendLine("   ARLID INT,");
            sb.AppendLine("   ARCID INT,");
            sb.AppendLine("   ACNID INT,");
            sb.AppendLine("   ARMID INT,");
            sb.AppendLine("   ARGID INT,");
            sb.AppendLine("   AS1ID INT,");
            sb.AppendLine("   AS2ID INT,");
            sb.AppendLine("   ATOID INT,");
            sb.AppendLine("   ATPID INT,");
            sb.AppendLine("   PRIMARY KEY(AATID),");
            sb.AppendLine("   FOREIGN KEY(MATID) REFERENCES TB_MAT_MATERIAL(MATID),");
            sb.AppendLine("   FOREIGN KEY(ARLID) REFERENCES TB_ARL_ATRLINHAPROD(ARLID),");
            sb.AppendLine("   FOREIGN KEY(ARCID) REFERENCES TB_ARC_ATRCOR(ARCID),");
            sb.AppendLine("   FOREIGN KEY(ACNID) REFERENCES TB_ACN_ATRCORNUMERICA(ACNID),");
            sb.AppendLine("   FOREIGN KEY(ARMID) REFERENCES TB_ARM_ATRMODELO(ARMID),");
            sb.AppendLine("   FOREIGN KEY(ARGID) REFERENCES TB_ARG_ATRGRIFE(ARGID),");
            sb.AppendLine("   FOREIGN KEY(AS1ID) REFERENCES TB_AS1_ATRSUBLINHA1(AS1ID),");
            sb.AppendLine("   FOREIGN KEY(AS2ID) REFERENCES TB_AS2_ATRSUBLINHA2(AS2ID),");
            sb.AppendLine("   FOREIGN KEY(ATOID) REFERENCES TB_ATO_ATRTAMANHO(ATOID),");
            sb.AppendLine("   FOREIGN KEY(ATPID) REFERENCES TB_ATP_ATRGRUPO(ATPID))");


            return sb.ToString();
        }
        public string CreateTableAtributoLinhaQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    CREATE TABLE TB_ARL_ATRLINHAPROD( ");
            sb.AppendLine("   ARLID INT,");
            sb.AppendLine("   ARLDESCRICAO VARCHAR(30),");
            sb.AppendLine("   ARLSTATUS CHAR(1)");
            sb.AppendLine("   PRIMARY KEY(ARLID))");

            return sb.ToString();
        }
        public string CreateTableAtributoCorQuery()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    CREATE TABLE TB_ARC_ATRCOR( ");
            sb.AppendLine("   ARCID INT,");
            sb.AppendLine("   ARCDESCRICAO VARCHAR(30),");
            sb.AppendLine("   ARCSTATUS CHAR(1)");
            sb.AppendLine("   PRIMARY KEY(ARCID))");

            return sb.ToString();
        }
        public string CreateTableAtributoCorNumericaQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    CREATE TABLE TB_ACN_ATRCORNUMERICA(");
            sb.AppendLine("   ACNID INT,");
            sb.AppendLine("   ACNDESCRICAO VARCHAR(30),");
            sb.AppendLine("   ACNSTATUS CHAR(1),");
            sb.AppendLine("   PRIMARY KEY(ACNID))");

            return sb.ToString();
        }
        public string CreateTableAtributoModeloQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    CREATE TABLE TB_ARM_ATRMODELO(");
            sb.AppendLine("   ARMID INT,");
            sb.AppendLine("   ARMDESCRICAO VARCHAR(30),");
            sb.AppendLine("   ARMSTATUS CHAR(1)");
            sb.AppendLine("   PRIMARY KEY(ARMID))");

            return sb.ToString();
        }
        public string CreateTableAtributoGrifeQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    CREATE TABLE TB_ARG_ATRGRIFE (");
            sb.AppendLine("   ARGID INT,");
            sb.AppendLine("   ARGDESCRICAO VARCHAR(30),");
            sb.AppendLine("   ARGSTATUS CHAR(1)");
            sb.AppendLine("   PRIMARY KEY(ARGID))");

            return sb.ToString();
        }
        public string CreateTableAtributoSublinha1Query()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("   CREATE TABLE TB_AS1_ATRSUBLINHA1(");
            sb.AppendLine("   AS1ID INT,");
            sb.AppendLine("   AS1DESCRICAO VARCHAR(30),");
            sb.AppendLine("   AS1STATUS CHAR(1)");
            sb.AppendLine("   PRIMARY KEY(AS1ID))");

            return sb.ToString();
        }
        public string CreateTableAtributoSublinha2Query()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("   CREATE TABLE TB_AS2_ATRSUBLINHA2(");
            sb.AppendLine("   AS2ID INT,");
            sb.AppendLine("   AS2DESCRICAO VARCHAR(30),");
            sb.AppendLine("   AS2STATUS CHAR(1)");
            sb.AppendLine("   PRIMARY KEY(AS2ID))");

            return sb.ToString();
        }
        public string CreateTableAtributoTamanhoQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    CREATE TABLE TB_ATO_ATRTAMANHO(");
            sb.AppendLine("   ATOID INT,");
            sb.AppendLine("   ATODESCRICAO VARCHAR(30),");
            sb.AppendLine("   ATOSTATUS CHAR(1)");
            sb.AppendLine("   PRIMARY KEY(ATOID))");

            return sb.ToString();
        }
        public string CreateTableAtributoGrupoQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    CREATE TABLE TB_ATP_ATRGRUPO(");
            sb.AppendLine("   ATPID INT,");
            sb.AppendLine("   ATPDESCRICAO VARCHAR(30),");
            sb.AppendLine("   ATPSTATUS CHAR(1)");
            sb.AppendLine("   PRIMARY KEY(ATPID))");

            return sb.ToString();
        }
        public string CreateTableClienteQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    CREATE TABLE TB_CLI_CLIENTE(");
            sb.AppendLine("   CLIID int,");
            sb.AppendLine("   PESID int,");
            sb.AppendLine("   CLISALARIO float,");
            sb.AppendLine("   CLISTATUS char,");
            sb.AppendLine("   CLISEXO char,");
            sb.AppendLine("   CLIESTADOCIVIL char,");
            sb.AppendLine("   PRIMARY KEY(CLIID),");
            sb.AppendLine("   FOREIGN KEY(PESID) REFERENCES TB_PES_PESSOA(PESID),)");

            return sb.ToString();
        }
        public string CreateTableUsuarioQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    CREATE TABLE TB_USU_USUARIO(");
            sb.AppendLine("   USUID int,");
            sb.AppendLine("   PESID int,");
            sb.AppendLine("   USUSENHA varchar(30),");
            sb.AppendLine("   PRIMARY KEY(USUID),");
            sb.AppendLine("   FOREIGN KEY(PESID) REFERENCES TB_PES_PESSOA(PESID))");

            return sb.ToString();
        }
        public string CreateTableConvenio()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CREATE TABLE TB_CON_CONVENIO(");
            sb.AppendLine("   CONID int,");
            sb.AppendLine("   EDNID int,");
            sb.AppendLine("   TELID int,");
            sb.AppendLine("   CONEMPRESA varchar(70),");
            sb.AppendLine("   CONNUMCONTRATO varchar(15),");
            sb.AppendLine("   CONPERCDESCONTO int,");
            sb.AppendLine("   CONOBSERVACOES varchar(250),");
            sb.AppendLine("   PRIMARY KEY(CONID),");
            sb.AppendLine("   FOREIGN KEY(EDNID) REFERENCES TB_EDN_ENDERECO(EDNID),");
            sb.AppendLine("   FOREIGN KEY(TELID) REFERENCES TB_TEL_TELEFONE(TELID))");

            return sb.ToString();
        }
        public string InsertTableParametrosQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO TB_PRV_PARAMETROVALOR (PRVVALOR, PRVCAMPO) VALUES ('1000001', 'ARMACAO')");
            sb.AppendLine("INSERT INTO TB_PRV_PARAMETROVALOR (PRVVALOR, PRVCAMPO) VALUES ('1', 'VENDEDOR')");
            sb.AppendLine("INSERT INTO TB_PRV_PARAMETROVALOR (PRVVALOR, PRVCAMPO) VALUES ('1', 'CLIENTE')");
            sb.AppendLine("INSERT INTO TB_PRV_PARAMETROVALOR (PRVVALOR, PRVCAMPO) VALUES ('1', 'FORNECEDOR')");

            return sb.ToString();
        }
        public string InsertTablesNcmQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO TB_NCM_NCM (NCMID, NCMCODIGO, NCMDESCRICAO, NCMSTATUS) VALUES (NEXT VALUE FOR SEQ_NCM, 90031100, 'ARMACOES DE ACETATO/PLASTICO', 1);");
            sb.AppendLine("INSERT INTO TB_NCM_NCM (NCMID, NCMCODIGO, NCMDESCRICAO, NCMSTATUS) VALUES (NEXT VALUE FOR SEQ_NCM, 90031910, '	ARMACOES DE METAL', 1)");
            sb.AppendLine("INSERT INTO TB_NCM_NCM (NCMID, NCMCODIGO, NCMDESCRICAO, NCMSTATUS) VALUES (NEXT VALUE FOR SEQ_NCM, 90031990, 'ARMACOES DE OUTROS MATERIAIS', 1)");
            sb.AppendLine("INSERT INTO TB_NCM_NCM (NCMID, NCMCODIGO, NCMDESCRICAO, NCMSTATUS) VALUES (NEXT VALUE FOR SEQ_NCM, 90041000, 'OCULOS DE SOL', 1)");

            return sb.ToString();
        }
        public string InsertTablesCentroCustoQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO TB_CCU_CENTROCUSTO(CCUID, CCUDESCRICAO, CCUSTATUS) VALUES (NEXT VALUE FOR SEQ_CCU, 'LOJA', 1)");
            sb.AppendLine("INSERT INTO TB_CCU_CENTROCUSTO(CCUID, CCUDESCRICAO, CCUSTATUS) VALUES (NEXT VALUE FOR SEQ_CCU, 'ADMINISTRATIVO', 1)");
            sb.AppendLine("INSERT INTO TB_CCU_CENTROCUSTO(CCUID, CCUDESCRICAO, CCUSTATUS) VALUES (NEXT VALUE FOR SEQ_CCU, 'LABORATORIO', 1)");

            return sb.ToString();
        }
        public string InsertTablesPlanoContasQuery()
        {
            StringBuilder sb = new StringBuilder();

            //Despesas
            sb.AppendLine("INSERT INTO TB_PCT_PLANOCONTAS(PCTID, PCTDESCRICAO, PCTSTATUS, PCTTIPO) VALUES (NEXT VALUE FOR SEQ_PCT, 'DESPESA COM PUBLICIDADE', 1, 'D')");
            sb.AppendLine("INSERT INTO TB_PCT_PLANOCONTAS(PCTID, PCTDESCRICAO, PCTSTATUS, PCTTIPO) VALUES (NEXT VALUE FOR SEQ_PCT, 'IMPOSTOS E TAXAS', 1, 'D')");
            sb.AppendLine("INSERT INTO TB_PCT_PLANOCONTAS(PCTID, PCTDESCRICAO, PCTSTATUS, PCTTIPO) VALUES (NEXT VALUE FOR SEQ_PCT, 'MERCADORIAS E SERVICOS', 1, 'D')");
            sb.AppendLine("INSERT INTO TB_PCT_PLANOCONTAS(PCTID, PCTDESCRICAO, PCTSTATUS, PCTTIPO) VALUES (NEXT VALUE FOR SEQ_PCT, 'DESPESAS FINANCEIRAS/BANCARIAS', 1, 'D')");
            sb.AppendLine("INSERT INTO TB_PCT_PLANOCONTAS(PCTID, PCTDESCRICAO, PCTSTATUS, PCTTIPO) VALUES (NEXT VALUE FOR SEQ_PCT, 'DESPESAS COM FUNCIONARIOS', 1, 'D')");
            sb.AppendLine("INSERT INTO TB_PCT_PLANOCONTAS(PCTID, PCTDESCRICAO, PCTSTATUS, PCTTIPO) VALUES (NEXT VALUE FOR SEQ_PCT, 'PREST SERVICOS CONTABILIDADE', 1, 'D')");
            sb.AppendLine("INSERT INTO TB_PCT_PLANOCONTAS(PCTID, PCTDESCRICAO, PCTSTATUS, PCTTIPO) VALUES (NEXT VALUE FOR SEQ_PCT, 'DESPESAS COM ALUGUEL', 1, 'D')");
            sb.AppendLine("INSERT INTO TB_PCT_PLANOCONTAS(PCTID, PCTDESCRICAO, PCTSTATUS, PCTTIPO) VALUES (NEXT VALUE FOR SEQ_PCT, 'DESPESAS COM AGUA', 1, 'D')");
            sb.AppendLine("INSERT INTO TB_PCT_PLANOCONTAS(PCTID, PCTDESCRICAO, PCTSTATUS, PCTTIPO) VALUES (NEXT VALUE FOR SEQ_PCT, 'DESPESAS COM LUZ', 1, 'D')");


            //Receitas
            sb.AppendLine("INSERT INTO TB_PCT_PLANOCONTAS(PCTID, PCTDESCRICAO, PCTSTATUS, PCTTIPO) VALUES (NEXT VALUE FOR SEQ_PCT, 'VENDAS', 1, 'R')");
            sb.AppendLine("INSERT INTO TB_PCT_PLANOCONTAS(PCTID, PCTDESCRICAO, PCTSTATUS, PCTTIPO) VALUES (NEXT VALUE FOR SEQ_PCT, 'RECEBIMENTOS',1,'R')");
            sb.AppendLine("INSERT INTO TB_PCT_PLANOCONTAS(PCTID, PCTDESCRICAO, PCTSTATUS, PCTTIPO) VALUES (NEXT VALUE FOR SEQ_PCT, 'INCLUSAO CREDITO CLIENTE',1, 'R')");
            sb.AppendLine("INSERT INTO TB_PCT_PLANOCONTAS(PCTID, PCTDESCRICAO, PCTSTATUS, PCTTIPO) VALUES (NEXT VALUE FOR SEQ_PCT, 'TRANSFERENCIA DE CREDITO',1, 'R')");
            sb.AppendLine("INSERT INTO TB_PCT_PLANOCONTAS(PCTID, PCTDESCRICAO, PCTSTATUS, PCTTIPO) VALUES (NEXT VALUE FOR SEQ_PCT, 'RECEITAS',1, 'R')");

            return sb.ToString();
        }
        public string InsertTablesTipoVendaQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO TB_TPV_TIPOVENDA(TPVID, TPVDESCRICAO, TPVDEFAULTVENDA) VALUES(NEXT VALUE FOR SEQ_TPV, 'VENDA', '1')");
            sb.AppendLine("INSERT INTO TB_TPV_TIPOVENDA(TPVID, TPVDESCRICAO, TPVDEFAULTVENDA) VALUES(NEXT VALUE FOR SEQ_TPV, 'TROCA', '0')");
            sb.AppendLine("INSERT INTO TB_TPV_TIPOVENDA(TPVID, TPVDESCRICAO, TPVDEFAULTVENDA) VALUES(NEXT VALUE FOR SEQ_TPV, 'BRINDE/CORTERIA', '0') ");
            sb.AppendLine("INSERT INTO TB_TPV_TIPOVENDA(TPVID, TPVDESCRICAO, TPVDEFAULTVENDA) VALUES(NEXT VALUE FOR SEQ_TPV, 'GARANTIA', '0')");
            sb.AppendLine("INSERT INTO TB_TPV_TIPOVENDA(TPVID, TPVDESCRICAO, TPVDEFAULTVENDA) VALUES(NEXT VALUE FOR SEQ_TPV, 'ORCAMENTO', '0')");

            return sb.ToString();
        }
        public string InsertTablesIndicacaoQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO TB_IND_INDICACAO( INDID, INDDESCRICAO, INDDEFAULTVENDA, INDSTATUS) VALUES(NEXT VALUE FOR SEQ_IND, 'INDICACAO', '1', '1')");
            sb.AppendLine("INSERT INTO TB_IND_INDICACAO(INDID, INDDESCRICAO, INDDEFAULTVENDA, INDSTATUS) VALUES(NEXT VALUE FOR SEQ_IND, 'JA CLIENTE', '0', '1')");
            sb.AppendLine("INSERT INTO TB_IND_INDICACAO(INDID, INDDESCRICAO, INDDEFAULTVENDA, INDSTATUS) VALUES(NEXT VALUE FOR SEQ_IND, 'CONVENIOS', '0', '1') ");
            sb.AppendLine("INSERT INTO TB_IND_INDICACAO(INDID, INDDESCRICAO, INDDEFAULTVENDA, INDSTATUS) VALUES(NEXT VALUE FOR SEQ_IND, 'REDES SOCIAIS', '0', '1')");
            sb.AppendLine("INSERT INTO TB_IND_INDICACAO(INDID, INDDESCRICAO, INDDEFAULTVENDA, INDSTATUS) VALUES(NEXT VALUE FOR SEQ_IND, 'PANFLETAGEM', '0', '1')");

            return sb.ToString();
        }
    }
}

