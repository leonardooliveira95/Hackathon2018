'use strict';

const BackdropLoadingModulo = (() => {

    var exibirLoading = (callback) => {
    
        $(".backdrop-loading").fadeIn(400, callback);

    };

    var esconderLoading = (callback) => {

        $(".backdrop-loading").fadeOut(400, callback);
    };

    var isLoading = () => {
        return $(".backdrop-loading").css("display") !== "none";
    };

    return {
        exibirLoading: exibirLoading,
        esconderLoading: esconderLoading,
        isLoading: isLoading
    }

})();