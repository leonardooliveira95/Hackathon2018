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

                "type": "message",
                "text": "iopopiop",
                "from": {
                    "id": "default-user",
                    "name": "User"
                },
                "locale": "pt-BR",
                "textFormat": "plain",
                "timestamp": "2018-10-13T23:29:21.716Z",
                "channelData": {
                    "clientActivityId": "1539470336139.2932336851935673.4"
                },
                "id": "k2656kdbh2d",
                "channelId": "emulator",
                "localTimestamp": "2018-10-13T20:29:21-03:00",
                "recipient": {
                    "id": "m226mfj49gd9",
                    "name": "Bot"
                },
                "conversation": {
                    "id": "df5821a8jhk8"
                },
                "serviceUrl": "http://localhost:50821"



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