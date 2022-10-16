// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.addEventListener('load', myfunc, false);

function myfunc() {
    $.ajax({
        type: "GET",
        url: "https://localhost:5001/api/courses/",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            "Authorization": "Bearer " + token
        },
        success: function (res) {
            var i = 1;
            $.each(res, function (data, value) {
                $("#coursesDropDown").append($("<option " + (i == courseValue ? 'selected' : '') + "></option>").val(i++).html(value.CourseName));

            })
        },
        error: function () {
            alert("Wrong request!");
        }
    })


    $.ajax({
        type: "GET",
        url: "https://localhost:5001/api/sections/",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            "Authorization": "Bearer " + token
        },
        success: function (res) {
            var i = 1;
            $.each(res, function (data, value) {
                $("#sectionsDropDown").append($("<option " + (i == sectionValue ? 'selected' : '') + "></option>").val(i++).html(value.SectionName));

            })
        },
        error: function () {
            alert("Wrong request! section");
        }
    })
}
