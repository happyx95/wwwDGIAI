
var llamarAlertaInfo = function (mensaje, titulo) {
    alertify.defaults.glossary.title = titulo;
    alertify.alert(mensaje, function () {
    });   
}

function notificarInfo(msg) {
    alertify.success(msg);
}
function notificarError(msg) {
    alertify.error(msg);
}
function notificarAdv(msg) {
    alertify.warning(msg);
}
