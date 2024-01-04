
var codeDayWork = null;
var selectedDay = null;
var selectedHour = null;
$(document).ready(function () {

    const url = "/api/management/getreservedtimes";

    $.ajax({
        url: url,
        type: 'GET',
        contentType: 'application/json',
        success: function (data) {
            if (data.length > 0) {
                data.forEach(function (elemento) {

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

    const url = "/api/management/createreservedtime";
    
    let objToSend = {
        "Hour": textHour,
        "Day": dayWeek,
        "Description": textPerson
    };
    
    $.ajax({
        url: url,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(objToSend),  // Envia objeto
        success: function (data) {

            let code = data;
            $(idClientBtn).html(`<button type="button" class="btn btn-link" onclick="VacateTime('${code}','${idClientBtn}','${idClientPerson}','${selectedDay}','${dayWeek}','${textHour}')">Disponibilizar</button>`);
            $(idClientPerson).html(`<b class="text-primary">${textPerson}</b>`);

            let modal = bootstrap.Modal.getOrCreateInstance(document.getElementById('modalReservedTime')) // Returns a Bootstrap modal instance
            modal.hide();

        },
        error: function (error) {
            console.error('Erro:', error);
        }
    });

}

function VacateTime(code, idClientBtn, idClientPerson, dayNumber, dayWeek, hour) {

    const url = "/api/management/deletereservedtime";

    $.ajax({
        url: url,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(code),  // Envia a string diretamente
        success: function (data) {
            console.log('Resposta do Backend:', data);

            $(idClientBtn).html(`<button type="button" class="btn btn-link" onclick="OpenModalDayWork('${dayNumber}','${dayWeek}','${hour}')">Reservar</button>`);
            $(idClientPerson).html(`<b class="text-success">LIVRE</b>`);

        },
        error: function (error) {
            console.error('Erro:', error);
        }
    });
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
