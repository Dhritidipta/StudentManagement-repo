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
        success: function (res) {
            $.each(res, function (data, value) {
                console.log(value.CourseName);
                $("#coursesDropDown").append($("<option></option>").val(value.CourseName).html(value.CourseName));
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
        success: function (res) {
            $.each(res, function (data, value) {
                console.log(value.SectionName);
                $("#sectionsDropDown").append($("<option></option>").val(value.SectionName).html(value.SectionName));
            })
        },
        error: function () {
            alert("Wrong request!");
        }
    })
}
