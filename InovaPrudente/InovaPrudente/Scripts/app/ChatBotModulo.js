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
            url: "http://localhost:3979/api/Messages/Post",
            type: "POST",
            contentType: "application/x-www-form-urlencoded",
            data: {

                type: "message",
                serviceUrl: "http://localhost:3979/",
                text: texto,
                from: {
                    id: "default-user",
                    name: "User"
                },
                locale: "pt-BR",
                textFormat: "plain",
                timestamp: "2018-10-13T22:38:58.299Z",
                channelData: {
                    clientActivityId: "1539470336139.2932336851935673.0"
                },
                entities: [
                    {
                        type: "ClientCapabilities",
                        requiresBotState: true,
                        supportsTts: true,
                        supportsListening: true
                    }
                ],
                id: "250h4dah9c06c"
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