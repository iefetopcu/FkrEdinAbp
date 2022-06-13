//(function ($) {
//    var _CommentService = abp.services.app.productComment,
//        _$form = $('#commentform');



//    _$form.find('.save-button').on('click', (e) => {
//        e.preventDefault();
//        console.log("Forma girdi")
//        if (!_$form.valid()) {
//            return;
//        }
//        var values = _$form.serializeFormToObject();
       
//        _CommentService.create(values).done(function () {          
//            _$form[0].reset();
//            abp.notify.info(l('SavedSuccessfully'));           
//        }).always(function () {
            
//        });
//    });


//})(jQuery);

