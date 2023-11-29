
var appointment = {
    "Day": "",
    "Month": "",
    "Year": "",
    "Hour": "",
    "Minute": "",
    "Observation": ""
}

var connection = null;

$(document).ready(function () {

    GetHours();

    connection = new signalR.HubConnectionBuilder()
        .withUrl("/appointmentHub")
        .build();

    connection.on("ReceiveAppointmentConfirmed", function (appointmentCode) {
        // Lógica para exibir a mensagem recebida
        console.log("Codigo recebido do servidor " + appointmentCode);

        $(`#${appointmentCode}`).removeClass('btn-dark');
        $(`#${appointmentCode}`).removeClass('btn-secondary');
        $(`#${appointmentCode}`).addClass('btn-danger');
        $(`#${appointmentCode}`).addClass('disabled');
    });

    connection.start().catch(function (err) {
        console.error(err.toString());
    });

});

function SendAppointmentConfirmed(appointmentCode) {
    connection.invoke("SendAppointmentConfirmed", appointmentCode).catch(function (err) {
        console.error(err.toString());
    });
}

function GetHours() {

    const url = "/api/appointments";

    // Configuração da requisição
    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {
            BindDay(response.dayOne, "one");
            BindDay(response.dayTwo, "two");
            BindDay(response.dayThree, "three");
            BindDay(response.dayFour, "four");
            BindDay(response.dayFive, "five");
        },
        error: function (error) {
            console.error('Erro na requisição:', error);
        }
    });
}
function BindDay(list, day) {

    let leftOn = true;
    let rightOn = true;
    list.forEach(function (item, index, array) {

        if (index == 0) {
            $("#day-" + day + "-text").text(item.dayText);
        }

        let button = null;

        if (!(index % 2)) {

            if (leftOn) {
                button = `<button class="btn btn-dark" type="button" id="${ "".concat(item.day, item.month, item.year, item.hour, item.minute) }" onclick="OpenModalAppointment('${item.day}', '${item.month}', '${item.year}', '${item.hour}', '${item.minute}', '${item.dayText}')">${item.title}</button>`;
            }
            else {
                button = `<button class="btn btn-secondary" type="button" id="${"".concat(item.day, item.month, item.year, item.hour, item.minute) }" onclick="OpenModalAppointment('${item.day}', '${item.month}', '${item.year}', '${item.hour}', '${item.minute}', '${item.dayText}')">${item.title}</button>`;
            }
            leftOn = !leftOn;
            $("#day-" + day +"-left").append(button);
        }
        else {
            if (rightOn) {
                button = `<button class="btn btn-secondary" type="button" id="${"".concat(item.day, item.month, item.year, item.hour, item.minute) }" onclick="OpenModalAppointment('${item.day}', '${item.month}', '${item.year}', '${item.hour}', '${item.minute}', '${item.dayText}')">${item.title}</button>`;
            }
            else {
                button = `<button class="btn btn-dark" type="button" id="${"".concat(item.day, item.month, item.year, item.hour, item.minute) }" onclick="OpenModalAppointment('${item.day}', '${item.month}', '${item.year}', '${item.hour}', '${item.minute}', '${item.dayText}')">${item.title}</button>`;
            }
            rightOn = !rightOn;
            $("#day-" + day +"-right").append(button);
        }
    });
}

function CreateAppointment() {

    const url = "/api/appointments";

    appointment.Observation = $("#inputCliente").val();

    // Configuração da requisição
    $.ajax({
        type: 'POST',
        url: url,
        contentType: 'application/json',
        data: JSON.stringify(appointment),
        success: function (response) {
            console.log('Resposta do servidor:', response);

            $(`#${"".concat(appointment.Day, appointment.Month, appointment.Year, appointment.Hour, appointment.Minute) }`).removeClass('btn-dark');
            $(`#${"".concat(appointment.Day, appointment.Month, appointment.Year, appointment.Hour, appointment.Minute) }`).removeClass('btn-secondary');
            $(`#${"".concat(appointment.Day, appointment.Month, appointment.Year, appointment.Hour, appointment.Minute) }`).addClass('btn-danger');
            $(`#${"".concat(appointment.Day, appointment.Month, appointment.Year, appointment.Hour, appointment.Minute)}`).addClass('disabled');

            let modal = bootstrap.Modal.getOrCreateInstance(document.getElementById('modalAppointment')) // Returns a Bootstrap modal instance
            modal.hide();

            // SendAppointmentConfirmed("".concat(appointment.Day, appointment.Month, appointment.Year, appointment.Hour, appointment.Minute));
        },
        error: function (error) {
            console.error('Erro na requisição:', error);
        }
    });
}

function OpenModalAppointment(textDay, textMonth, textYear, textHour, textMinute, textDayFormarter) {

    appointment.Day = textDay;
    appointment.Month = textMonth;
    appointment.Year = textYear;
    appointment.Hour = textHour;
    appointment.Minute = textMinute;

    $("#inputCliente").hide();

    $("#modalAppointmentLabel").text(`Confirmar Agendamento`);

    $("#modalAppointmentBodyLabel").text(`Quer confirmar o agendamento as ${textHour.concat(":", textMinute) } na ${textDayFormarter} ?`);

    $("#inputCliente").val('');

    if ($('#inputHiddenRole').val() == "Admin")
        $("#inputCliente").show();  

    let modal = bootstrap.Modal.getOrCreateInstance(document.getElementById('modalAppointment')) // Returns a Bootstrap modal instance
    // Show or hide:
    modal.show();
    //modal.hide();
}

function ConfirmButton() {
    CreateAppointment();
}