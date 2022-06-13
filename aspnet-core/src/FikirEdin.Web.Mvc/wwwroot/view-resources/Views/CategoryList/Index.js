$(document).ready(function () {
    var catId = $("#catId").val()
    //$.getJSON(`api/services/app/Product/GetAll?categorId=` + catId, function (data) {
    //    $.each(data.result.items, function (i, field) {
    //        console.log(field)
    //        if (field.productShowcase == true) {
    //            $("#productslistsponsor").append('<div class="col-lg-3 text-center"><div class="product-item" style="margin-bottom:30px;">' +
    //                '<div class="image"><img src="Common/Product/' + field.picture + '" height="100"/></div>'
    //                + '<div class="body"><div class="title"><a href="Urun/' + field.url + '">' + field.productName + '</a></div></div>'
    //                + '</div></div>');
    //        }

    //        if (field.productShowcase != true) {
    //            $("#productslist").append('<div class="col-lg-3 text-center"><div class="product-item" style="margin-bottom:30px;">' +
    //                '<div class="image"><img src="Common/Product/' + field.picture + '" height="100"/></div>'
    //                + '<div class="body"><div class="title"><a href="Urun/' + field.url + '">' + field.productName + '</a></div></div>'
    //                + '</div></div>');
    //        }
    //    });
    //});

    $.getJSON("/api/services/app/Category/GetTreeCategories", function (data) {
        $.each(data.result, function (i, field) {
            console.log(data.result);
            if (field.parentId == 0) {
                $('#categorylist').append('<li class="dropdown menu-item"> <a href="Category/Index?url='+field.url+'" class="dropdown-toggle" >' + field.name + '</a></li>');
            }
        });
    });
});





