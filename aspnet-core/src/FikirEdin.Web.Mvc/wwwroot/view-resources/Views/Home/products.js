$(document).ready(function () {
    
    $.getJSON("api/services/app/Product/GetAll", function (data) {
        $.each(data.result.items, function (i, field) {
            console.log(field)
            if (field.productShowcase == true) {
                $("#productslistsponsor").append('<div class="col-lg-3 text-center"><div class="product-item" style="margin-bottom:30px;">' +
                    '<div class="image"><img src="Common/Product/' + field.picture + '" height="100"/></div>'
                    + '<div class="body"><div class="title"><a href="Home/Urun?url=' + field.url + '" class="text-secondary"><b >' + field.productName + '</b></a></div></div>'
                    + '</div></div>');
            }

            if (field.productShowcase != true) {
                $("#productslist").append('<div class="col-lg-3 text-center"><div class="product-item" style="margin-bottom:30px;">' +
                    '<div class="image"><img src="Common/Product/' + field.picture + '" height="100"/></div>'
                    + '<div class="body"><div class="title"><a href="Home/Urun?url=' + field.url + '">' + field.productName + '</a></div></div>'
                    + '</div></div>');
            }
        });
    });
});

