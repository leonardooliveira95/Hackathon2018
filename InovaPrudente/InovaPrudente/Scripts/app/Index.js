let map;
let markers = [];

const SelecionarModulo = (function () {

    let inicializar = () => {

        $("#botao-alterar-endereco").click(_clickAlterarEndereco);
    };

    let _clickAlterarEndereco = (event) => {

        let botao = $(event.currentTarget);

        _escolherOpcao(botao);

        $.ajax({
            url: urlBase + "Home/TrocarEndereco",
            type: "GET"
        })
        .done((data) => {

            $(".container-opcao-selecionada").html(data);
            $("#botao-escolher-endereco").click(_clickBotaoEscolherEndereco);

        });

    };

    let _clickBotaoEscolherEndereco = () => {

        let endereco = $("#input-texto-endereco").val();

        _exibirPontoMapa(endereco);

    };

    let _escolherOpcao = (botaoSelecionado) => {

        let botoesContainer = $(".container-botoes button");
        botoesContainer.prop("disabled", true);
        botoesContainer.removeClass("btn-primary");

        botaoSelecionado.prop("disabled", false);
        botaoSelecionado.addClass("active");
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

    let _calcularValorPrecoDistancia = (distancia) => {

        $.ajax({
            url: urlBase + "Home/CalcularValorPrecoDistancia",
            type: "POST",
            data: {
                distancia: distancia
            }
        })
        .done((data) => {

            MensagensModulo.exibeMensagemInformacao("O novo valor do frete é " + data.valor)

        });
    };

    return {
        inicializar: inicializar,
        carregarMapa: carregarMapa
    }

})();

$(() => {

    SelecionarModulo.inicializar();

});