$(document).ready(function () {
    $.getJSON("/api/services/app/BlogCategory/GetAll", function (data) {
        $.each(data.result.items, function (i, field) {
            console.log(data.result.items);
            $('#blogcategorylist').append('<div class="col-lg-2 text-center rounded" style="margin:5px; background-color:#3498db;"><a href="#"><h2 style="padding:50px; color:white;">' + field.categoryName + '</h2></a></div>');           
        });
    });
});





