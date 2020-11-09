$(document).ready(function () {

    var emVM = {
        Nome: "",
        Cnpj: "",
        CapitalSocial: "",
        Procura: "",
        Socios: "",
        TipoEmpresa: "",
        NomeFantasia: "",
        DataAbertura: "",
        Endereco: "",
        Numero: "",
        Cep: "",
        Bairro: "",
        Uf: "",
        Telefone: "",
        Email: ""
    };

    function AtualizarObjeto() {
        emVM = {
            Cnpj: $("#pesquisaCnpj").val()
        }
    }

    function AtualizarObjetoSalvar() {
        emVM = {
            Nome: $("#lstNmEmpresa").val(),
            NomeFantasia: $("#lstNmFantasia").val(),
            Cnpj: $("#lstCnpj").val(),
            TipoEmpresa: $("#lstTipoEmpresa").val(),
            DataAbertura: $("#lstDataAbertura").val(),
            CapitalSocial: $("#lstCapitalSocial").val(),
            Procura: $("#lstProcura").val(),
            Socios: $("#lstSocios").val()            
        }
    }

    $("#btnPesquisar").click(function () {

        if ($("#pesquisaCnpj").val() == "") {

            $("#pesquisaCnpj").css({ "border-color": "#F00", "padding": "2px" });
            alert("Por favor, informe o CNPJ para pesquisar");
            return false;

        } else {

            AtualizarObjeto();

            var url = "/Home/PesquisarApi";

            $.ajax({
                url: url,
                type: "GET",
                data: emVM,
                dataType: "json",
                success: function (result) {

                }
            });
        }
    });

    $("#btnSalvar").click(function () {
        AtualizarObjetoSalvar();

        var url = "/Home/Empresa"

        $.ajax({
            url: url,
            type: "GET",
            data: emVM,
            dataType: "json",
            success: function (result) {

            }
        });
    });
});