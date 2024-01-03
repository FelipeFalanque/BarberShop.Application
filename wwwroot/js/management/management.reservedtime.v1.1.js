
var codeDayWork = null;
var selectedDay = null;
var selectedHour = null;
$(document).ready(function () {

    const url = "/api/management/reservedtimes";

    $.ajax({
        url: url,
        type: 'GET',
        contentType: 'application/json',
        success: function (data) {
            if (data.length > 0) {
                data.forEach(function (elemento) {
                    console.log(elemento);

                    selectedDay = ConvertDayToValue(elemento.day);
                    selectedHour = elemento.hour.replace(":", "");

                    let idClientBtn = `#${selectedDay}Btn-${selectedHour}`;
                    let idClientPerson = `#${selectedDay}Person-${selectedHour}`;

                    $(idClientBtn).html(`<button type="button" class="btn btn-link" onclick="VacateTime('${elemento.code}','${idClientBtn}','${idClientPerson}','${selectedDay}','${elemento.day}','${elemento.hour}')">Disponibilizar</button>`);
                    $(idClientPerson).html(`<b class="text-primary">${elemento.description}</b>`);

                });
            };
        },
        error: function (error) {
            console.error('Erro:', error);
        }
    });

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

    const url = "/api/management/setdaywork";
    
    let objToSend = {
        "Code": code,
        "Start": selectStartHour
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

function VacateTime(code, idClientBtn, idClientPerson, dayNumber, dayWeek, hour) {

    $(idClientBtn).html(`<button type="button" class="btn btn-link" onclick="OpenModalDayWork('${dayNumber}','${dayWeek}','${hour}')">Reservar</button>`);
    $(idClientPerson).html(`<b class="text-success">LIVRE</b>`);
}

function ConvertDayToValue(day) {
    // Mapeamento entre os dias da semana e os valores desejados
    const dayMapping = {
        'Segunda': 'dayOne',
        'Terça': 'dayTwo',
        'Terca': 'dayTwo',
        'Quarta': 'dayThree',
        'Quinta': 'dayFour',
        'Sexta': 'dayFive',
        'Sábado': 'daySix',
        'Sabado': 'daySix',
        'Domingo': 'daySeven'
    };

    // Converte o dia para o valor correspondente, ou retorna null se nao encontrado
    return dayMapping[day] || null;
}
