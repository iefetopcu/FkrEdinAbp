$(document).ready(function () {
    var commentRate = 0;
    var commentCount = 0;
    
    $.getJSON("https://localhost:44312/api/services/app/ProductComment/GetAll", function (data) {
        $.each(data.result.items, function (i, field) {
            
            var commentproductId = $("#forcommentproductId").val();
            
            if (field.productId == commentproductId && field.approved == true) {
                $("#commentLines").append('<div class="col-xs-12 col-lg-12 col-sm-12 no-margin">' +
                    '<div class="comment-body">' +
                    '<div class="meta-info">' +
                    '<div class="author inline"><h4>' + field.productCommentName + '</h4></div> ' +
                    '<div class="star-holder inline">' + field.productRate + '</div>' +
                    '<div class="date inline pull-right">' + field.creationTime + '</div>' +
                    '</div>' + (field.modelString != null ? '<b style="color:#FE8C5A">' + field.modelString + '</b>' : '') +
                    '<p class="comment-text">' + field.productCommentDescription + '</p>' +
                    '</div>' +
                    '</div >');  

                commentCount++;              
                commentRate += field.productRate;


            }    
        });

        console.log("Rate : " + commentRate);
        console.log("Comment Count : " + commentCount);
        var commentRateaverage = commentRate / commentCount;
        console.log("Rate Avarage : " + commentRateaverage);
        $("#rateavarage").append(commentRateaverage.toFixed(1));

        if (commentRateaverage == 0) {
            $("#ratestar1").hide();
            $("#ratestar2").hide();
            $("#ratestar3").hide();
            $("#ratestar4").hide();
            $("#ratestar5").hide();
        }
        else if (commentRateaverage <= 1.5) {
            $("#ratestar1").show();
            $("#ratestar2").hide();
            $("#ratestar3").hide();
            $("#ratestar4").hide();
            $("#ratestar5").hide();
        } else if (commentRateaverage <= 2.5) {
            $("#ratestar1").show();
            $("#ratestar2").show();
            $("#ratestar3").hide();
            $("#ratestar4").hide();
            $("#ratestar5").hide();
        } else if (commentRateaverage <= 3.5) {
            $("#ratestar1").show();
            $("#ratestar2").show();
            $("#ratestar3").show();
            $("#ratestar4").hide();
            $("#ratestar5").hide();
        } else if (commentRateaverage <= 4.5) {
            $("#ratestar1").show();
            $("#ratestar2").show();
            $("#ratestar3").show();
            $("#ratestar4").show();
            $("#ratestar5").hide();
        } else {
            $("#ratestar1").show();
            $("#ratestar2").show();
            $("#ratestar3").show();
            $("#ratestar4").show();
            $("#ratestar5").show();
        }
            
            
    });
});

