﻿document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.querySelector("#searchInput");
    const searchBtn = document.querySelector("#searchBtn");

    searchBtn.disabled = true; //setting button state to disabled

    searchInput.addEventListener("input", stateHandle);

    function stateHandle() {
        if (searchInput.value === "") {
            searchBtn.disabled = true; //button remains disabled
        } else {
            searchBtn.disabled = false; //button is enabled
        }
    }
});