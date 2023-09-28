oTabTipoVenda = null;
_TipoVenda = null;
IDPRINCIPAL = null;
$(document).ready(function () {
    jQueryInit();
});

function jQueryInit() {
    fnCriaTela();
}

function fnCriaTela() {

    oTabTipoVenda = $("#tbTipoVenda").DataTable({
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
            { sWidth: '06%', "bSortable": false },
            { sWidth: '20%' },//Numero          
            { sWidth: '20%' },//Titulo
        ]
    });

    fnListaDados();

}

function fnRetornaObjInclusao() {

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "TipoVenda/RetornaObjInclusao",
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {

        },
        success: function (result) {

            debugger;
            _TipoVenda = result.ObjInclusao;

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

$("#aLista").click(function () {
    $("#btnSalvarFormulario").css('display', 'none');
})

$("#aCadastro").click(function () {
    STATUS = 'INSERCAO';
    $("#btnSalvarFormulario").css('display', 'block');
    fnRetornaObjInclusao();
    /*    fnDadosVendedor();*/
});

$(document).ready(function () {
    $('#btnSalvarFormulario').on('click', function () {

        switch (STATUS) {
            case 'INSERCAO':
                fnSalvarDados();
                $("#aLista").tab('show');
                fnListaDados();
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

function fnSalvarDados() {

    _TipoVenda.TPVID = IDPRINCIPAL;
    _TipoVenda.TPVDESCRICAO = $("#txtDescricaoTipoVenda").val();
    _TipoVenda.TPVDEFAULTVENDA = $("#ckbDefaultVenda").prop("checked") ? 1 : 0;


    $.ajax({

        type: "POST",
        contentType: "application/json",
        url: "TipoVenda/GravarTipoVenda",
        data: JSON.stringify(_TipoVenda),
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {

        },
        success: function (result) {
            debugger;



            $(document).ready(function () {
                var resposta = confirm("Você tem certeza de que deseja continuar?");

                if (resposta) {
                    // O usuário clicou em "OK", faça algo aqui
                    alert("Ação confirmada!");
                } else {
                    // O usuário clicou em "Cancelar" ou fechou a caixa de diálogo
                    alert("Ação cancelada!");
                }
            });


            result.retorno = "OK";




            fnListaDados();

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
        url: "TipoVenda/ListaDados",
        data: {},
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {
        },
        success: function (result) {


            var Lista = result.lsTipoVenda;
            oTabTipoVenda.clear().draw();

            var ListaTipoVenda = new Array();
            if (Lista.length > 0) {

                for (var i = 0; i < Lista.length; i++) {
                    debugger;

                    var btnEditar = '<button id="' + Lista[i].TPVID + '"  name="btnEdicao" type="button" class="btn  btn-primary" onClick="fnEditarTipoVenda(this)">Editar</button>';
                    var btnExcluir = '<button id="' + Lista[i].TPVID + '"  name="btnDeletar" type="button" class="btn  btn-danger" onClick="fnExcluirTipoVenda(this)">Deletar</button>';

                    var Linha = [btnEditar + btnExcluir,
                    Lista[i].TPVDESCRICAO,
                    Lista[i].TPVDEFAULTVENDA
                    ];
                    ListaTipoVenda[i] = Linha;
                }
                oTabTipoVenda.rows.add(ListaTipoVenda).draw();

            }

        },
        error: function (jqXHR, exception) {
        },
        complete: function () {
        }
    });
}

function fnExcluirTipoVenda(tpvid) {


    $.ajax({
        type: "GET",
        contentType: "application/json",
        url: "TipoVenda/ExcluirTipoVenda",
        data: { tpvid: tpvid.id },
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

function fnEditarTipoVenda(tpvid) {

    $.ajax({
        type: "GET",
        contentType: "application/json",
        url: "TipoVenda/GetTipoVendaByID",
        data: { tpvid: tpvid.id },
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {
        },
        success: function (result) {
            debugger;
            _TipoVenda = result.retorno

            IDPRINCIPAL = _TipoVenda.TPVID;
            $("#txtDescricaoTipoVenda").val(_TipoVenda.TPVDESCRICAO);
            $("#ckbDefaultVenda").prop("checked", _TipoVenda.TPVDEFAULTVENDA == 1);

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


