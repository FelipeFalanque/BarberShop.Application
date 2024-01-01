
var codeDayWork = null;
$(document).ready(function () {


});
function OpenModalDayWork(code, description, hour) {

    $("#modalReservedTimeBodyLabel").text(description);

    $("#textHour").val(hour);

    let modal = bootstrap.Modal.getOrCreateInstance(document.getElementById('modalReservedTime')) // Returns a Bootstrap modal instance
    // Show or hide:
    modal.show();
    //modal.hide();

    codeDayWork = code;
}

function ConfirmButton() {

    let code = codeDayWork
    let isOpenSelected = $("#radioOpen").is(":checked");

    if (isOpenSelected) {
        $(`#txtOpenClose_${code}`).removeClass('text-danger');
        $(`#txtOpenClose_${code}`).addClass('text-success');
        $(`#txtOpenClose_${code}`).text('ABERTO');
    } else {
        $(`#txtOpenClose_${code}`).removeClass('text-success');
        $(`#txtOpenClose_${code}`).addClass('text-danger');
        $(`#txtOpenClose_${code}`).text('FECHADO');
    }

    let selectStartHour = $("#selectStartHour").val();
    let selectLastHour = $("#selectLastHour").val();

    $(`#txtOpen_${code}`).text(selectStartHour);
    $(`#txtClose_${code}`).text(selectLastHour);

    const url = "/api/management/setdaywork";

    let objToSend = {
        "Code": code,
        "Start": selectStartHour,
        "End": selectLastHour,
        "Day": "",
        "Open": isOpenSelected,
        "Description": ""
    };

    $.ajax({
        url: url,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(objToSend),  // Envia objeto
        success: function (data) {

            console.log('Resposta do Backend:', data);
            let modal = bootstrap.Modal.getOrCreateInstance(document.getElementById('modalDayWork')) // Returns a Bootstrap modal instance
            modal.hide();
        },
        error: function (error) {
            console.error('Erro:', error);
        }
    });

}
