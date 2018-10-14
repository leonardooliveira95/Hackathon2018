let map;
let markers = [];

const SelecionarModulo = (function () {

    let _armarios = [];

    let inicializar = () => {

        $("#botao-alterar-endereco").click(_clickAlterarEndereco);
        $("#botao-alterar-data-entrega").click(_clickAlterarDataEntrega);
        $("#botao-entregar-armario").click(_clickEntregarArmario);
    };

    let _desabilitarEnter = () => {

        $('form').on('keyup keypress', function (e) {
            var keyCode = e.keyCode || e.which;
            if (keyCode === 13) {
                e.preventDefault();
                return false;
            }
        });

    }

    let _clickAlterarEndereco = (event) => {

        let botao = $(event.currentTarget);

        _escolherOpcao(botao);

        $.ajax({
            url: urlBase + "Home/TrocarEndereco",
            type: "GET"
        })
            .done((data) => {

                $(".container-opcao-selecionada").html(data).addClass("fadeIn");
                $("#botao-escolher-endereco").click(_clickBotaoEscolherEndereco);
                $("#botao-confirmar-alteracao-endereco").click(_clickBotaoConfirmarAlteracaoEndereco);
                $("#botao-escolher-outro-local").click(_clickBotaoEscolherOutroLocal);
                $("#input-texto-endereco").on("keypress", _keypressTextoEndereco);

                _desabilitarEnter();

            });

    };

    let _keypressTextoEndereco = (event) => {

        if (event.which == 10 || event.which == 13) {
            _clickBotaoEscolherEndereco();
        }
    };

    let _clickBotaoEscolherEndereco = () => {

        let input = $("#input-texto-endereco");

        input.prop("disabled", true);
        $("#botao-escolher-endereco").prop("disabled", true);

        let endereco = input.val();

        _exibirPontoMapa(endereco);

    };

    let _clickBotaoConfirmarAlteracaoEndereco = () => {

        _scrollToBottom();

        let botoesContainer = $(".container-botoes-confirmacao button");
        botoesContainer.prop("disabled", true);

        $("#resultado-confirmacao-troca-endereco").fadeIn("fast");

    };

    let _clickBotaoEscolherOutroLocal = () => {

        _scrollTo("#selecao-novo-endereco");

        let input = $("#input-texto-endereco");

        input.prop("disabled", false);
        $("#botao-escolher-endereco").prop("disabled", false);
        $("#resultado-selecao-novo-endereco").fadeOut("fast");
    };

    let _clickAlterarDataEntrega = (event) => {

        let botao = $(event.currentTarget);

        _escolherOpcao(botao);

        $.ajax({
            url: urlBase + "Home/AlterarDataEntrega",
            type: "GET"
        })
            .done((data) => {

                $(".container-opcao-selecionada").html(data).addClass("fadeIn");
                $("#botao-confirmar-nova-data-entrega").click(_clickBotaoConfirmarNovaDataEntrega);

                _desabilitarEnter();

            });

    };

    let _clickBotaoConfirmarNovaDataEntrega = () => {

        let vetInput = $("#input-nova-data-entrega").val().split("-");
        let data = new Date(vetInput[0], parseInt(vetInput[1]) - 1, vetInput[2]);


        $("#div-mensagem-confirmacao-data").show().addClass("fadeIn");
        $("#nova-data-entrega").html(data.toLocaleDateString());
    };

    let _clickEntregarArmario = (event) => {

        let botao = $(event.currentTarget);

        _escolherOpcao(botao);

        $.ajax({
            url: urlBase + "Home/EntregarArmario",
            type: "GET"
        })
            .done((data) => {

                $(".container-opcao-selecionada").html(data).addClass("fadeIn");
                $("#botao-escolher-armario").click(_clickBotaoEscolherArmario);

                _desabilitarEnter();

            });

    };

    let _clickBotaoEscolherArmario = (event) => {

        let botao = $(event.currentTarget);



    };

    let _escolherOpcao = (botaoSelecionado) => {

        let botoesContainer = $(".container-botoes button");
        botoesContainer.prop("disabled", true);
        botoesContainer.removeClass("btn-primary");

        botaoSelecionado.addClass("btn-primary");

    };

    let _exibirPontoMapa = (endereco) => {

        let geocoder = new google.maps.Geocoder();
        geocoder.geocode({ 'address': endereco }, function (results, status) {

            let latLng = { lat: results[0].geometry.location.lat(), lng: results[0].geometry.location.lng() };

            if (status == 'OK') {

                let marker = new google.maps.Marker({
                    position: latLng,
                    map: map,
                    center: latLng
                });

                map.setZoom(17);
                map.panTo(marker.position);

                let distancia = google.maps.geometry.spherical.computeDistanceBetween(marker.position, markers[0].position);
                _calcularValorPrecoDistancia(distancia);

                $("#span-novo-endereco").html(endereco);


            }
            else {
                MensagensModulo.exibeMensagemErro("Erro ao buscar dados do Google Maps");
            }
        });

    };

    let carregarMapa = () => {

        let endereco = $("#map").attr("data-endereco-atual");
        let geocoder = new google.maps.Geocoder();

        geocoder.geocode({ "address": endereco }, (results, status) => {

            let latLng = { lat: results[0].geometry.location.lat(), lng: results[0].geometry.location.lng() };

            map = new google.maps.Map(document.getElementById('map'), {
                zoom: 4,
                center: latLng
            });

            let marker = new google.maps.Marker({
                position: latLng,
                map: map,
                title: "Endereço de entrega atual"
            });

            markers.push(marker);

            map.setZoom(17);
            map.panTo(marker.position);

        });
    };

    let carregarMapaArmario = () => {

        map = new google.maps.Map(document.getElementById('map'), {
            zoom: 4,
            center: { lat: -34.397, lng: 150.644 }
        });

        $.each(SelecionarModulo.armarios, (index, valor) => {

            let geocoder = new google.maps.Geocoder();

            geocoder.geocode({ "address": valor.Endereco }, (results, status) => {

                let latLng = { lat: results[0].geometry.location.lat(), lng: results[0].geometry.location.lng() };

                let marker = new google.maps.Marker({
                    position: latLng,
                    map: map,
                    title: valor.Endereco
                });

                map.setZoom(17);
                map.panTo(marker.position);

            });
            
        });

    };

    let _calcularValorPrecoDistancia = (distancia) => {

        $.ajax({
            url: urlBase + "Home/CalcularValorPrecoDistancia",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ distancia: distancia })
        })
        .done((data) => {

            $("#span-novo-valor-frete").html("R$ " + data.valor);
            $("#resultado-selecao-novo-endereco").show().removeClass("fadeIn").addClass("fadeIn");

            _scrollToBottom();


        });
    };

    let _scrollTo = (seletor) => {

        $('html, body').animate({
            scrollTop: $(seletor).offset().top
        }, 800);

    };

    let _scrollToBottom = () => {
        $('html, body').animate({
            scrollTop: document.body.scrollHeight
        }, 800);
    };

    return {
        inicializar: inicializar,
        carregarMapa: carregarMapa,
        carregarMapaArmario: carregarMapaArmario,
        armarios: _armarios
    }

})();

$(() => {

    SelecionarModulo.inicializar();

});