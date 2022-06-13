$(document).ready(function () {
    var catId = $("#categoryId").val();
    $.getJSON(`api/services/app/Product/GetProducts?CategorId=` + catId, function (data) {
        $.each(data.result.items, function (i, field) {
            console.log(field)
            //if (field.productShowcase == true) {
            //    $("#productslistsponsor").append('<div class="col-lg-3 text-center"><div class="product-item" style="margin-bottom:30px;">' +
            //        '<div class="image"><img src="Common/Product/' + field.picture + '" height="100"/></div>'
            //        + '<div class="body"><div class="title"><a href="Urun/' + field.url + '">' + field.productName + '</a></div></div>'
            //        + '</div></div>');
            //}

            //if (field.productShowcase != true) {
            //    $("#productslist").append('<div class="col-lg-3 text-center"><div class="product-item" style="margin-bottom:30px;">' +
            //        '<div class="image"><img src="Common/Product/' + field.picture + '" height="100"/></div>'
            //        + '<div class="body"><div class="title"><a href="Urun/' + field.url + '">' + field.productName + '</a></div></div>'
            //        + '</div></div>');
            //}
        });
    });
    $.getJSON("/api/services/app/Category/GetAll", function (data) {
        $.each(data.result.items, function (i, field) {
            
            if (field.parentid == catId) {
                $('#categorylist').append('<li class="dropdown menu-item"> <a href="?url=' + field.url + '" class="dropdown-toggle" >'+field.categoryName +'</a></li>');
            }
        });
    });
});





