oTabUsuario = null;
_Usuario = null;
IDPRINCIPAL = null;
$(document).ready(function () {
    jQueryInit();
});

function jQueryInit() {
    fnCriaTela();
}

function fnCriaTela() {

    oTabUsuario = $("#tbUsuario").DataTable({
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
            { sWidth: '12%', "bSortable": false },
            { sWidth: '30%' },//Numero          
            { sWidth: '30%' },//Titulo
            { sWidth: '20%' },//Titulo
        ]
    });

    fnListaDados();

    $(document).ready(function () {
        $('#txtTelefoneUsuario').inputmask('(99) 9999-9999');
        $('#txtCelularUsuario').inputmask('(99) 99999-9999');
        $('#txtDocFederalUsuario').inputmask('999.999.999-99');
        $('#txtDocFederalAdmin').inputmask('99.999.999/9999-99');
    });

}

function fnRetornaObjInclusao() {

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "Usuario/RetornaObjInclusao",
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {

        },
        success: function (result) {

            
            _Usuario = result.ObjInclusao;

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
    // Seletor para o campo de entrada com ID "txtDocFederalUsuario"
    $("#txtDocFederalUsuario").on("blur", function () {

    });
});

$(document).ready(function () {
    // Quando o valor do select for alterado
    $("#ddlTipoUsuario").on("change", function () {
        var selectedValue = $(this).val();

        // Mostra a label correspondente com base na seleção
        if (selectedValue === "0") {

            $("#lblCNPJUsuario").css("display", "none");
            $("#txtDocFederalAdmin").css("display", "none");
            $("#lblCpfUsuario").css("display", "block");
            $("#txtDocFederalUsuario").css("display", "block");


        } else if (selectedValue === "1") {

            $("#lblCpfUsuario").css("display", "none");
            $("#txtDocFederalUsuario").css("display", "none");
            $("#lblCNPJUsuario").css("display", "block");
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

    



    if ($("#ddlTipoUsuario").val() == "0") {
        _Usuario.TbPessoa.PESDOCFEDERAL = $("#txtDocFederalUsuario").val().replace(/[.-]/g, '');
    }

    else if ($("#ddlTipoUsuario").val() == "1"){
        _Usuario.TbPessoa.PESDOCFEDERAL = $("#txtDocFederalAdmin").val().replace(/[.-/]/g, '');
    }

    _Usuario.USUSEQUENCIAL = $("#txtCodigoUsuario").val();
    _Usuario.USUSTATUS = $("#ddlStatus").val();
    _Usuario.USUSENHA = $("#txtSenhaUsuario").val();

    _Usuario.TbPessoa.PESNOME = $("#txtNomeUsuario").val();
    _Usuario.TbPessoa.PESSOBRENOME = $("#txtSobreNomeUsuario").val();
    _Usuario.TbPessoa.PESTIPO = $("#ddlTipoUsuario").val();


    _Usuario.TbEmail.EMLDESCRICAO = $("#txtEmailUsuario").val();



    var dddTelefone = $("#txtTelefoneUsuario").val().replace(/[-() ]+/g, "").substring(0, 2);
    var telefone = $("#txtTelefoneUsuario").val().replace(/[-() ]+/g, "").slice(2);
    _Usuario.TbTelefone.TELDDD = dddTelefone;
    _Usuario.TbTelefone.TELNUMERO = telefone;

    var dddCelular = $("#txtCelularUsuario").val().replace(/[-() ]+/g, "").substring(0, 2);
    var celular = $("#txtCelularUsuario").val().replace(/[-() ]+/g, "").slice(2);
    _Usuario.TbTelefone.TELDDDC = dddCelular;
    _Usuario.TbTelefone.TELCELULAR = celular;


    $.ajax({

        type: "POST",
        contentType: "application/json",
        url: "Usuario/GravarUsuario",
        data: JSON.stringify(_Usuario),
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {

        },
        success: function (result) {
            


            switch (result.retorno) {
                case "EMAIL JÁ CADASTRADO!":
                    alert('E-mail já cadastrado em outro usuário!');
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
    $("#txtDocFederalUsuario, #txtDocFederalAdmin").on("change", function () {
        fnVerificaDocumentoCadastrado();
    });


    // Outro código jQuery aqui
});

function fnVerificaDocumentoCadastrado() {

    

    var pesdocfederal = "";


    if ($("#ddlTipoUsuario").val() == "0") {
        pesdocfederal = $("#txtDocFederalUsuario").val().replace(/[.-]/g, '');
    }

    else if ($("#ddlTipoUsuario").val() == "1") {
        pesdocfederal = $("#txtDocFederalAdmin").val().replace(/[.-/]/g, '');
    }

    $.ajax({

        type: "GET",
        contentType: "application/json",
        url: "Usuario/VerificaDocumentoCadastrado",
        data: { pesdocfederal: pesdocfederal },
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {

        },
        success: function (result) {
            


            if (result.retorno == "CPF/CNPJ já cadastrado!" && $("#ddlTipoUsuario").val() == "0") {
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
        url: "Usuario/ListaDados",
        data: {},
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {
        },
        success: function (result) {
            

            var Lista = result.lsUsuario;
            oTabUsuario.clear().draw();

            var ListaUsuario = new Array();
            if (Lista.length > 0) {

                for (var i = 0; i < Lista.length; i++) {
                    

                    var btnEditar = '<button id="' + Lista[i].PESID + '"  name="btnEdicao" type="button" class="btn  btn-primary" onClick="fnEditarUsuario(this)">Editar</button>';
                    var btnExcluir = '<button id="' + Lista[i].PESID + '"  name="btnDeletar" type="button" class="btn  btn-danger" onClick="fnExcluirUsuario(this)">Deletar</button>';

                    var Linha = [btnEditar + btnExcluir,
                    Lista[i].TbPessoa.PESNOME,
                    Lista[i].TbEmail.EMLDESCRICAO,
                    Lista[i].USUSTATUS == ('1') ? "ATIVO" : "INATIVO",
                    ];
                    ListaUsuario[i] = Linha;
                }
                oTabUsuario.rows.add(ListaUsuario).draw();

            }

        },
        error: function (jqXHR, exception) {
        },
        complete: function () {
        }
    });
}

function fnExcluirUsuario(pesid) {


    $.ajax({
        type: "GET",
        contentType: "application/json",
        url: "Usuario/ExcluirUsuario",
        data: { pesid: pesid.id },
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

function fnEditarUsuario(pesid) {

    $.ajax({
        type: "GET",
        contentType: "application/json",
        url: "Usuario/GetUsuarioByID",
        data: { pesid: pesid.id },
        dataType: "JSON",
        cache: false,
        async: false,
        beforeSend: function () {
        },
        success: function (result) {

            debugger;
            
            _Usuario = result.retorno

            $("#txtCodigoUsuario").val(_Usuario.USUSEQUENCIAL);
            $("#ddlStatus").val(_Usuario.USUSTATUS);
            $("#txtSenhaUsuario").val(_Usuario.USUSENHA);

            $("#txtNomeUsuario").val(_Usuario.TbPessoa.PESNOME);

            $("#txtDocFederalUsuario").val(_Usuario.TbPessoa.PESDOCFEDERAL)



            $("#txtEmailUsuario").val(_Usuario.TbEmail.EMLDESCRICAO)



            $("#txtTelefoneUsuario").val(_Usuario.TbTelefone.TELDDD + _Usuario.TbTelefone.TELNUMERO);
            $("#txtCelularUsuario").val(_Usuario.TbTelefone.TELDDDC + _Usuario.TbTelefone.TELCELULAR);



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

function buscaCep(cep) {
    $.ajax({
        url: "https://viacep.com.br/ws/" + cep + "/json/",
        dataType: "json",
        success: function (data) {

            if (data.erro) {
                // Trate o caso em que o CEP informado é inválido
            } else {
                $("#txtLogradouro").val(data.logradouro);
                $("#txtBairro").val(data.bairro);
                $("#txtCidade").val(data.localidade);
                $("#ddlUf").val(data.uf);
                // Use os dados do endereço como quiser
            }
        },
        error: function (xhr, status, error) {
            // Trate os erros da requisição aqui
        }
    });
}

function checkPasswordStrength() {
    var password = document.getElementById("txtSenhaUsuario").value;
    var strengthMeter = document.getElementById("strength-meter");

    var strongRegex = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\\$%^&*])");
    var mediumRegex = new RegExp("^(?=.*[a-zA-Z])(?=.*[0-9])");

    if (strongRegex.test(password)) {
        strengthMeter.className = "strong";
        strengthMeter.textContent = "Forte";
    } else if (mediumRegex.test(password)) {
        strengthMeter.className = "medium";
        strengthMeter.textContent = "Média";
    } else {
        strengthMeter.className = "weak";
        strengthMeter.textContent = "Fraca";
    }
}