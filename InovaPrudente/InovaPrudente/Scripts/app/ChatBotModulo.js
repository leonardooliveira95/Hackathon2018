const ChatBotModulo = (function () {

    let inicializar = () => {

        $("#botao-enviar-mensagem").click(_clickBotaoEnviarMensagem);

    };

    let _clickBotaoEnviarMensagem = () => {

        let texto = $("#input-texto-mensagem").val();
        let msg = $(".modelo-mensagem").clone(true);

        msg.find(".texto").html(texto);
        msg.addClass("usuario");
        msg.removeClass("modelo-mensagem");

        $(".container-mensagens").append(msg);
        
        msg.show();

        _enviarMensagemServidor(texto);

    };

    let _enviarMensagemServidor = (texto) => {

        $.ajax({
            url: "http://localhost:3979/Messages/Post",
            type: "POST",
            data: {

                type: "message",
                serviceUrl: "http://localhost:50821",
                text: texto

            }
        })
        .done((data) => {
            console.log(data);
        });

    };

    return {
        inicializar: inicializar
    }


})();


$(() => {

    ChatBotModulo.inicializar();

});