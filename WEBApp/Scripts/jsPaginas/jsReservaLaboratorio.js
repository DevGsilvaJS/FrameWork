oTabLaboratorio = null;
_ReservaLaboratorio = null;
IDPRINCIPAL = null;
$(document).ready(function () {
    jQueryInit();
});

function jQueryInit() {
    fnCriaTela();
}

function fnCriaTela() {

    oTabLaboratorio = $("#tbLaboratorio").DataTable({
        "oLanguage": {
            "sProcessing": "Aguarde enquanto os dados são carregados ...",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sPaginationType": "bootstrap",
            "sZeroRecords": "Nenhum registro correspondente ao critério encontrado",
            "sInfoEmpty": "Exibindo 0 a 0 de 0 registros",
            "sInfo": "Exibindo de _START_ a _END_ de _TOTAL_ registros",
            "sInfoFiltered": "",
            "sSearch": "Procurar",
            "oPaginate": {
                "sFirst": "Primeiro",
                "sPrevious": "Anterior",
                "sNext": "Próximo",
                "sLast": "Último"
            }
        },

        "iDisplayLength": 50,
        "aLengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
        "bRetrieve": false,
        "bFilter": true,
        "bSortClasses": true,
        "bLengthChange": false,
        "bPaginate": true,
        "bInfo": true,
        "bJQueryUI": false,
        "bAutoWidth": false,
        "aaSorting": [[1, "asc"]],
        "aoColumns": [
            { sWidth: '13%', "bSortable": false },
            { sWidth: '30%' },//Numero          
            { sWidth: '30%' },//Titulo
            { sWidth: '20%' },//Titulo
        ]
    });

    fnListaDados();
    lsLaboratorios();

}

function fnRetornaObjInclusao() {

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "Laboratorio/RetornaObjInclusao",
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {

        },
        success: function (result) {

            debugger;
            _ReservaLaboratorio = result.ObjInclusao;

        },
        error: function (jqXHR, exception) {
        },
        complete: function () {
        }
    });

}

$(document).ready(function () {
    $('.nav-tabs a').on('click', function (e) {
        e.preventDefault();
        $(this).tab('show');
    });
});

$(document).ready(function () {
    $('#btnSalvarFormulario').on('click', function () {

        switch (STATUS) {
            case 'INSERCAO':
                fnSalvarDados();
                break;
            case 'ALTERACAO':
                fnSalvarDados();
                $("#aLista").tab('show');
                fnListaDados();
                break;
            default:
                break;
        }
    });
});

$(document).ready(function () {
    // Seletor para o campo de entrada com ID "txtDocFederalLaboratorio"
    $("#txtDocFederalLaboratorio").on("blur", function () {

    });
});

$(document).ready(function () {
    // Quando o valor do select for alterado
    $("#ddlTipoLaboratorio").on("change", function () {
        var selectedValue = $(this).val();

        // Mostra a label correspondente com base na seleção
        if (selectedValue === "0") {

            $("#lblCNPJLaboratorio").css("display", "none");
            $("#txtDocFederalAdmin").css("display", "none");
            $("#lblCpfLaboratorio").css("display", "block");
            $("#txtDocFederalLaboratorio").css("display", "block");


        } else if (selectedValue === "1") {

            $("#lblCpfLaboratorio").css("display", "none");
            $("#txtDocFederalLaboratorio").css("display", "none");
            $("#lblCNPJLaboratorio").css("display", "block");
            $("#txtDocFederalAdmin").css("display", "block");


        }
    });
});

$("#aLista").click(function () {
    $("#btnSalvarFormulario").css('display', 'none');
})

$("#aCadastro").click(function () {
    STATUS = 'INSERCAO';
    $("#btnSalvarFormulario").css('display', 'block');
    fnRetornaObjInclusao();
});

$("#btnBuscarCep").click(function () {
    buscaCep($("#txtValorCep").val());
})

function fnSalvarDados() {

    debugger;

    _ReservaLaboratorio.LABID = $("#ddlLaboratorio").val();
    _ReservaLaboratorio.RELDATA = $("#dtReservaLaboratorio").val();
    _ReservaLaboratorio.RELHORARIO = $("#ddlHorarioReserva").val();


    if (_ReservaLaboratorio.LABID == "" || _ReservaLaboratorio.RELDATA == "" || _ReservaLaboratorio.RELHORARIO == "") {
        alert('Preencha todos campos para prosseguir!');
        return false;
    }

    $.ajax({

        type: "POST",
        contentType: "application/json",
        url: "ReservaLaboratorio/GravarReservaLaboratorio",
        data: JSON.stringify(_ReservaLaboratorio),
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {

        },
        success: function (result) {
            debugger;


            switch (result.retorno) {
                case "LAB":
                    alert('Já existe um laboratório cadastrado neste andar!');
                    break;
                case "OK":
                    $("#aLista").tab('show');
                    fnListaDados();
                    break;
                default:
            }




        },
        error: function (jqXHR, exception) {

        },
        complete: function () {
        }
    });
}

$(document).ready(function () {
    // Seu código jQuery aqui

    // Adicione um evento onchange ao elemento com o ID #meuElemento
    $("#txtDocFederalLaboratorio, #txtDocFederalAdmin").on("change", function () {
        fnVerificaDocumentoCadastrado();
    });


    // Outro código jQuery aqui
});

function fnVerificaDocumentoCadastrado() {

    debugger;

    var pesdocfederal = "";


    if ($("#ddlTipoLaboratorio").val() == "0") {
        pesdocfederal = $("#txtDocFederalLaboratorio").val().replace(/[.-]/g, '');
    }

    else if ($("#ddlTipoLaboratorio").val() == "1") {
        pesdocfederal = $("#txtDocFederalAdmin").val().replace(/[.-/]/g, '');
    }

    $.ajax({

        type: "GET",
        contentType: "application/json",
        url: "Laboratorio/VerificaDocumentoCadastrado",
        data: { pesdocfederal: pesdocfederal },
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {

        },
        success: function (result) {
            debugger;


            if (result.retorno == "CPF/CNPJ já cadastrado!" && $("#ddlTipoLaboratorio").val() == "0") {
                alert("CPF já cadastrado!");
                return false;
            }
            else {
                alert("CNPJ já cadastrado!");
                return false;
            }

        },
        error: function (jqXHR, exception) {

        },
        complete: function () {
        }
    });
}

function fnListaDados() {

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "Laboratorio/ListaDados",
        data: {},
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {
        },
        success: function (result) {


            var Lista = result.lsLaboratorio;
            oTabLaboratorio.clear().draw();

            var ListaLaboratorio = new Array();
            if (Lista.length > 0) {

                for (var i = 0; i < Lista.length; i++) {
                    debugger;

                    var btnEditar = '<button id="' + Lista[i].LABID + '"  name="btnEdicao" type="button" class="btn  btn-primary" onClick="fnEditarLaboratorio(this)">Editar</button>';
                    var btnExcluir = '<button id="' + Lista[i].LABID + '"  name="btnDeletar" type="button" class="btn  btn-danger" onClick="fnExcluirLaboratorio(this)">Deletar</button>';

                    var Linha = [btnEditar + btnExcluir,
                    Lista[i].LABDESCRICAO,
                    Lista[i].TbAndar.ANDNUMERO,
                    Lista[i].LABSTATUS == ('1') ? "ATIVO" : "INATIVO",
                    ];
                    ListaLaboratorio[i] = Linha;
                }
                oTabLaboratorio.rows.add(ListaLaboratorio).draw();

            }

        },
        error: function (jqXHR, exception) {
        },
        complete: function () {
        }
    });
}

function fnExcluirLaboratorio(labid) {


    $.ajax({
        type: "GET",
        contentType: "application/json",
        url: "Laboratorio/ExcluirLaboratorio",
        data: { labid: labid.id },
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {
        },
        success: function (result) {

            fnListaDados();
        },
        error: function (jqXHR, exception) {
        },
        complete: function () {
        }
    });
}

function fnEditarLaboratorio(labid) {

    $.ajax({
        type: "GET",
        contentType: "application/json",
        url: "Laboratorio/GetLaboratorioByID",
        data: { labid: labid.id },
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {
        },
        success: function (result) {
            debugger;
            _ReservaLaboratorio = result.retorno

            $("#txtDescricaoLab").val(_ReservaLaboratorio.LABDESCRICAO);
            $("#dllAndar").val(_ReservaLaboratorio.TbAndar.ANDID);
            $("#ddlStatus").val(_ReservaLaboratorio.LABSTATUS);


            STATUS = 'ALTERACAO';
            $("#aCadastro").tab('show');
            $("#btnSalvarFormulario").css('display', 'block');
        },
        error: function (jqXHR, exception) {
        },
        complete: function () {
        }
    });
}

function lsLaboratorios() {

    $.ajax({

        type: "POST",
        contentType: "application/json",
        url: "ReservaLaboratorio/listaLaboratorios",
        data: JSON.stringify(),
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {

        },
        success: function (result) {
            debugger;

            if (result != null) {

                var ListaLaboratorios = result.lista;

                var options = '<option value="0">Selecione o Laboratório</option>';;
                $.each(ListaLaboratorios, function (key, val) {

                    options += '<option value="' + val.LABID + '">' + val.LABDESCRICAO + '</option>';
                });

                $("#ddlLaboratorio").html(options);

            }


        },
        error: function (jqXHR, exception) {

        },
        complete: function () {
        }
    });

}