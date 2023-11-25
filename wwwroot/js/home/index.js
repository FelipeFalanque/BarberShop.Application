
$(document).ready(function () {
    GetHours();
});

function GetHours() {

    const url = "/api/appointments";

    var jqxhr = $.ajax({
        type: "GET",
        url: url,
        // data: data,
        //success: success,
        dataType: "json"
    });

    jqxhr.done(function (resp) {
        console.log(resp);
        BindDay(resp.dayOne, "one");
        BindDay(resp.dayTwo, "two");
        BindDay(resp.dayThree, "three");
        BindDay(resp.dayFour, "four");
        BindDay(resp.dayFive, "five");
    })
}
function BindDay(list, day) {

    let leftOn = true;
    let rightOn = true;

    let role = $('#inputHiddenRole').val();

    console.log(role);

    list.forEach(function (item, index, array) {

        if (index == 0) {
            $("#day-" + day + "-text").text(item.dayText);
        }

        let button = null;

        if (!(index % 2)) {

            if (leftOn) {
                button = `<button class="btn btn-dark" type="button" onclick="OpenModalAppointment('${item.title}', '${item.dayText}')">${item.title}</button>`;
            }
            else {
                button = `<button class="btn btn-secondary" type="button" onclick="OpenModalAppointment('${item.title}', '${item.dayText}')">${item.title}</button>`;
            }
            leftOn = !leftOn;
            $("#day-" + day +"-left").append(button);
        }
        else {
            if (rightOn) {
                button = `<button class="btn btn-secondary" type="button" onclick="OpenModalAppointment('${item.title}', '${item.dayText}')">${item.title}</button>`;
            }
            else {
                button = `<button class="btn btn-dark" type="button" onclick="OpenModalAppointment('${item.title}', '${item.dayText}')">${item.title}</button>`;
            }
            rightOn = !rightOn;
            $("#day-" + day +"-right").append(button);
        }
    });
}

function CreateAppointment() {

    const url = "/api/appointments";

    let dataSend = {
        "day" : 1,
        "month" : 2,
        "year" : 2023,
        "hour" : 18,
        "minute" : 30,
        "observation" : "Jose Maria"
    };

    var jqxhr = $.ajax({
        type: "POST",
        url: url,
        data: "Text my JS",
        //success: success,
        dataType: "json",
        success: function (resp) {
            console.log(resp)
        },
        error: function (error, errorInfo) {
            console.log(error);
            console.log(errorInfo);
        }
    });

    jqxhr.done(function (resp) {
        console.log("POST /api/appointments");
        console.log(resp);
    })
}

function OpenModalAppointment(textHour, textDay) {

    $("#inputCliente").hide();

    $("#modalAppointmentLabel").text(`Confirmar Agendamento`);

    $("#modalAppointmentBodyLabel").text(`Quer confirmar o agendamento as ${textHour} na ${textDay} ?`);

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