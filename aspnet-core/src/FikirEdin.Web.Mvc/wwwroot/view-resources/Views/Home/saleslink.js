$(document).ready(function () {

    $.getJSON("https://localhost:44312/api/services/app/ProductAddLink/GetAll", function (data) {
        $.each(data.result.items, function (i, field) {
            
            var saleslinkproductId = $("#forcommentproductId").val();
            
            if (field.productId == saleslinkproductId) {
                $("#saleslink").append(' <a href="' + field.salesLink +'" class="btn btn" style="margin-right:10px; background-color:#' + field.buttonColor +'; color:white;" target="_blank">' + field.shoppingCentre +'</a>');
            }
            

                

        });
    });
});

