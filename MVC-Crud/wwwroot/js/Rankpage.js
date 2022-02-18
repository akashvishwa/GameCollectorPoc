// jquerry for add Rank form which will list all options through ajax


$(document).ready(function () {



    // for gamer data
    $.ajax({
        url: `/Ranking/FetchGamerData/`,
        type: "GET",
        async: false,
        dataType: "json",
        contentType: "application/json",
        success: function (result) {

            console.log(result);
            $.each(result, function (key, value) {

                $("#AddGamerName").append($("<option>", { value: value.profileId }).text(value.gamerName));
            });

        }

    }
    );

    // for game data
    $.ajax({
        url: `/Ranking/FetchGameData/`,
        type: 'GET',
        async: false,
        dataType: "json",
        contentType: "application/json",
        success: function (result2) {

            console.log(result2);
            $.each(result2, function (key, value) {

                $("#AddGameName").append($("<option>", { value: value.id }).text(value.gameName));
            });
        }
    });



});