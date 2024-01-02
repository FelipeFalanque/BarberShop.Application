
var codeDayWork = null;
var selectedDay = null;
var selectedHour = null;
$(document).ready(function () {


});
function OpenModalDayWork(day, description, hour) {

    $("#modalReservedTimeBodyLabel").text(description);

    $("#textHour").val(hour);
    $("#textPerson").val("");

    $("#textPersonHelp").hide();

    let modal = bootstrap.Modal.getOrCreateInstance(document.getElementById('modalReservedTime')) // Returns a Bootstrap modal instance
    // Show or hide:
    modal.show();
    //modal.hide();

    selectedDay = day;
    selectedHour = hour.replace(":", "");
}

function ConfirmButton() {


    let textHour = $("#textHour").val();
    let textPerson = $("#textPerson").val();

    if (textPerson.length == 0) {
        $("#textPersonHelp").show();
        return;
    }

    let idClientBtn = `#${selectedDay}Btn-${selectedHour}`;
    let idClientPerson = `#${selectedDay}Person-${selectedHour}`;

    let dayWeek = $("#modalReservedTimeBodyLabel").text();

    $(idClientBtn).html(`<button type="button" class="btn btn-link" onclick="VacateTime('','${idClientBtn}','${idClientPerson}','${selectedDay}','${dayWeek}','${textHour}')">Disponibilizar</button>`);
    $(idClientPerson).html(`<b class="text-primary">${textPerson}</b>`);

    let modal = bootstrap.Modal.getOrCreateInstance(document.getElementById('modalReservedTime')) // Returns a Bootstrap modal instance
    modal.hide();

    //const url = "/api/management/setdaywork";
    //
    //let objToSend = {
    //    "Code": code,
    //    "Start": selectStartHour
    //};
    //
    //$.ajax({
    //    url: url,
    //    type: 'POST',
    //    contentType: 'application/json',
    //    data: JSON.stringify(objToSend),  // Envia objeto
    //    success: function (data) {
    //
    //        console.log('Resposta do Backend:', data);
    //        let modal = bootstrap.Modal.getOrCreateInstance(document.getElementById('modalDayWork')) // Returns a Bootstrap modal instance
    //        modal.hide();
    //    },
    //    error: function (error) {
    //        console.error('Erro:', error);
    //    }
    //});

}

function VacateTime(code, idClientBtn, idClientPerson, dayNumber, dayWeek, hour) {




    $(idClientBtn).html(`<button type="button" class="btn btn-link" onclick="OpenModalDayWork('${dayNumber}','${dayWeek}','${hour}')">Reservar</button>`);
    $(idClientPerson).html(`<b class="text-success">LIVRE</b>`);
}
