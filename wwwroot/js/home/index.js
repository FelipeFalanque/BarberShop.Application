
$(document).ready(function () {
    GetHours();
});

function GetHours() {

    const url = "/Home/Hours";

    var jqxhr = $.ajax({
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

    list.forEach(function (item, index, array) {

        if (index == 0) {
            $("#day-" + day + "-text").text(item.dayText);
        }

        let button = null;

        if (!(index % 2)) {

            if (leftOn) {
                button = `<button class="btn btn-dark" type="button">${item.title}</button>`;
            }
            else {
                button = `<button class="btn btn-secondary" type="button">${item.title}</button>`;
            }
            leftOn = !leftOn;
            $("#day-" + day +"-left").append(button);
        }
        else {
            if (rightOn) {
                button = `<button class="btn btn-secondary" type="button">${item.title}</button>`;
            }
            else {
                button = `<button class="btn btn-dark" type="button">${item.title}</button>`;
            }
            rightOn = !rightOn;
            $("#day-" + day +"-right").append(button);
        }
    });
}