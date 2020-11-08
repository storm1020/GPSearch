$(document).ready(function () {

    var emVM = {
        Nome: "",
        Cnpj: ""
    };

    function AtualizarObjeto() {
        emVM = {
            Cnpj: $("#pesquisaCnpj").val()
        }
    }

    $("#btnPesquisar").click(function () {

        //validar antes se o campo estiver vazio
        AtualizarObjeto();

        var url = "/Home/PesquisarApi";

        $.ajax({
            url: url,
            type: "GET",
            data: emVM,
            dataType: "json",
            success: function (result) {
                //retorno
            }
        });

    });
});