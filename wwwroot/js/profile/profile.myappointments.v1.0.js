
$(document).ready(function () {

});

function Cancel(code) {

    const url = "/api/appointments/cancel";

    $.ajax({
        url: url,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(code),  // Envia a string diretamente
        success: function (data) {
            console.log('Resposta do Backend:', data);

            $(`#btn_${code}`).removeClass('btn btn-danger btn-sm');
            $(`#btn_${code}`).addClass('btn btn-secondary btn-sm');

            $(`#txt_${code}`).removeClass('text-success');
            $(`#txt_${code}`).addClass('text-danger');

            $(`#txt_${code}`).text('Sim');

        },
        error: function (error) {
            console.error('Erro:', error);
        }
    });
}
