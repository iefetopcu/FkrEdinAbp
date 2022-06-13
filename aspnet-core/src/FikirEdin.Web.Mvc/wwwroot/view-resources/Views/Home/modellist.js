$(document).ready(function () {
    
    $.getJSON("https://localhost:44312/api/services/app/ProductModel/GetAll", function (data) {
        var modelcount = 0;
        $("#modellist").hide();
        $.each(data.result.items, function (i, field) {             
            var productId = $("#forcommentproductId").val();        
            if (field.productId == productId) {
                
                $("#modellist").append('<option value="' + field.productModelName + '">' + field.productModelName + '</option>');
                
                modelcount++;
            }
        });
        console.log("Model count : " + modelcount);
        if (modelcount > 0) {
            $("#modellist").show();
            $("#infomessage").append('<i style="color:red;" id="">Lütfen bir model seçiniz.</i>');
        }
    });
});

