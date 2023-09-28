oTabEntradaEstoque = null;
oTabListaProdutosEntrada = null;
var ListaItensPesquisa = [];
ListaGrid = [];
var ListaItensGrid = new Array();
var posicaoGrid = 1;
_EntradaEstoque = null
IDPRINCIPAL = null;
var custoUnitario = 0;
var valorIpi = 0;
var custoTotal = 0;
var totalNota = 0;

$(document).ready(function () {
    jQueryInit();
});

function jQueryInit() {
    fnCriaTela();
    fnCriaGridItens();
    $("#btnSalvarFormulario").css('display', 'block');
}

function fnCriaTela() {

    oTabEntradaEstoque = $("#tbMovimentacao").DataTable({
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
            { sWidth: '15%', "bSortable": false },
            { sWidth: '4%' },//Numero          
            { sWidth: '10%' },//Titulo
            { sWidth: '10%' },//Titulo
            { sWidth: '10%' },//Titulo
            { sWidth: '10%' },//Titulo
            { sWidth: '10%' },//Titulo
            { sWidth: '10%' },//Titulo
            { sWidth: '10%' },//Titulo
        ]
    });

    fnRetornaObjInclusao();
    fnSetDataAtual();
    fnRetornaComboFornecedores();
    fnRetornaComboCfops();

    $('#txtValorUnitario').inputmask('R$ 9{1,},99');
    $('#txtIPI').inputmask('R$ 9{1,},99');
    $('#txtCustoTotal').inputmask('R$ 9{1,},99');
    $('#txtMvmvalvenda').inputmask('R$ 9{1,},99');

}

function fnCriaGridItens() {

    oTabListaProdutosEntrada = $("#tbListaProdutosEntrada").DataTable({
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
            { sWidth: '20%' },//Numero          
            { sWidth: '20%' },//Titulo
            { sWidth: '20%' },//Titulo
            { sWidth: '20%' },//Titulo
        ]
    });
}

function fnRetornaObjInclusao() {

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "EntradaEstoque/RetornaObjInclusao",
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {

        },
        success: function (result) {


            _EntradaEstoque = result.ObjInclusao;

        },
        error: function (jqXHR, exception) {
        },
        compvare: function () {
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

$("#btnPesquisarProduto").click(function () {

    fnLimpaGrid();

    fnBuscarProduto($("#txtFantasia").val());

})


$("#txtIPI").blur(function () {

    fnCalculoCustoTotal();
})

function removerMascara(valor) {

    return valor.replace("R$", "").trim();

}

function substituirPontosPorVirgulas(texto) {
    // Usar o método replace com uma expressão regular para substituir todos os pontos por vírgulas
    return texto.replace(/\./g, ',');
}

function textoParaNumero(texto) {

    return parseFloat(texto.replace(',', '.'));
}

function fnCalculoCustoTotal() {


    var quantidade = 0;
    var custoUnitario = 0;
    var valorIpi = 0;

    custoUnitario = removerMascara($("#txtValorUnitario").val());
    valorIpi = removerMascara($("#txtIPI").val());
    quantidade = $("#txtQtd").val();



    custoUnitario = parseFloat(custoUnitario.replace(',', '.'));
    valorIpi = parseFloat(valorIpi.replace(',', '.'));

    var resultado = quantidade * (custoUnitario + valorIpi);


    custoTotal = resultado.toFixed(2).replace('.', ',');
    $("#txtCustoTotal").val(custoTotal);

}

$("#txtMarkup").blur(function () {

    fnCalculoValorVenda();
})

function fnCalculoValorVenda() {


    var markup = 0;
    var valorVenda = 0;
    var valorCusto = custoTotal

    var markup = $("#txtMarkup").val();

    markup = textoParaNumero(markup);

    valorCusto = textoParaNumero(valorCusto);


    if (markup < 0 || markup == null || markup == "undefined" || markup == "") {
        return false;
    }

    else {

        valorVenda = (valorCusto * ((markup / 100) + 1)).toFixed(2);
        valorVenda = valorVenda.replace('.', ',');
        $("#txtMvmvalvenda").val(valorVenda);
    }
}

$(document).ready(function () {
    $('#btnSalvarFormulario').on('click', function () {
        fnSalvarDados();
    });
});

function fnSalvarDados() {

    _EntradaEstoque.TPVID = IDPRINCIPAL;
    _EntradaEstoque.TPVDESCRICAO = $("#txtDescricaoEntradaEstoque").val();
    _EntradaEstoque.TPVDEFAULTVENDA = $("#ckbDefaultVenda").prop("checked") ? 1 : 0;


    $.ajax({

        type: "POST",
        contentType: "application/json",
        url: "EntradaEstoque/GravarEntradaEstoque",
        data: JSON.stringify(_EntradaEstoque),
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {

        },
        success: function (result) {


            result.retorno = "OK";

            fnListaDados();

        },
        error: function (jqXHR, exception) {

        },
        compvare: function () {
        }
    });
}

function fnRetornaComboFornecedores() {

    $.ajax({

        type: "POST",
        contentType: "application/json",
        url: "EntradaEstoque/RetornaComboFornecedores",
        data: JSON.stringify(),
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {

        },
        success: function (result) {


            if (result != null) {

                var lista = result.listaFornecedores;

                var options = '<option value="0">Selecione o Fornecedor</option>';;
                $.each(lista, function (key, val) {

                    options += '<option value="' + val.FORID + '">' + val.TbPessoa.PESNOME + '</option>';
                });

                $("#sslFornecedor").html(options);

            }


        },
        error: function (jqXHR, exception) {

        },
        compvare: function () {
        }
    });

}

function fnRetornaComboCfops() {

    $.ajax({

        type: "POST",
        contentType: "application/json",
        url: "EntradaEstoque/RetornaComboCfops",
        data: JSON.stringify(),
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {

        },
        success: function (result) {



            if (result != null) {

                var lista = result.listaCfops;

                var options = '<option value="0">Selecione o CFOP</option>';;
                $.each(lista, function (key, val) {

                    options += '<option value="' + val.COPID + '">' + val.COPDESCRICAO + '</option>';
                });

                $("#sslCFOP").html(options);

            }


        },
        error: function (jqXHR, exception) {

        },
        compvare: function () {
        }
    });

}

function fnSetDataAtual() {

    var dataAtual = new Date();
    dataAtual.setMinutes(dataAtual.getMinutes() - dataAtual.getTimezoneOffset()); // Ajusta para UTC

    // Formata a data para o formato YYYY-MM-DD, que é o formato esperado pelo input type="date"
    var dataFormatada = dataAtual.toISOString().slice(0, 10);

    // Define a data atual no campo input
    document.getElementById('dtDataMvm').value = dataFormatada;
}

function fnBuscarProduto(produto) {

    $.ajax({

        type: "POST",
        contentType: "application/json",
        url: "EntradaEstoque/RetornaEntityProduto",
        data: JSON.stringify({ produto: produto }),
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {

        },
        success: function (result) {

            if (result.Produto.length == 0) {
                alert('Nenhum produto encontrado!');
                return false;
            }

            ListaItensPesquisa = result.Produto;


            if (ListaItensPesquisa.length > 0) {

                $('#txtModal').modal('show');

                oTabListaProdutosEntrada.clear().draw();

                var Lista = new Array();

                if (ListaItensPesquisa.length > 0) {

                    for (var i = 0; i < ListaItensPesquisa.length; i++) {


                        var btnSalvarItemGrid = '<button id="' + ListaItensPesquisa[i].MATID +
                            '"  name="btnEdicao" type="button" class="btn  btn-primary" onClick="fnPopulaGrid(this)">SALVAR</button>';


                        var Linha = [btnSalvarItemGrid,
                            ListaItensPesquisa[i].MATSEQUENCIAL,
                            ListaItensPesquisa[i].MATFANTASIA,
                            ListaItensPesquisa[i].TbGrife.ARGDESCRICAO,
                            ListaItensPesquisa[i].TbCor.ARCDESCRICAO,
                        ];
                        Lista[i] = Linha;
                    }
                    oTabListaProdutosEntrada.rows.add(Lista).draw();
                }

            }



        },
        error: function (jqXHR, exception) {

        },
        compvare: function () {
        }
    });
}

function fnPopulaGrid(ProdutoSelecionado) {

    for (var i = 0; i < ListaItensPesquisa.length; i++) {

        var iTemLista = ListaItensPesquisa[i].MATID.toString();

        if (iTemLista === ProdutoSelecionado.id) {


            IDPRINCIPAL = ListaItensPesquisa[i].MATID;

            $("#txtProduto").val(ListaItensPesquisa[i].MATFANTASIA);

            $('#txtModal').modal('hide');

        }
    }

}

$("#btnAdicionarItemGrid").click(function () {

    if (IDPRINCIPAL == null) {
        return false;
    }

    fnPreencheGrid(IDPRINCIPAL);

})

function fnPreencheGrid(mATID) {

    for (var i = 0; i < ListaItensPesquisa.length; i++) {

        if (mATID === ListaItensPesquisa[i].MATID) {
           
            _EntradaEstoque.TbProduto.MATID = IDPRINCIPAL


            var btnEditar = '<button id="' + _EntradaEstoque.TbProduto.MATID + '"  name="btnEdicao" type="button" style="margin:5px;"  class="btn  btn-primary" onClick="fnEditarTipoVenda(this)">Editar</button>';
            var btnExcluir = '<button id="' + _EntradaEstoque.TbProduto.MATID + '"  name="btnEdicao" type="button" class="btn  btn-danger" onClick="fnEditarTipoVenda(this)">Excluir</button>';

            var Linha = [btnEditar + btnExcluir,
                posicaoGrid,
            _EntradaEstoque.TbProduto.MATFANTASIA = $("#txtProduto").val(),
            _EntradaEstoque.TbItensEntrada.MVMQUANTIDADE = $("#txtQtd").val(),
            _EntradaEstoque.TbItensEntrada.MVMVALUNITARIO = $("#txtValorUnitario").val(),
            _EntradaEstoque.TbItensEntrada.MVMVALIPI = $("#txtIPI").val(),
            _EntradaEstoque.TbItensEntrada.MVMVALCUSTO = $("#txtCustoTotal").val(),
            _EntradaEstoque.TbItensEntrada.MVMMARKUP = $("#txtMarkup").val(),
            _EntradaEstoque.TbItensEntrada.MVMVALVENDA = $("#txtMvmvalvenda").val(),
            ];
            ListaGrid[0] = Linha;
            posicaoGrid += 1;

            oTabEntradaEstoque.rows.add(ListaGrid).draw();

            debugger;

            var custo = removerMascara($("#txtCustoTotal").val());
            custo = textoParaNumero(custo);


            totalNota += custo;


            totalNota = totalNota.toFixed(2).replace('.', ',');

            $("#txtValorNota").val(totalNota);


            var regex = /id="([^"]+)"/;
            var match = btnEditar.match(regex);

            if (match && match.length > 1) {
                var matid = match[1];
                console.log(matid); // matid conterá o valor de _EntradaEstoque.TbProduto.MATID
            }

            Linha[0] = matid;




        }
    }
}

function fnLimpaGrid() {


    $("#txtProduto").val('');
    $("#txtQtd").val('');
    $("#txtValorUnitario").val('');
    $("#txtIPI").val('');
    $("#txtCustoTotal").val('');
    $("#txtMarkup").val('');
    $("#txtMvmvalvenda").val('');
}

