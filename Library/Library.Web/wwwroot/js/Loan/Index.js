"use strict"

$(document).ready(function () {
    const lstUsers = $("select");
    const btnView = $("button");

    lstUsers.prop("selectedIndex", -1);
    btnView.prop("disabled", true);

    lstUsers.on("change", () => {
        btnView.prop("disabled", false);
    });
});