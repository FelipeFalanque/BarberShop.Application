
var codeDayWork = null;
$(document).ready(function () {


});
function OpenModalDayWork(code, description, start, end, open) {

    $("#modalDayWorkBodyLabel").text(description);

    $("#radioOpen").prop("checked", open);
    $("#radioClose").prop("checked", !open);

    $("#selectStartHour").val(start);
    $("#selectLastHour").val(end);

    let modal = bootstrap.Modal.getOrCreateInstance(document.getElementById('modalDayWork')) // Returns a Bootstrap modal instance
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

}
