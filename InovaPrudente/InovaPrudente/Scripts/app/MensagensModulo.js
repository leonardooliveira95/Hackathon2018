'use strict';

const MensagensModulo = (function () {

    var stack_bottomright = { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 };
    var animate_in = "slideInRight";
    var animate_out = "slideOutRight";

    //Inicializa o estilo das mensagens
    PNotify.prototype.options.styling = "fontawesome";

    var exibeMensagemInformacao = (mensagem) => {

        new PNotify({
            text: mensagem,
            icon: 'fa fa-fw fa-info',
            type: 'info',
            addclass: 'stack-bottomright',
            stack: stack_bottomright,
            animate: {
                animate: true,
                in_class: animate_in,
                out_class: animate_out
            },
            buttons: {
                labels: { close: "Fechar", stick: "Manter aberto" },
                sticker: false
            }
        });

    };

    var exibeMensagemErro = (mensagem) => {

        new PNotify({
            text: mensagem,
            icon: 'fa fa-fw fa-exclamation',
            type: 'error',
            addclass: 'stack-bottomright',
            stack: stack_bottomright,
            animate: {
                animate: true,
                in_class: animate_in,
                out_class: animate_out
            },
            buttons: {
                labels: { close: "Fechar", stick: "Manter aberto" },
                sticker: false
            }
        });
    };

    var exibeMensagemAlerta = (mensagem) => {

        new PNotify({
            text: mensagem,
            icon: 'fa fa-fw fa-warning',
            type: 'notice',
            addclass: 'stack-bottomright',
            stack: stack_bottomright,
            animate: {
                animate: true,
                in_class: animate_in,
                out_class: animate_out
            },
            buttons: {
                labels: { close: "Fechar", stick: "Manter aberto" },
                sticker: false
            }
        });
    };

    var exibeMensagemSucesso = (mensagem) => {

        new PNotify({
            text: mensagem,
            icon: 'fa fa-fw fa-check',
            type: 'success',
            text_escape: true,
            addclass: 'stack-bottomright',
            stack: stack_bottomright,
            animate: {
                animate: true,
                in_class: animate_in,
                out_class: animate_out
            },
            buttons: {
                labels: { close: "Fechar", stick: "Manter aberto" },
                sticker: false
            }
        });

    };

    return {

        exibeMensagemInformacao: exibeMensagemInformacao,
        exibeMensagemAlerta: exibeMensagemAlerta,
        exibeMensagemErro: exibeMensagemErro,
        exibeMensagemSucesso: exibeMensagemSucesso

    };

})();